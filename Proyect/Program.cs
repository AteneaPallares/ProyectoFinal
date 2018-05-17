using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Data;
using Newtonsoft.Json;
namespace Proyect
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
namespace WebApiClient
{
    public class Program
    {
        public class Attributes
{
    public string color { get; set; }
    public string gender { get; set; }
    public string size { get; set; }
    public string paperWoodIndicator { get; set; }
    public string mainimageurl { get; set; }
    public string compositeWood { get; set; }
    public string isSortable { get; set; }
    public string ironBankCategory { get; set; }
    public string replenishmentEndDate { get; set; }
    public string actualColor { get; set; }
    public string clothingSize { get; set; }
    public string caResidentsPropWarningRequired { get; set; }
    public string canonicalUrl { get; set; }
    public string replenishmentStartDate { get; set; }
    public string isOrderable { get; set; }
    public string releaseDate { get; set; }
    public string pesticideInd { get; set; }
    public string productUrlText { get; set; }
    public string velocityClassification { get; set; }
    public string finerCateg { get; set; }
    public string hasWarranty { get; set; }
    public string ppuQty { get; set; }
    public string isPvtLabelUnbranded { get; set; }
    public string replenType { get; set; }
    public string isReplenishable { get; set; }
    public string format { get; set; }
    public string chokingHazardWarning { get; set; }
    public string wklyFcstWeeks { get; set; }
    public string requiresTextileActLabeling { get; set; }
    public string isImport { get; set; }
    public string fuelRestriction { get; set; }
    public string prodClassType { get; set; }
    public string batteryType { get; set; }
    public string features { get; set; }
}

public class BestMarketplacePrice
{
    public double price { get; set; }
    public string sellerInfo { get; set; }
    public double standardShipRate { get; set; }
    public double twoThreeDayShippingRate { get; set; }
    public bool availableOnline { get; set; }
    public bool clearance { get; set; }
}

public class Item
{
    public int itemId { get; set; }
    public int parentItemId { get; set; }
    public string name { get; set; }
    public double msrp { get; set; }
    public double salePrice { get; set; }
    public string upc { get; set; }
    public string categoryPath { get; set; }
    public string shortDescription { get; set; }
    public string longDescription { get; set; }
    public string brandName { get; set; }
    public string thumbnailImage { get; set; }
    public string mediumImage { get; set; }
    public string largeImage { get; set; }
    public string productTrackingUrl { get; set; }
    public double standardShipRate { get; set; }
    public double twoThreeDayShippingRate { get; set; }
    public string size { get; set; }
    public string color { get; set; }
    public bool marketplace { get; set; }
    public string modelNumber { get; set; }
    public string sellerInfo { get; set; }
    public string productUrl { get; set; }
    public List<int> variants { get; set; }
    public string categoryNode { get; set; }
    public bool bundle { get; set; }
    public bool clearance { get; set; }
    public bool preOrder { get; set; }
    public string stock { get; set; }
    public Attributes attributes { get; set; }
    public string gender { get; set; }
    public string addToCartUrl { get; set; }
    public string affiliateAddToCartUrl { get; set; }
    public bool freeShippingOver50Dollars { get; set; }
    public bool availableOnline { get; set; }
    public bool? ninetySevenCentShipping { get; set; }
    public bool? shipToStore { get; set; }
    public bool? freeShipToStore { get; set; }
    public string customerRating { get; set; }
    public int? numReviews { get; set; }
    public string customerRatingImage { get; set; }
    public double? overnightShippingRate { get; set; }
    public BestMarketplacePrice bestMarketplacePrice { get; set; }
    public bool? specialBuy { get; set; }
    public int? maxItemsInOrder { get; set; }
}

public class RootObject
{
    public string category { get; set; }
    public string format { get; set; }
    public string nextPage { get; set; }
    public List<Item> items { get; set; }
}
   
        private static readonly HttpClient client = new HttpClient();


public static async Task<WebApiClient.Program.RootObject> ProcessRepositories(string opcion)
{
    client.DefaultRequestHeaders.Accept.Clear();
    Uri hola=new Uri("http://api.walmartlabs.com/v1/paginated/items?category="+opcion+"&apiKey=mfp6st9xcakz2ya283ga5m5t&lsPublisherId={Your%20LinkShare%20Publisher%20Id}&format=json");
    var stringTask = client.GetStringAsync(hola);
    string msg="";
    HttpResponseMessage response ;
    try
    {
        response= await client.GetAsync(hola);
        msg=await stringTask;
    }
    catch(Exception )
    {
        msg = "{}";
    }

RootObject account = JsonConvert.DeserializeObject<RootObject>(msg);
RootObject ok=account;
List<Item> producto=new List<Item>();
    return ok;

}

    }
}
