using System;
using System.Collections.Generic;
using System.Linq;
using CheckoutHub.Data;
using CheckoutHub.Models;
using Microsoft.Extensions.Logging;

namespace CheckoutHub.Services
{
    /// <summary>
    /// Service for abstracting crud operations of office drinks ordering
    /// </summary>
    public class DrinkService : IDrinkService
    {
        private CheckoutContext _context;
        private ILogger<DrinkService> _logger;

        public DrinkService(CheckoutContext context, ILogger<DrinkService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public bool DeleteDrinkStock(string drinkKey)
        {
            var drinkToDelete = _context.DrinkStock.FirstOrDefault(t => t.Name == drinkKey);

            if (drinkToDelete != null)
            {
                try
                {
                    _context.Entry(drinkToDelete).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    _logger.LogError("Failed to delete drink from office shopping list", e);
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        public IEnumerable<DrinkStock> GetDrinks(string drinkKey = null)
        {
            try
            {
                IQueryable<DrinkStock> drinks;
                if (drinkKey != null)
                {
                    drinks = _context.DrinkStock.Where(t => t.Name == drinkKey);
                }
                else
                {
                    drinks = _context.DrinkStock;

                }

                return drinks;
            }
            catch (Exception e)
            {
                _logger.LogError("Failed to retrieve drinks from office shopping list", e);
                return null;
            }
        }

        public DrinkStock UpdateDrinkStock(DrinkStock drinkStock)
        {
            try
            {
                var existingDrink = _context.DrinkStock.FirstOrDefault(t => t.Name == drinkStock.Name);
                if (existingDrink != null)
                {
                    existingDrink.Quantity = drinkStock.Quantity;
                    _context.SaveChanges();
                    return drinkStock;
                }
                return null;
                
            }
            catch (Exception e)
            {
                _logger.LogError("Failed to update drink from office shopping list", e);
                return null;
            }
        }

        public DrinkStock AddDrinkStock(DrinkStock drinkStock)
        {
            try
            {
                var existingDrink = _context.DrinkStock.FirstOrDefault(t => t.Name == drinkStock.Name);
                if (existingDrink != null)
                {
                    return drinkStock;
                }
                else
                {
                    _context.DrinkStock.Add(drinkStock);
                    _context.SaveChanges();
                    return drinkStock;
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Failed to add drink from office shopping list", e);
                return null;
            }

        }
    }
}
