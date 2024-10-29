using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrackApp.Models
{
    public abstract class Person
    {
        // Public way to store all credentials. 
        public string? Username { get; set; }
        public string? Password { get; set; }


        // Method for signing in. If true it returns successfully.
        public abstract bool SignIn(string username, string password);
    }
}

