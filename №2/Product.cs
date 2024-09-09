using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp2
{
    internal abstract class Product
    {
        public string Name { get; set; }
        public double Price {  get; set; }
        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }
        internal abstract string GetInformation();
    }
    internal class Toy : Product
    {
        public string Censor { get; set; }
        public Toy(string name, double price, string cen) :base(name,price) 
        {
            this.Censor = cen;
        }
        internal override string GetInformation()
        {
            return $"Toy - {Name} | Price - {Price* 0.8} | Censor - +{Censor}";
        }
    }
    internal class Meat : Product
    {
        public string Date { get; set; }
        public Meat(string name, double price, string date) : base(name, price)
        {
            this.Date = date;
        }
        internal override string GetInformation()
        {
            return $"Meat - {Name} | Price - {Price* 0.95} | Date - {Date}";
        }
    }
    internal class Drinks : Product
    {
        public string Type { get; set; }
        public Drinks(string name, double price,string type) : base(name, price)
        {
            this.Type = type;
        }
        internal override string GetInformation()
        {
            return $"Drink - {Name} | Price - {Price* 0.7} | Type - {Type}";
        }
    }
    internal class Snacks : Product
    {
        public string Country { get; set; }
        public Snacks(string name, double price, string country) : base(name, price)
        {
            this.Country = country;
        }
        internal override string GetInformation()
        {
            return $"Snack - {Name} | Price - {Price * 0.99} | Country - {Country}";
        }
    }
}
