using Checkout.ApiServices.Office.RequestModels;
using Checkout.ApiServices.Office.ResponseModels;
using Checkout.ApiServices.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.ApiServices.Office
{
    public interface IOfficeService
    {
        HttpResponse<DrinkStock> SubmitDrink(DrinkRequest requestModel);

        HttpResponse<DrinkStock> GetDrink(string DrinkKey);

        HttpResponse<DrinkStock> UpdateDrink(DrinkRequest requestModel);

        HttpResponse<bool> RemoveDrink(string  DrinkKey);

        HttpResponse<IEnumerable<DrinkStock>> GetDrinkList();
    }
}
