using StoreKeyCodeTestAidin.Models.Campaign;
using StoreKeyCodeTestAidin.Models.Cart;

namespace StoreKeyCodeTestAidin.Repositories;
/// <summary>
/// Class <c>ProductRepository</c>
/// As the code test does not have a any real storage, the Dictionary-objects will hold the look-up values.
/// But the class will act somewhat as a real repository.
/// </summary>

public class ProductRepository
{
    //CampaignInfo can hold any attribute needed.
    public readonly Dictionary<string, CampaignInfo> VolumeProducts = new()
    {
        { "8711000530085", new CampaignInfo { CampaignPrice = 85, MinPurchaseQuantity = 2} },
        { "7310865004703",  new CampaignInfo { CampaignPrice = 20, MinPurchaseQuantity = 2} }
    };
    
    //All keys in ComboProducts have the same value as its the key-lookup that is needed.
    public readonly Dictionary<string, int> ComboProducts = new()
    {
        { "5000112637922", 30 },
        { "5000112637939", 30 },
        { "7310865004703", 30 },
        { "7340005404261", 30 },
        { "7310532109090", 30 },
        { "7611612222105", 30 },
    };
    
    /// <summary>
    /// Method <c>GetVerifiedComboProducts</c> Will return products that are in the look-up-table.
    /// <param name="customerCart"> List of Customer cart <see cref="CustomerCart"/></param>
    /// <returns> List<CartAttributes> </returns>
    /// </summary>
    public List<CartAttributes> GetVerifiedComboProducts(CustomerCart customerCart)
    {
        return customerCart.Cart.Where(ca => ComboProducts.ContainsKey(ca.ProductNumber)).ToList();
    }
    
    /// <summary>
    /// Method <c>GetVerifiedComboProducts</c> Will return products that are NOT in the look-up-table.
    /// <param name="customerCart"> List of Customer cart <see cref="CustomerCart"/></param>
    /// <returns> List<CartAttributes> </returns>
    /// </summary>
    public List<CartAttributes> GetUnVerifiedComboProducts(CustomerCart customerCart)
    {
        return customerCart.Cart.Where(ca => !ComboProducts.ContainsKey(ca.ProductNumber)).ToList();
    }
}