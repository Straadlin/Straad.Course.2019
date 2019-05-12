namespace Excercise_001_Net_Core_WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserViewModel
    {
        public string FirstName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public DateTime? Date
        {
            get;
            set;
        }
    }
}