using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetApp.Interfaces;

namespace TimesheetApp.DBAccess
{
    public class TaskDB : ITaskDB
    {
        public bool SaveToDB(int taskId, int hours, int minutes)
        {
            throw new NotImplementedException();
        }
    }
}
