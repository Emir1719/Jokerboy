using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;

namespace Jokerboy
{
    public partial class GameHorseRace : Form
    {
        int At1x, At2x, At3x, At4x, At1y, At2y, At3y, At4y, Index = 1;
        
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            Random rnd = new Random();
            pictureBox1.Left += rnd.Next(1, 10);//at1
            pictureBox2.Left += rnd.Next(1, 10);//at2
            pictureBox3.Left += rnd.Next(1, 10);//at3
            pictureBox4.Left += rnd.Next(1, 10);//at4

            if (pictureBox1.Right >= finalLine.Left)
            {
                timer1.Stop();
                afterRice();
                MetroMessageBox.Show(this, "Jack kazandı.", "Sonuç!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (pictureBox2.Right >= finalLine.Left)
            {
                timer1.Stop();
                afterRice();
                MetroMessageBox.Show(this, "Leo kazandı.", "Sonuç!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (pictureBox3.Right >= finalLine.Left)
            {
                timer1.Stop();
                afterRice();
                MetroMessageBox.Show(this, "White kazandı.", "Sonuç!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (pictureBox4.Right >= finalLine.Left)
            {
                timer1.Stop();
                afterRice();
                MetroMessageBox.Show(this, "David kazandı.", "Sonuç!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void BtnComeBack_Click(object sender, EventArgs e)
        {
            Jokerboy joker = new Jokerboy();
            Jokerboy.TabNo = 3;
            joker.Show();
            this.Hide();
        }

        private void BtnOyunKural_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "At yarışı haram bir içerik olduğu için bu oyundan para kazanamazsınız! Eğlence amaçlı vardır.", "Bilgilendirme!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void AtYarisi_Load(object sender, EventArgs e)
        {
            At1x = pictureBox1.Location.X;
            At1y = pictureBox1.Location.Y;

            At2x = pictureBox2.Location.X;
            At2y = pictureBox2.Location.Y;

            At3x = pictureBox3.Location.X;
            At3y = pictureBox3.Location.Y;

            At4x = pictureBox4.Location.X;
            At4y = pictureBox4.Location.Y;
        }

        public GameHorseRace()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                switch (Index)
                {
                    case 1://oyuna başla
                        timer1.Start();
                        axWindowsMediaPlayer1.URL = Application.StartupPath + "\\Music\\horse-race-sound.mp3";
                        BtnGame.Enabled = false;
                        comboBox1.Enabled = false;
                        pictureBox1.Enabled = true;
                        pictureBox2.Enabled = true;
                        pictureBox3.Enabled = true;
                        pictureBox4.Enabled = true;
                        Index++;
                        break;
                    case 2://yeniden oyna
                        pictureBox1.Location = new Point(At1x, At1y);
                        pictureBox2.Location = new Point(At2x, At2y);
                        pictureBox3.Location = new Point(At3x, At3y);
                        pictureBox4.Location = new Point(At4x, At4y);
                        BtnGame.Enabled = true;
                        comboBox1.Enabled = true;
                        Index = 1;
                        BtnGame.Text = "Oyunu Başlat";
                        break;
                }
            }
            else
            {
                MetroMessageBox.Show(this, "At Seçimi Yapınız!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void afterRice()
        {
            BtnGame.Text = "Yeniden Oyna";
            BtnGame.Enabled = true;

            pictureBox1.Enabled = false;
            pictureBox2.Enabled = false;
            pictureBox3.Enabled = false;
            pictureBox4.Enabled = false;

            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }
    }
}