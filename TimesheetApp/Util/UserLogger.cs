using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetApp.Interfaces;

namespace TimesheetApp.Util
{
    public class UserLogger : IUserLogger
    {
        public string GetLoggedUserEmail(string userName)
        {
            //vraca email korisnika na osnovu njegovog username-a
            throw new NotImplementedException();
        }

        public string GetLoggedUserName()
        {
            //vraca username trenutno logovanog korisnika
            throw new NotImplementedException();
        }
    }
}
