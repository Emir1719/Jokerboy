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
        enum GameState {
            start, restart
        }

        private int horse1x, horse2x, horse3x, horse4x;
        private int horse1y, horse2y, horse3y, horse4y;
        private readonly short minSpeed = 1, maxSpeed = 12;
        GameState state = GameState.start;

        public GameHorseRace()
        {
            InitializeComponent();
        }

        private void timer1_Tick_1(object sender, EventArgs e) {
            Random rnd = new Random();
            pictureBox1.Left += rnd.Next(minSpeed, maxSpeed);//at1
            pictureBox2.Left += rnd.Next(minSpeed, maxSpeed);//at2
            pictureBox3.Left += rnd.Next(minSpeed, maxSpeed);//at3
            pictureBox4.Left += rnd.Next(minSpeed, maxSpeed);//at4
            result();
        }

        private void result() {
            string horseName = "";
            if (pictureBox1.Right >= finalLine.Left) {
                horseName = "Jack";
            }
            else if (pictureBox2.Right >= finalLine.Left) {
                horseName = "Leo";
            }
            else if (pictureBox3.Right >= finalLine.Left) {
                horseName = "White";
            }
            else if (pictureBox4.Right >= finalLine.Left) {
                horseName = "David";
            }
            else return; //Eğer yarışı bitiren bir at olmadıysa oyun devam etsin.

            timer1.Stop();
            BtnGame.Text = "Yeniden Oyna";
            BtnGame.Enabled = true;
            pictureBox1.Enabled = false;
            pictureBox2.Enabled = false;
            pictureBox3.Enabled = false;
            pictureBox4.Enabled = false;
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            JokerMessageBox messageBox = new JokerMessageBox("Sonuç", horseName + " kazandı.");
            messageBox.setSize(JokerMessageBox.FormSize.small);
            messageBox.Show();
        }

        private void BtnComeBack_Click(object sender, EventArgs e) {
            Jokerboy joker = new Jokerboy();
            Jokerboy.TabNo = 3;
            joker.Show();
            this.Hide();
        }

        private void BtnOyunKural_Click(object sender, EventArgs e) {
            JokerMessageBox messageBox = new JokerMessageBox();
            messageBox.setTitle("Bilgilendirme");
            messageBox.setContent("At yarışı haram bir içerik olduğu için bu oyundan para kazanamazsınız! Eğlence amaçlı vardır. \n" +
                "Bu oyunu hesap oluşturmadan oynayabilirsiniz.");
            messageBox.Show();
        }

        private void AtYarisi_Load(object sender, EventArgs e) {
            horse1x = pictureBox1.Location.X;
            horse1y = pictureBox1.Location.Y;

            horse2x = pictureBox2.Location.X;
            horse2y = pictureBox2.Location.Y;

            horse3x = pictureBox3.Location.X;
            horse3y = pictureBox3.Location.Y;

            horse4x = pictureBox4.Location.X;
            horse4y = pictureBox4.Location.Y;
        }

        private void button1_Click(object sender, EventArgs e) {
            if (comboBox1.Text != "")
            {
                switch (state)
                {
                    case GameState.start:
                        timer1.Start();
                        axWindowsMediaPlayer1.URL = Application.StartupPath + "\\Music\\horse-race-sound.mp3";
                        BtnGame.Enabled = false;
                        comboBox1.Enabled = false;
                        pictureBox1.Enabled = true;
                        pictureBox2.Enabled = true;
                        pictureBox3.Enabled = true;
                        pictureBox4.Enabled = true;
                        state = GameState.restart;
                        break;
                    case GameState.restart:
                        //Atlar eski konumuna getirilir.
                        pictureBox1.Location = new Point(horse1x, horse1y);
                        pictureBox2.Location = new Point(horse2x, horse2y);
                        pictureBox3.Location = new Point(horse3x, horse3y);
                        pictureBox4.Location = new Point(horse4x, horse4y);
                        BtnGame.Enabled = true;
                        comboBox1.Enabled = true;
                        state = GameState.start;
                        BtnGame.Text = "Oyunu Başlat";
                        break;
                }
            }
            else
            {
                JokerMessageBox messageBox = new JokerMessageBox();
                messageBox.setTitle("Uyarı");
                messageBox.setContent("At Seçimi Yapınız!");
                messageBox.Show();
            }
        }
    }
}