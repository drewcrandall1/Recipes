using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes
{
    public enum Units
    {
        OUNCES,
        GRAMS,
        COUNT,
        POUNDS,
        TEASPOON,
        TABLESPOON,
        CUP,
        LITER,
        QUART,
        FLUID_OUNCES,
    }
    public class FoodInventoryDataObject
    {
        
        public string Name { get; set; }
        public int Quantity { get; set; }
        public Units CurrentUnit { get; set; }
        public double Price { get; set; }
        public List<string> Substitutes { get; set; }
        public DateTime ExpirationDate { get; set; }
        

        public FoodInventoryDataObject(string _name, int _quantity, Units _quantityUnits, double _price,List<string> _substitutes,DateTime _expirationDate)
        {
            Name = _name;
            Quantity = _quantity;
            CurrentUnit = _quantityUnits;
            Price = _price;
            Substitutes = _substitutes;
            ExpirationDate = _expirationDate;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
