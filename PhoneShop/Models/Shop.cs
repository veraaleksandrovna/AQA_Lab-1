using PhoneShop.Models;

namespace PhoneShop.Models;

public class Shop
{
    public int Id { get; }
    
    public string Name { get; }
    
    public string Description { get; }
    
    public Phone[] Phones { get; }
}
