using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneShop
{
    public class Shop
    {
        public int Id { get; set; }
       
        public string Name { get; set; }

        public string Description { get; set; }
        
        public Phone[] Phones { get; set; }
    }
}
