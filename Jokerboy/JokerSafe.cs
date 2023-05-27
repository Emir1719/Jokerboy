using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace Jokerboy
{
    class JokerSafe
    {
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader data;
        private long safe;

        public JokerSafe()
        {
            this.downloadJokerSafe();
        }

        //public void JokerSafeCondition(string process, long tempSafe)
        //{
        //    //Jokerboy kasasının durumunu görüntüler ve kasayı günceller.
        //    if (connect.State == ConnectionState.Closed)
        //    {
        //        connect.Open();
        //    }
        //    cmd.Connection = connect;
        //    switch (process)
        //    {
        //        case "Yükle":
        //            //Veritabanından güncel kasa miktarını değişkene atar.
        //            cmd.CommandText = "Select * From JokerSafe where SafeID=1";
        //            data = cmd.ExecuteReader();
        //            data.Read();
        //            this.safe = Convert.ToInt64(data["Amount"]);
        //            data.Close();
        //            break;
        //        case "Güncelle":
        //            //Kullanıcı kazandıktan veya kaybettikten sonraki kasa miktarını veritabanına aktarır.
        //            cmd.CommandText = "Update JokerSafe set Amount=o1 where SafeID=1";
        //            cmd.Parameters.Clear();
        //            cmd.Parameters.AddWithValue("@o1", tempSafe);
        //            cmd.ExecuteNonQuery();
        //            break;
        //    }
        //    connect.Close();
        //}

        public void downloadJokerSafe()
        {
            //Veritabanından programa kasa değişkenine güncel miktarı yükler:
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }
            cmd.Connection = connect;
            cmd.CommandText = "Select * From JokerSafe where SafeID=1";
            data = cmd.ExecuteReader();
            data.Read();
            this.safe = Convert.ToInt64(data["Amount"]);
            data.Close();
            connect.Close();
        }

        public void uploadJokerSafe(long tempSafe)
        {
            //Güncel kasa miktarını veritabanına aktarır:
            this.safe = tempSafe;//Kısa download işlevi görür.
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }
            cmd.Connection = connect;
            cmd.CommandText = "Update JokerSafe set Amount=o1 where SafeID=1";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@o1", tempSafe);
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        public long getSafe()
        {
            return this.safe;
        }
    }
}