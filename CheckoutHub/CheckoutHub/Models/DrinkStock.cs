using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CheckoutHub.Models
{
    /// <summary>
    /// represents a stocked item of drink
    /// </summary>
    public class DrinkStock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
