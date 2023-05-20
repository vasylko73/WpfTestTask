using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.DbRepository
{
    public sealed class DbRepositorySingelton
    {
        private static DbRepositorySingelton instance;
        private DbRepository dbRepository = null;

        // Restrict to create object of singleton class
        private DbRepositorySingelton()
        {
            if (dbRepository == null)
            {
                dbRepository = new DbRepository();
            }
        }

        // The static method to provide global access to the singleton object
        // Get singleton object of SingletonEmployeeService class
        public static DbRepositorySingelton GetInstance()
        {
            if (instance == null)
            {
                // Thread safe singleton
                lock (typeof(DbRepositorySingelton))
                {
                    instance = new DbRepositorySingelton();
                }
            }
            return instance;
        }

        public DbRepository GetDbRepository()
        {
            return dbRepository;
        }
    }
}
