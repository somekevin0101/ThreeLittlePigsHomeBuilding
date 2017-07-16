using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThreeLittlePigs.Web.Models
{
    public class House
    {
        public string HouseCode { get; set; }

        public string HouseName { get; set; }

        public string HouseDescription { get; set; }

        public int MinPrice { get; set; }

        public int MaxPrice { get; set; }

        public int MinSquareFeet { get; set; }

        public int MaxSquareFeet { get; set; }

        public bool WolfProof { get; set; }
    }
}