﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetApp.Interfaces;

namespace TimesheetApp.Util
{
    public class TaskManager : ITaskManager
    {
        public int GetProjectAndTaskIds(string loggedUserName, string loggedUserEmail)
        {
            //vraca ID aktivnosti za koju se loguje vreme na osnovu ulaznih paramentara
            throw new NotImplementedException();
        }
    }
}
