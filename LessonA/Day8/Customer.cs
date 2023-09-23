using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Day8
{
     class Customer
    {
        private readonly double id;
        //public string Title;
        public string Title=String.Empty;
        public string FirstName {  get; set; }
        public string MiddleName { get; set; } 
        public string LastName { get; set; }
        public double CreditLimit { get; set; }
        public Customer(double v1) { id = v1; }
        public double GetID() { return id; }
        public override string ToString()
        {
            return $"Details: {id} {FirstName} {MiddleName} {LastName} {CreditLimit}";
        }






    }
}
