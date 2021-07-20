using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using NeoGames.Models;

namespace NeoGames.Controllers
{
    public class PurchasesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            // in order to get all purchases don't send the bulk parameter.
            // in order to get purchases with bulks send the bulk
            var allUrlKeyValues = ControllerContext.Request.GetQueryNameValuePairs();
            int bulk = 5;
            string bulkVal = allUrlKeyValues.LastOrDefault(x => x.Key == "bulk").Value;
            Int32.TryParse(bulkVal, out bulk);
            MockData mockData = MockData.Instance;
            Purchase[] purchases = mockData.getPurchases(bulk);

            string[] result = new string[purchases.Length];
            int i =  0;
            foreach (Purchase purchase in purchases)
            {
                var json = new JavaScriptSerializer().Serialize(purchase);
                result[i] = json;
                i++;
            }
            /*List<string> result = new List<string>();
            foreach (Purchase purchase in purchases)
            {
                var json = new JavaScriptSerializer().Serialize(purchase);
                result.Add(json);
            }*

           /*List<Purchase> result = new List<Purchase>();
           foreach (Purchase purchase in purchases)
           {
               result.Add(purchase);
           }
            var json = new JavaScriptSerializer().Serialize(result);*/
            return result;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}