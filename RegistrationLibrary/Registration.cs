using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegistrationLibrary
{
    public class Registration
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        //delegate point
        public void SetFirstName(string firstName)
        {
            this.FirstName = firstName;
        }
        //delegate point
        public void SetLastName(string lastName)
        {
            this.LastName = lastName;
        }
        //delegate point
        public void SetEmail(string Email)
        {
            this.Email = Email;
        }
        //delegate point
        public void SetAddress(string Address)
        {
            this.Address = Address;
        }
        //delegate point
        public void SetCity(string firstCity)
        {
            this.City = City;
        }
        //delegate point
        public void SetPostCode(string PostCode)
        {
            this.PostCode = PostCode;
        }
        //delegate point
        public void SetCountry(string Country)
        {
            this.Country = Country;
        }
        //delegate point
        public void SetPhone(string Phone)
        {
            this.Phone = Phone;
        }
        //Constructor
        public Registration(string firstName, string lastName, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }

        //constructor
        public Registration()
        {

        }
        //method to string
        public override string ToString()
        {
            return $"Your registration Information:\n First name : {this.FirstName}\n" +
                $"Last name: {this.LastName}\n Email: {this.Email}\n Address: {this.Address}\n" +
                $"City: {this.City}\n Post Code: {this.PostCode} \n Country: {this.Country}\n" +
                $"Phone: {this.Phone}.";
        }
    }
}
