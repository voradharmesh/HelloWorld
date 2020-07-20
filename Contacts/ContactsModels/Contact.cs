using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsModels
{

    public enum ContactAddress
    {
        home=0,
        work=1,
        other=2,
    }
    public class Contact
    {
        public int ContactId { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

    }

    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
