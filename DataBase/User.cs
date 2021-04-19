using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BostDB
{
    public class User
    {
        private string _user;
        private string _password;
        private Profile _profile;

        public User(string us, string pass, Profile prof)
        {
            us = _user;
            pass = _password;
            prof = _profile;
        }

        public string GetUser()
        {
            return _user;
        }

        public String Save()
        {
            return _user +"," + _password +"," +_profile;
        }
    }
}
