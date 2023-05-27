using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Jokerboy
{
    public partial class JokerboyRegister : MetroFramework.Forms.MetroForm
    {
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader data;

        public JokerboyRegister()
        {
            InitializeComponent();
        }

        private void JokerboyRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void BtnComeBack_Click(object sender, EventArgs e)
        {
            Jokerboy joker = new Jokerboy();
            joker.Show();
            this.Hide();
        }

        private void Register()//Kayıt
        {
            if (textUserName.Text.Trim() != "" && textPassword.Text.Trim() != "")
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                cmd.Connection = connect;
                cmd.CommandText = "Select * From Hesap where KullaniciAdi=@p1";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@p1", textUserName.Text);
                data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    data.Close();
                    MetroFramework.MetroMessageBox.Show(this, "Bu kullanıcı adı kullanılmaktadır. Aynı kullanıcı adı kullanılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //MessageBox.Show(ConfirmCode);
                    data.Close();
                    cmd.Connection = connect;
                    cmd.CommandText = "insert into Hesap (KullaniciAdi,Sifre,Cinsiyet,Bakiye,Yetki) values (@p1,@p2,@p3,@p4,@p5)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@p1", textUserName.Text);
                    cmd.Parameters.AddWithValue("@p2", textPassword.Text);
                    //cmd.Parameters.AddWithValue("@p3", comboGender.Text);
                    cmd.Parameters.AddWithValue("@p4", 100);
                    cmd.Parameters.AddWithValue("@p5", "Üye");
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        //UserName = textUserName.Text;
                        //Balance = 100;
                        //Authority = "Üye";
                        //Password = textPassword.Text;
                        textUserName.Clear();
                        textPassword.Clear();
                        MetroFramework.MetroMessageBox.Show(this, "Jokerboy'a Kaydınız Yapılmıştır.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Lütfen tüm bilgileri doldurunuz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            connect.Close();
        }
    }
}
