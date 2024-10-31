using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalHub.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OldPrice { get; set; }
        public string Price { get; set; }
        public string ImageUrl { get; set; }
        public double Rating { get; set; }
    }
}