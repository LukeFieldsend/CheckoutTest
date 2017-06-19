using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckoutHub.Models;

namespace CheckoutHub.Services
{
    public interface IDrinkService
    {
        IEnumerable<DrinkStock> GetDrinks(string drinkKey = null);
        DrinkStock AddDrinkStock(DrinkStock drinkStock);
        DrinkStock UpdateDrinkStock(DrinkStock drinkStock);
        bool DeleteDrinkStock(string drinkKey);
    }
}
