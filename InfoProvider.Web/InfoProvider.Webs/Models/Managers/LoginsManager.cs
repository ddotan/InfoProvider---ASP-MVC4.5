using InfoProvider.Webs.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace InfoProvider.Webs.Services
{
    public class LoginsManager : IDisposable
    {
        private static List<UserLoggedIn> m_UsersLoggedIn { get; set; }
        public List<UserLoggedIn> GetUsersLoggedIn() { return m_UsersLoggedIn; }
        private static DateTime m_FirstLoginDate;
        private Object obj = new object();

        public LoginsManager()
        {
            initilize();
            if (m_UsersLoggedIn == null)
            {
                m_UsersLoggedIn = new List<UserLoggedIn>();
            }
        }
        private void initilize()
        {
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory + "\\Logins\\";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

        }
        public void Add(UserLoggedIn i_Login)
        {
            if (m_UsersLoggedIn.Count == 0)
            {
                m_FirstLoginDate = DateTime.Now;
            }
            m_UsersLoggedIn.Add(i_Login);
        }


        public void Dispose()
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\Logins\\" + "Logins-" + string.Format("{0:yyyy-MM-dd}", m_FirstLoginDate) + "-" + string.Format("{0:yyyy-MM-dd}", DateTime.Now) + ".log";
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
            }
            writeToFile(filePath);

        }
        private void writeToFile(string i_FilePath)
        {

            lock (obj)
            {
                try
                {
                    using (StreamWriter Stream = File.AppendText(i_FilePath))
                    {
                        foreach (UserLoggedIn loggeduser in m_UsersLoggedIn)
                        {
                            Stream.WriteLine(loggeduser.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}