namespace StoreKeyCodeTestAidin.Models.Campaign;
/// <summary>
/// Class <c>CampaignInfo</c>
/// Used to hold volume-campaigns key-values <see cref="Repositories.ProductRepository.VolumeProducts"/>
/// </summary>
public class CampaignInfo
{
    public int CampaignPrice { get; set; }
    public int MinPurchaseQuantity { get; set; }
}