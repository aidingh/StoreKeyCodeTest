using System.Globalization;
using StoreKeyCodeTestAidin.Models.Cart;
using StoreKeyCodeTestAidin.Repositories;

namespace StoreKeyCodeTestAidin.Services;
/// <summary>
/// Class <c>ComboCampaignsService</c> will handle business logic for customer carts.
/// Repository Reference: <see cref="ProductRepository"/> 
/// </summary>
public class ComboCampaignsService
{
    private readonly ProductRepository _productRepository;
    private const int ComboPrice = 30;

    public ComboCampaignsService(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    /// <summary>
    /// Method <c>ComboCampaignsValidator</c>
    /// Will determine if the cart has combo-campaigns.
    /// As a combo must be > 2 and a combo must be from a even number.
    /// Repository provides verified and unverified products-campaigns from the cart.
    /// If the verified products are even we calculate a combo price.
    /// If its the other way around (verified values are odd), then we calculate a new combo price and the rest from the verified products and the unverified.
    /// If verified products are odd and we have a unverified product, then we must calculate the new price accordingly.
    /// <param name="customerCart"> <see cref="customerCart"/> customer object </param>
    /// <returns> Returns a combo-checkout response to the client.</returns>
    /// </summary>
    public string? ComboCampaignsValidator(CustomerCart customerCart)
    {
        var unVerifiedProducts = _productRepository.GetUnVerifiedComboProducts(customerCart);
        var verifiedProducts = _productRepository.GetVerifiedComboProducts(customerCart);

        if(verifiedProducts.Count < 2)
        {
            return null;
        }
        
        switch (verifiedProducts.Count % 2)
        {
            case 0:
            {
                var sumOfUnVerifiedProducts = unVerifiedProducts.Sum(x => x.ProductPrice);
                var sum = (verifiedProducts.Count / 2) * ComboPrice + sumOfUnVerifiedProducts;
                return sum.ToString(CultureInfo.CurrentCulture);
            }
            case > 0:
            {
                var lastVerifiedProduct = verifiedProducts.Last();
                var sumOfUnVerifiedProducts = unVerifiedProducts.Sum(x => x.ProductPrice);
            
                var restProducts = lastVerifiedProduct.ProductPrice + sumOfUnVerifiedProducts;
                double sum = ((verifiedProducts.Count - 1) / 2 * ComboPrice);
                sum += restProducts;
            
                return sum.ToString(CultureInfo.CurrentCulture);
            }
            default:
                return null;
        }
    }
}