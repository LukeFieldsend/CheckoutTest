using Checkout.ApiServices.Office.RequestModels;
using System.Linq;
using System.Net;
using FluentAssertions;
using NUnit.Framework;
using Tests.Utils;
using Checkout.ApiServices.Office.ResponseModels;
using Checkout.ApiServices.SharedModels;
using System;

namespace Tests.OfficeService
{
    [TestFixture(Category = "OfficeApi")]
    public class OfficeServiceTests : BaseServiceTests
    {

        [SetUp]
        public void Init()
        {
            CleanUp("Milk");
            CleanUp("AppleJuice");
            CleanUp("Guinness");
            CleanUp("SanPelogrinoLemon");
            CleanUp("SanPelogrinoOrange");
            CleanUp("OrangeJuice");
            CleanUp("Mezcal");
        }

        private void CleanUp(string name)
        {
            var response = CheckoutClient.OfficeService.RemoveDrink(name);
            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void SubmitDrink()
        {
            var response = AddDrinkAssertion("Milk", 6);
            response.Model.Name.Should().Be("Milk");
            response.Model.Quantity.Should().Be(6);
        }

        [Test]
        public void DeleteDrink()
        {
            AddDrinkAssertion("AppleJuice", 4);
            var response = CheckoutClient.OfficeService.RemoveDrink("AppleJuice");

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Should().Be(true);


            var getResponse = CheckoutClient.OfficeService.GetDrink("AppleJuice");
            getResponse.Should().Be(null);
        }

        [Test]
        public void GetDrink()
        {
             var drink  = AddDrinkAssertion("Guinness", 30);

            var getResponse = CheckoutClient.OfficeService.GetDrink(drink.Model.Name);

            getResponse.Should().NotBeNull();
            getResponse.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.Model.Name.Should().Be(drink.Model.Name);
            getResponse.Model.Quantity.Should().Be(drink.Model.Quantity);
        }

        [Test]
        public void GetDrinks()
        {
            var drink = AddDrinkAssertion("SanPelogrinoLemon",12);

            var drink2 = AddDrinkAssertion("SanPelogrinoOrange", 6);
         

            var list = CheckoutClient.OfficeService.GetDrinkList();

            list.Should().NotBeNull();
            list.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            list.Model.Count().Should().BeGreaterThan(0);
            list.Model.First(t => t.Name == "SanPelogrinoLemon").Quantity.Should().Be(12);
        }

        private HttpResponse<DrinkStock> AddDrinkAssertion(string name, int quantity)
        {
            var drink = new DrinkRequest() { Name = name, Quantity = quantity };
            var response = CheckoutClient.OfficeService.SubmitDrink(drink);
            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            return response;
        }
        [Test]
        public void SecondAddDoesntUpdate()
        {
            AddDrinkAssertion("OrangeJuice", 2);
            AddDrinkAssertion("OrangeJuice", 9);

            var getResponse = CheckoutClient.OfficeService.GetDrink("OrangeJuice");

            getResponse.Model.Quantity.Should().Be(2);

        }

        [Test]
        public void UpdateDrink()
        {
            AddDrinkAssertion("Mezcal", 2);

            var response = CheckoutClient.OfficeService.UpdateDrink(new DrinkRequest() { Name="Mezcal",Quantity=22});

            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);

            var getResponse = CheckoutClient.OfficeService.GetDrink("Mezcal");

            getResponse.Model.Quantity.Should().Be(22);
        }
    }
}
