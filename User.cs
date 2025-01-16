using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_part_4_Omer_and_Roaa
{
    public class User
    {
        protected string Username;
        protected string Password;
        protected string Country;
        protected string City;
        protected string Street;
        protected int House;

        public User(string username, string password, string country, string city, string street, int house)
        {
            Username = username;
            Password = password;
            Country = country;
            City = city;
            Street = street;
            House = house;
        }

        public string GetUsername() { return Username; }
        public string GetPassword() { return Password; }
        public string GetCountry() { return Country; }
        public string GetCity() { return City; }
        public string GetStreet() { return Street; }
        public int GetHouse() { return House; }
        public bool SetPassword(string password) { Password = password; return true; }
        public bool SetCountry(string country) { Country = country; return true; }
        public bool SetCity(string city) { City = city; return true; }
        public bool SetStreet(string street) { Street = street; return true; }
        public bool SetHouse(int house) { House = house; return true; }
        public string GetAddress()
        {
            return $"{Country}, {City}, {Street}, {House}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is User))
            {
                return false;
            }
            User u = (User)obj;
            return Username == u.GetUsername();
        }

        public override int GetHashCode()
        {
            return Username.GetHashCode();
        }
    }
}
