namespace StoreKeyCodeTestAidin.Models.Cart;
/// <summary>
/// Class <c>CustomerCart</c>
/// Is a class that has a list of Objects of type CartAttributes <see cref="CartAttributes"/>
/// Controller functions will deserialize this this object.
/// </summary>
public class CustomerCart
{
    public List<CartAttributes>? Cart { get; set; }
}