using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerryFinal
{
    class SecurityClearance
    {
        private string firstName;
        private string lastName;

        private string password;
        private int securityLevel;

        public string Password
        {
            set
            {
                password = value;
            }
        }

        public int SecurityLevel
        {
            get
            {
                return securityLevel;
            }

            set
            {
                securityLevel = value;
            }
        }

        public SecurityClearance( string first, string last, string pass, int security )
        {
            firstName = first;
            lastName = last;
            Password = pass;

            if ( security <= 4 || security >= 0 )
            {
                SecurityLevel = security;
            }
        }

        public bool CheckPassword( string passWord )
        {
            if ( passWord == password )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"\nSecurity clearance for {firstName} {lastName} is Security Level {securityLevel} ";
        }
    }
}
