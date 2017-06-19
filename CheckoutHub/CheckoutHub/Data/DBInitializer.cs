using System;
using System.Linq;
using CheckoutHub.Models;
using CheckoutHub.Services;
using Microsoft.Extensions.Logging;

namespace CheckoutHub.Data
{
    /// <summary>
    /// Initializes the instance of localdb
    /// </summary>
    public static class DbInitializer
    {
        private static ILogger _logger;

        public static void Initialize(CheckoutContext context, ILogger logger)
        {
            context.Database.EnsureCreated();
            _logger = logger;

        }  
    }
}
