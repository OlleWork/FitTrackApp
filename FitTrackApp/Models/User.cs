﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTrackApp.Models
{
    public class User : Person
    {
        // This represents the users country and is also public property
        public string? Country { get; set; }
        public string? SecurityQuestion { get; set; } // Vice versa but with a security question for password recov.
        public string? SecurityAnswer { get; set; } // Vice versa but with a security answer for password recov.

        public override bool SignIn(string username, string password) // Verifies if the username and password are correct. 
        {
            return this.Username == username && this.Password == password; // If credentials match it will return true otherwise false. 
        }

        public bool PasswordReset(string securityAnswer, string newPassword) // Resets the users password if the security answer is correct.
                                                                             // Returns true if the security answer is correct and the password was reset.
        {

            if (securityAnswer == SecurityAnswer) // This double checks if the security answer matches the answer
            {
                Password = newPassword;
                return true; // If this runs it is correct and the user can change password 
            }
            return false; // Opposite of comment above.
        }
    }
}
