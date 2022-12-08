using StoreKeyCodeTestAidin.Services;
using Microsoft.AspNetCore.Mvc;
using StoreKeyCodeTestAidin.Models.Cart;

namespace StoreKeyCodeTestAidin.Controllers;
/// <summary>
/// Class <c>VolumeController</c>
/// Will receive a cart object <see cref="CustomerCart"/> and will return a response depending if the cart has volume-campaigns.
/// </summary>

[ApiController]
[Route("[controller]")]
public class VolumeController : ControllerBase
{
    private readonly VolumeCampaignsService _volumeCampaignsService;
    
    public VolumeController(VolumeCampaignsService volumeCampaignsService)
    {
        _volumeCampaignsService = volumeCampaignsService;
    }
    
    /// <summary>
    /// Method <c>VolumeCheckout</c>
    /// <param name="customerCart"> <see cref="CustomerCart"/> Request body sent by the client </param>
    /// <returns> <see cref="IActionResult"/> Returns a response object to the client. </returns>
    /// <exception cref="T:System.InvalidOperationException"> If the DeserializeObject fails. </exception>.
    /// </summary>
    [HttpPost(Name = "Volume-Checkout")]
    public IActionResult VolumeCheckout([FromBody] CustomerCart? customerCart)
    {
        if (customerCart == null)
        {
            return BadRequest();
        }
        
        var response = _volumeCampaignsService.VolumeCampaignsValidator(customerCart);
        return Ok(response);
    }
    
}