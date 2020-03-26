using System;
using System.Threading.Tasks;
using Simple.OData.Client;
using System.Net;

namespace TestConsumeAPIBC
{
    class Program
    {
        static async Task Main(string[] args)
        {
            NetworkCredential myCred = new NetworkCredential(
                "admin","e4+1IDevw8mIVlwi89xNENUFnnVFAvvNsqJQ14hSASo=","");
            
            CredentialCache myCache = new CredentialCache();
            
            myCache.Add(new Uri(@"https://api.businesscentral.dynamics.com"), "Basic", myCred);
            
            var odataSetting = new ODataClientSettings();
            odataSetting.Credentials = myCache;
            odataSetting.BaseUri = new Uri(@"https://api.businesscentral.dynamics.com/v2.0/9fa7c13f-5edb-418a-858d-e4384253eb21/Sandbox/ODataV4/");
            odataSetting.IgnoreResourceNotFoundException = true;
            odataSetting.OnTrace = (x, y) => Console.WriteLine(string.Format(x, y));
            var client = new ODataClient(odataSetting);
            
            var packages = await client
                .FindEntriesAsync("Company('CRONUS AU')/MasterItem");
            
            Console.WriteLine("No - Description - BaseUnitofMeasure");
            foreach (var package in packages)
            {
                Console.WriteLine($"{package["No"]} - {package["Description"]} - {package["BaseUnitofMeasure"]}" );
            }
        }
    }
}
