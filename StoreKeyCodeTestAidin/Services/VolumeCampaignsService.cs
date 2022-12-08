using System.Globalization;
using StoreKeyCodeTestAidin.Models.Cart;
using StoreKeyCodeTestAidin.Repositories;

namespace StoreKeyCodeTestAidin.Services;
/// <summary>
/// Class <c>VolumeCampaignsService</c> will handle business logic for customer carts.
/// Repository Reference: <see cref="ProductRepository"/> 
/// </summary>
public class VolumeCampaignsService
{
    private readonly ProductRepository _productRepository;

    public VolumeCampaignsService(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    /// <summary>
    /// Method <c>VolumeCampaignsValidator</c>
    /// Will determine if the cart has volume-campaigns.
    /// If the product is verified and Minimum Purchase Quantity is true, then ge acquire the volume-campaigns.price.
    /// If there is a product with no volume-campaigns set, we get the sum of those products and add to the volume-campaigns-price.
    /// <param name="customerCart"> <see cref="customerCart"/> customer object </param>
    /// <returns> Returns a combo-checkout response to the client.</returns>
    /// </summary>
    public string VolumeCampaignsValidator(CustomerCart customerCart)
    {
        var verified = new List<CartAttributes>();
        double volumeComboPrice = 0;

        foreach (var ca in customerCart.Cart.Where(ca => _productRepository.VolumeProducts.ContainsKey(ca.ProductNumber)))
        {
            verified.Add(ca);
            if (verified.Count == _productRepository.VolumeProducts[ca.ProductNumber].MinPurchaseQuantity)
            {
                volumeComboPrice = _productRepository.VolumeProducts[ca.ProductNumber].CampaignPrice;
                break;
            }
        }

        var restPrice = customerCart.Cart.Where(ca => !_productRepository.VolumeProducts.ContainsKey(ca.ProductNumber)).Sum(ca => ca.ProductPrice);
        var result = restPrice + volumeComboPrice;
        
        return result.ToString(CultureInfo.CurrentCulture);
    }
}