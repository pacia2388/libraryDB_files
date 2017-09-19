using LibrarySystemDemo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibrarySystemDemo.DAL
{
    class dalBookType
    {
        public static List<BookType> GetBookTypes()
        {
            dbConnector connector = new dbConnector();

            try
            {
                List<BookType> bookTypes = new List<BookType>();

                SqlCommand cmd = new SqlCommand("spGetBookType", connector.GetConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                connector.OpenConnection();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BookType bookType = new BookType();
                    bookType.BookTypeID = Convert.ToInt32(reader["BookTypeID"]);
                    bookType.BookTypeName = reader["BookTypeName"].ToString();
                    bookType.Memo = reader["Memo"].ToString();
                    bookTypes.Add(bookType);
                }
                return bookTypes;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                connector.CloseConnection();
            }
        }

        public static int AddBookType(BookType bookType)
        {
            dbConnector connector = new dbConnector();
            int result = 0;

            try
            {
                SqlCommand cmd = new SqlCommand("spAddBookType", connector.GetConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookTypeID", bookType.BookTypeID);
                cmd.Parameters.AddWithValue("@BookTypeName", bookType.BookTypeName);
                cmd.Parameters.AddWithValue("@Memo", bookType.Memo);

                connector.OpenConnection();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error in Inserting data");
            }
            finally
            {
                connector.CloseConnection();
            }
            return result;
        }

        public static int SaveBookType(BookType bookType)
        {
            dbConnector connector = new dbConnector();
            int result = 0;

            try
            {
                SqlCommand cmd = new SqlCommand("spSaveBookType", connector.GetConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookTypeID", bookType.BookTypeID);
                cmd.Parameters.AddWithValue("@BookTypeName", bookType.BookTypeName);
                cmd.Parameters.AddWithValue("Memo", bookType.Memo);

                connector.OpenConnection();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                connector.CloseConnection();
            }
            return result;
        }

        public static int DeleteBookType(int id)
        {
            var connector = new dbConnector();
            int result = 0;

            try
            {
                SqlCommand cmd = new SqlCommand("spDeleteBookType", connector.GetConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookTypeID", id);

                connector.OpenConnection();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                connector.CloseConnection();
            }
            return result;
        }
    }
}
