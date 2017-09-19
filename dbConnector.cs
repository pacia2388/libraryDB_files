using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LibrarySystemDemo.DAL
{
    class dbConnector
    {
        private SqlConnection SqlCon = null;

        public SqlConnection GetConnection
        {
            get { return SqlCon; }
        }

        public dbConnector()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LibraryDbContext"].ConnectionString;
            SqlCon = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (SqlCon.State == ConnectionState.Closed)
            {
                SqlCon.Open();
            }
        }

        public void CloseConnection()
        {
            if (SqlCon.State == ConnectionState.Open)
            {
                SqlCon.Close();
            }
        }


    }
}
