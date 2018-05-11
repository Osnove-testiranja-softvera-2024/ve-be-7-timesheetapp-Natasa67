using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetApp.DBAccess;
using TimesheetApp.Interfaces;
using TimesheetApp.Util;

namespace TimesheetApp
{
    public class TimeLogger
    {
        ITaskDB taskDB;
        IEmailSender emailSender;
        IErrorLogger errorLogger;
        IUserLogger userLogger;
        ITaskManager projectAndTaskManager;

        public TimeLogger()
        {
            taskDB = new TaskDB();
            emailSender = new EmailSender();
            errorLogger = new ErrorLogger();
            userLogger = new UserLogger();
            projectAndTaskManager = new TaskManager();
        }

        public void LogTime(int hours, int minutes)
        {
            try
            {
                //dobaviti podatke o trenutno logovanom korisniku (username, email)
                string userName = userLogger.GetLoggedUserName();
                string userEmail = userLogger.GetLoggedUserEmail(userName);

                //dobaviti podatke o projektu i aktivnosti (task) na projektu za koju se loguje vreme
                int taskId = projectAndTaskManager.GetTaskId(userName, userEmail);

                //logovati vreme - sacuvati podatke u bazi
                bool saved = taskDB.SaveToDB(taskId, hours, minutes);
                if (saved)
                {
                    //poslati mejl obavestenja o logovanom vremenu
                    emailSender.SendEmail(userEmail, 
                                         "Time logged successfully",
                                         hours + " hours and " + minutes + " minutes successfully logged to task with ID=" + taskId);
                }
                else
                {
                    throw new Exception("Failed to save data to database");
                }                                               
            }
            catch (Exception ex) //obrada gresaka
            {
                errorLogger.LogError(ex);
                throw ex;
            }
        }
    }
}
