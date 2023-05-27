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
    public partial class JokerUserEdit : Form
    {
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        DataSet set = new DataSet();
        User user = new User(Jokerboy.userID);
        public static string id;

        public JokerUserEdit()
        {
            InitializeComponent();
        }

        private void JokerUserEdit_Load(object sender, EventArgs e)
        {
            if (user.getAuthority() == "Admin")
            {
                comboBox1.Items.Add("Admin");
                BtnDelete.Visible = true;
            }
            downloadData();
        }

        private void downloadData()
        {
            if (connect.State == ConnectionState.Closed)
                connect.Open();

            dataGridView1.Refresh();
            set.Tables.Clear();
            dataGridView1.Columns.Clear();
            adapter = new OleDbDataAdapter("Select ID, Name as [Kullanıcı Adı], Gmail, Gender as Cinsiyet, Authority as Yetki, Balance as Bakiye From Account where Name not in ('"+user.getName()+"') and Password not in ('"+user.getPassword()+"')", connect);
            adapter.Fill(set, "Account");
            dataGridView1.DataSource = set.Tables["Account"];
            adapter.Dispose();
        }

        private void BtnSeç_Click(object sender, EventArgs e)
        {
            if (user.getAuthority() == "Yönetici")
            {
                if (dataGridView1.CurrentRow.Cells["Yetki"].Value.ToString() != "Admin")
                {
                    id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    lblKullanıcı.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    comboBox1.Text = dataGridView1.CurrentRow.Cells["Yetki"].Value.ToString();
                    BtnUpdate.Enabled = true;
                    BtnDelete.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Adminlerin yetkisini düzenleyemezsiniz.");
                }
            }
            else
            {
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                lblKullanıcı.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells["Yetki"].Value.ToString();
                BtnUpdate.Enabled = true;
                BtnDelete.Enabled = true;
            }
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Closed)
                connect.Open();

            cmd.Connection = connect;
            cmd.CommandText = "Update Account set Authority=@p1 where ID=@p2";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@p1", comboBox1.Text);
            cmd.Parameters.AddWithValue("@p2", id);
            cmd.ExecuteNonQuery();
            downloadData();
            connect.Close();
            BtnUpdate.Enabled = false;
            BtnDelete.Enabled = false;
            comboBox1.Text = "";
            lblKullanıcı.Text = "?";
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seçili kullanıcı silinecek, devam etmek ister misiniz?", "Sil",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                cmd.Connection = connect;
                cmd.CommandText = "Delete * From Hesap where id=@p2";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@p2", id);
                cmd.ExecuteNonQuery();
                downloadData();
                connect.Close();
            }
            BtnUpdate.Enabled = false;
            BtnDelete.Enabled = false;
            comboBox1.Text = "";
            lblKullanıcı.Text = "?";
        }

        private void BtnComeBack_Click(object sender, EventArgs e)
        {
            Jokerboy joker = new Jokerboy();
            Jokerboy.TabNo = 2;
            joker.Show();
            this.Hide();
        }
    }
}