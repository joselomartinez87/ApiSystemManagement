using System;
using System.Configuration;
using System.Data.Linq;

namespace SystemManagement.DataAccess.Helper
{
    public static class DataContextHelper
    {

        public static T GetDataContext<T>() where T : DataContext
        {
            T result;
            string connectionString = string.Empty;
            connectionString = ConfigurationManager.ConnectionStrings["systemManagementAPI"].ToString();

            result = (T)Activator.CreateInstance(typeof(T), connectionString);

            return result;
        }

    }
}
