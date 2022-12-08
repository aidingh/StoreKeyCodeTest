using StoreKeyCodeTestAidin.Services;
using Microsoft.AspNetCore.Mvc;
using StoreKeyCodeTestAidin.Models.Cart;

namespace StoreKeyCodeTestAidin.Controllers;
/// <summary>
/// Class <c>ComboController</c>
/// Will receive a cart object <see cref="CustomerCart"/> and will return a response depending if the cart has combo-campaigns.
/// </summary>
[ApiController]
[Route("[controller]")]
public class ComboController : ControllerBase
{
    private readonly ComboCampaignsService _comboCampaignsService;
    
    public ComboController(ComboCampaignsService comboCampaignsService)
    {
        _comboCampaignsService = comboCampaignsService;
    }
    
    /// <summary>
    /// Method <c>ComboCheckout</c>
    /// <param name="customerCart"> <see cref="CustomerCart"/> Request body sent by the client </param>
    /// <returns> <see cref="IActionResult"/> Returns a response object to the client. </returns>
    /// <exception cref="T:System.InvalidOperationException"> If the DeserializeObject fails. </exception>.
    /// </summary>
    [HttpPost(Name = "Combo-Checkout")]
    public IActionResult ComboCheckout([FromBody] CustomerCart? customerCart)
    {
        if (customerCart == null)
        {
            return BadRequest();
        }
        
        var response = _comboCampaignsService.ComboCampaignsValidator(customerCart);
        
        if (response == null)
        {
            return new BadRequestResult();
        }
        return Ok(response);
    }
}