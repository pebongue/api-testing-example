using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using RestSharp;

namespace PetStoreTests
{
    public class Inventory
    {
        public int Sold { get; set; }
        public int Pending { get; set; }
        public int Available { get; set; }
    }
    public class BaseTest
    {
        protected RestClient client;                                                    

        [SetUp]
        public void Initialise()
        {
            client = new RestClient("http://localhost/v2");                             
        }

        public Inventory GetInventory()
        {
            var request = new RestRequest("/store/inventory");
            return client.GetAsync<Inventory>((request)).GetAwaiter().GetResult()!;
        }
    }
}