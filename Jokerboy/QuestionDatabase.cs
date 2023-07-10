using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data;

namespace Jokerboy
{
    internal class QuestionDatabase
    {
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader data;

        public int addQuestionAsUsed(string table, string userID, string QuesID)
        {
            string querry = "Insert into " + table + " values (@p1, @p2)";
            if (connect.State == ConnectionState.Closed)
                connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = querry;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@p1", userID);
            cmd.Parameters.AddWithValue("@p2", QuesID);
            int result = cmd.ExecuteNonQuery();
            connect.Close();
            return result;
        }
    }
}
