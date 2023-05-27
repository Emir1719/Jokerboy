using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace Jokerboy
{
    class User
    {
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader data;
        private string name, gmail, password, gender, authority, ID;
        private double balance;
        /*
            name, ID, gmail değişkenleri eşsizdir.
        */

        public User(string userID)
        {
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }
            cmd.Connection = connect;
            cmd.CommandText = "Select * From Account where ID=@p1";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@p1", userID);
            data = cmd.ExecuteReader();
            if (data.HasRows)
            {
                //Kullanıcı veritabanında varsa kendi bilgileri yüklenir:
                data.Read();
                this.ID = data["ID"].ToString();
                this.name = data["Name"].ToString();
                this.gmail = data["Gmail"].ToString();
                this.password = data["Password"].ToString();
                this.gender = data["Gender"].ToString();
                this.authority = data["Authority"].ToString();
                this.balance = Convert.ToDouble(data["Balance"]);
                data.Close();
            }
            connect.Close();
        }

        public int isWin(bool condition, long earnings)
        {
            //Kullanıcının oyunu kazanıp ya da kaybetmmesi durumunda bakiye günceller.
            if (condition == true)
            {
                //Kullanıcı oyunu kazandıysa:
                JokerSafe safe = new JokerSafe();
                if (safe.getSafe() < earnings)
                {
                    //Kasadaki para miktarı kullanıcıya verilecek miktarı karşılamıyorsa:
                    return (-1);
                }
                long tempSafe = safe.getSafe() - earnings;
                safe.uploadJokerSafe(tempSafe);
                this.balance += earnings;
                this.updateBalance();
                return 1;
            }
            else
            {
                //Kullanıcı oyunu kaybettiyse:
                return 0;
            }
        }

        public void updateBalance()
        {
            //Bakiye miktarını veritabanına aktarır:
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }
            cmd.Connection = connect;
            cmd.CommandText = "Update Account set Balance=@p1 where Name=@p2";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@p1", this.balance);
            cmd.Parameters.AddWithValue("@p2", this.name);
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        public double getBalance()
        {
            return this.balance;
        }

        public string getName()
        {
            return this.name;
        }

        public string getGender()
        {
            return this.gender;
        }

        public string getPassword()
        {
            return this.password;
        }

        public string getGmail()
        {
            return this.gmail;
        }

        public string getAuthority()
        {
            return this.authority;
        }

        public string getID()
        {
            return this.ID;
        }
    }
}