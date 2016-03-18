using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EBoxClient.Entity
{
    [Serializable]
    public class Provice
    {
        public Provice(string no, string name)
        {
            No = no;
            Name = name;
        }
        public string No { get; set; }
        public string Name { get; set; }
        public List<City> CityList = new List<City>();
    }

    [Serializable]
    public class City
    {
        public City(string no, string name)
        {
            No = no;
            Name = name;
        }
        public string No { get; set; }
        public string Name { get; set; }
        public Provice Provice { get; set; }
        public List<County> CountyList = new List<County>();
    }

    [Serializable]
    public class County
    {
        public County(string no, string name)
        {
            No = no;
            Name = name;
        }
        public string No { get; set; }
        public City City { get; set; }
        public string Name { get; set; }
    }
}
