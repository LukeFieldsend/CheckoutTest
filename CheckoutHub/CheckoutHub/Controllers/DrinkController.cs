using CheckoutHub.Models;
using CheckoutHub.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutHub.Controllers
{
    /// <summary>
    /// Controls crud operations for office drink list
    /// </summary>
    [Route("api/[controller]")]
    public class DrinkController : Controller
    {

        private IDrinkService _drinkService;

        public DrinkController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        [HttpGet]
        public IEnumerable<DrinkStock> Get()
        {
            return _drinkService.GetDrinks();
        }

        [HttpGet("{drinkKey}")]
        public DrinkStock Get(string drinkKey)
        {
            return _drinkService.GetDrinks(drinkKey).FirstOrDefault();
        }

        [HttpPost]
        public DrinkStock Post([FromBody]DrinkStock drinkStockItem)
        {
         return _drinkService.AddDrinkStock(drinkStockItem);

        }
  
        [HttpPut]
        public DrinkStock Put([FromBody]DrinkStock drinkStockItem)
        {
           return _drinkService.UpdateDrinkStock(drinkStockItem);
        }

        // DELETE api/values/5
        [HttpDelete("{drinkKey}")]
        public bool Delete(string drinkKey)
        {
            if(_drinkService.DeleteDrinkStock(drinkKey))
            {
                return true;
            }
            return false;
        }
    }
}
