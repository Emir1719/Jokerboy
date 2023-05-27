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
    public partial class AddDetective : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Veritabanı.mdb");
        OleDbCommand komut = new OleDbCommand();
        //OleDbDataReader data;

        public AddDetective()
        {
            InitializeComponent();
        }

        private void BtnGeriDön_Click(object sender, EventArgs e)
        {
            GameDetective dedektif = new GameDetective();
            dedektif.Show();
            this.Hide();
        }

        private void SoruEklemeDedektif_Load(object sender, EventArgs e)
        {

        }

        private void BtnSoruEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Insert into Dedektif (olay,kisi1,kisi2,kisi3,acıklama,yalancı) values (@p1,@p2,@p3,@p4,@p5,@p6)";
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@p1",textBox1.Text);
            komut.Parameters.AddWithValue("@p2",textKisi1.Text);
            komut.Parameters.AddWithValue("@p3",textKisi2.Text);
            komut.Parameters.AddWithValue("@p4",textKisi3.Text);
            komut.Parameters.AddWithValue("@p5",textBox2.Text);
            komut.Parameters.AddWithValue("@p6",comboBox1.Text);
            if (komut.ExecuteNonQuery()==1)
            {
                MessageBox.Show("Soru eklediğiniz için teşekkür ederiz.");
            }
            baglanti.Close();
        }
    }
}
