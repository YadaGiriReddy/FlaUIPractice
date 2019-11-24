using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankSystem
{
    class Client
    {
        protected readonly string FirstName, LastName, Age ,Email, Country, VisaCard, Password,PhonNumber;
        protected int Amount = 0;
        public Client(string Email,string Password, string FirstName, string LastName, string Country,
                      string Age,string VisaCard,string PhonNumber,bool Vip)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.VisaCard = VisaCard;
            this.Email = Email;
            this.Country = Country;
            this.Age = Age;
            this.Password = Password;
            this.PhonNumber = PhonNumber;
            if (Vip) Amount = 10;
        }
        public Client(string Email,string Password,string FirstName, string LastName, string Country,
                      string Age, string VisaCard, string PhonNumber,int Amount)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.VisaCard = VisaCard;
            this.Email = Email;
            this.Country = Country;
            this.Age = Age;
            this.Password = Password;
            this.PhonNumber = PhonNumber;
            this.Amount = Amount;
        }
        public string FName
        {
            get { return FirstName; }
        }
        public string LName
        {
            get { return LastName; }
        }
        public string EM
        {
            get { return Email; }
        }
        public string Ctry
        {
            get { return Country; }
        }
        public string Ag
        {
            get { return Age; }
        }
        public string Pass
        {
            get { return Password; }
        }
        public string Visa
        {
            get { return VisaCard; }
        }
        public string Phone
        {
            get { return PhonNumber; }
        }
        public int Am
        {
            set { Amount = value; }
            get { return Amount; }
        }
    }
}
