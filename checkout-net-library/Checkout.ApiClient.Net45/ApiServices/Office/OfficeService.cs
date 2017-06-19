using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkout.ApiServices.Office.RequestModels;
using Checkout.ApiServices.Office.ResponseModels;
using Checkout.ApiServices.SharedModels;
using System.Net;

namespace Checkout.ApiServices.Office
{
    public class OfficeService : IOfficeService
    {
        public HttpResponse<DrinkStock> GetDrink(string DrinkKey)
        {
            return new ApiHttpClient().GetRequest<DrinkStock>(ApiUrls.Drink+"/"+ DrinkKey, AppSettings.SecretKey);
        }

        public HttpResponse<IEnumerable<DrinkStock>> GetDrinkList()
        {
            return new ApiHttpClient().GetRequest<IEnumerable<DrinkStock>>(ApiUrls.Drink, AppSettings.SecretKey);
        }

        public HttpResponse<bool> RemoveDrink(string DrinkKey)
        {
            return new ApiHttpClient().DeleteRequest<bool>(ApiUrls.Drink + "/" + DrinkKey, AppSettings.SecretKey);
        }

        public HttpResponse<DrinkStock> SubmitDrink(DrinkRequest requestModel)
        {
            return new ApiHttpClient().PostRequest<DrinkStock>(ApiUrls.Drink, AppSettings.SecretKey, requestModel);
        }

        public HttpResponse<DrinkStock> UpdateDrink(DrinkRequest requestModel)
        {
            return new ApiHttpClient().PutRequest<DrinkStock>(ApiUrls.Drink, AppSettings.SecretKey, requestModel);
        }
    }
}
