using System;

namespace ContactApi.Models
{
    public class Customer : IPerson
    {
        private string firstName, lastName;
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }

        private long id;
        public long Id { get => id; set => id = value; }

        public DateTime? BirthDay { get; set; }
        public string Email { get; set; }
    }
}