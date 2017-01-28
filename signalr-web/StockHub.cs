
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;
using System.Collections.Generic;
using Troschuetz.Random.Distributions.Continuous;
using Troschuetz.Random.Generators;
using System.Linq;

namespace signalr_web
{
    [HubName("StockHub")]
    public class StockHub : Hub
    {

        private static List<Stock> DataStock;

        public StockHub()
        {
            Troschuetz.Random.Generators.StandardGenerator rnd = new Troschuetz.Random.Generators.StandardGenerator();
            
            if (DataStock == null)
            {
                DataStock = new List<Stock>();
                DataStock.Add(new Stock() { Code = "BMRI", Price = rnd.Next(100) });
                DataStock.Add(new Stock() { Code = "BBCA", Price = rnd.Next(100) });
                DataStock.Add(new Stock() { Code = "BSMR", Price = rnd.Next(100) });

            }
        }


        [HubMethodName("GetStock")]
        public List<Stock> GetStock()
        { 
            Troschuetz.Random.Generators.StandardGenerator rnd = new Troschuetz.Random.Generators.StandardGenerator();
           
            foreach(var item in DataStock){
                item.Price = rnd.Next(1000);
            }
            return DataStock;
        }
    }

    public class Stock
    {
        public string Code { set; get; }
        public double Price { set; get; }
    }
}