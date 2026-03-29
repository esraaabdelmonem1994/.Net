using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment_01
{
    public struct Address
    {
        public string Street;
        public string City;
        public int ZipCode;

        public Address(string street, string city, int zipCode)
        {
            this.Street = street;
            this.City = city;
            this.ZipCode = zipCode;
        }
    }
}
