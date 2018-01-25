using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactApi.Models
{
    public class Supplier : IPerson
    {
        private string firstName, lastName;
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName= value; }

        private long id;
        public long Id { get => id; set => id = value; }

        public string Telephone { get; set; }
    }
}