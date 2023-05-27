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
using MetroFramework;

namespace Jokerboy
{
    public partial class GameMillionaire : Form
    {
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader data;
        User user = new User(Jokerboy.userID);
        JokerSafe safe = new JokerSafe();
        Label[] levels;
        Label currentLevel;
        private byte gameTime = 60;
        private string A, B, C, D, question="", correctAnswer;
        private bool evenAnswer = false;

        public GameMillionaire()
        {
            InitializeComponent();
        }

        private void OyunMilyoner_Load(object sender, EventArgs e)
        {
            safe.downloadJokerSafe();
            levels = new Label[] {
                lblLevel1_1, lblLevel1_2, lblLevel2_1, lblLevel2_2, lblLevel2_3, 
                lblLevel3_1, lblLevel3_2, lblLevel3_3, lblLevel4_1, lblLevel4_2, null
            };
            currentLevel = lblLevel1_1;
            lblBalance.Text = user.getBalance().ToString();

            if (user.getAuthority() == "Admin")
                BtnAddQues.Enabled = true;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            downloadQuestion();
            BtnStart.Enabled = false;//Yeniden başlama olmayacak
            BtnA.Enabled = true;
            BtnB.Enabled = true;
            BtnC.Enabled = true;
            BtnD.Enabled = true;
            BtnJokerChangeLevel.Enabled = true;
            BtnJokerChangeQuestion.Enabled = true;
            BtnJokerEvenAnswer.Enabled = true;
        }

        private void BtnA_Click(object sender, EventArgs e)
        {
            result("A");
        }

        private void BtnB_Click(object sender, EventArgs e)
        {
            result("B");
        }

        private void BtnC_Click(object sender, EventArgs e)
        {
            result("C");
        }

        private void BtnD_Click(object sender, EventArgs e)
        {
            result("D");
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            finishGame();
        }

        private void BtnJokerChangeQuestion_Click(object sender, EventArgs e)
        {
            downloadQuestion();
            BtnJokerChangeQuestion.Enabled = false;
        }

        private void BtnJokerChangeLevel_Click(object sender, EventArgs e)
        {
            if (getLevel() != "Kolay")
            {
                Label tempCurrentLevel = currentLevel;
                currentLevel = lblLevel1_1;
                downloadQuestion();
                currentLevel = tempCurrentLevel;
                BtnJokerChangeLevel.Enabled = false;
            }
            else
            {
                MetroMessageBox.Show(this, "Bu joker, kolay sorularda kullanılamaz!", "Uyarı");
            }
        }

        private void BtnJokerEvenAnswer_Click(object sender, EventArgs e)
        {
            evenAnswer = true;
            BtnJokerEvenAnswer.Enabled = false;
        }

        private void downloadQuestion()
        {
            if (connect.State == ConnectionState.Closed)
                connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "Select Top 1 * From GameMillionaire where Difficulty=@p1 and Question<>@p2 ORDER BY Rnd(-QuesID * time());";
            cmd.Parameters.Clear();
            if (getLevel() != null)
            {
                cmd.Parameters.AddWithValue("@p1", getLevel());
                cmd.Parameters.AddWithValue("@p2", question);//Peş peşe aynı soru gelmemesi için eklendi
                data = cmd.ExecuteReader();
                data.Read();
                question = data["Question"].ToString();
                A = data["A"].ToString();
                B = data["B"].ToString();
                C = data["C"].ToString();
                D = data["D"].ToString();
                correctAnswer = data["Answer"].ToString();
                data.Close();

                textQuestion.Text = question;
                BtnA.Text = A;
                BtnB.Text = B;
                BtnC.Text = C;
                BtnD.Text = D;
                currentLevel.BorderStyle = BorderStyle.FixedSingle;

                timer1.Start();
            }
            else
            {
                //Tüm sorular bittiyse:
                finishGame();
            }
            connect.Close();
        }

        private string getLevel()
        {
            //Mevcut leveli belirler:
            int index = Array.IndexOf(levels, currentLevel);
            if (index + 1 < levels.Length)
            {
                if (index >= 0 && index <= 1) {
                    gameTime = 60;
                    return "Kolay";
                }
                else if (index >= 2 && index <= 4) {
                    gameTime = 60;
                    return "Orta";
                }
                else if (index >= 5 && index <= 7) {
                    gameTime = 150;
                    return "Zor";
                }
                else if (index >= 8 && index <= 9) {
                    gameTime = 240;
                    return "Akademik";
                }
            }
            return null;
        }

        private void upLevel()
        {
            //Mevcut leveli artırır:
            int index = Array.IndexOf(levels, currentLevel);
            if (index < levels.Length)
            {
                currentLevel.BackColor = Color.Gray;
                currentLevel.BorderStyle = BorderStyle.None;

                index++;
                currentLevel = levels[index];
                downloadQuestion();
            }
        }

        private void result(string userAnswer)
        {
            if (userAnswer == correctAnswer)
            {
                //Kullanıcı doğru cevabı bulduysa:
                user.isWin(true, calculateEarnings());
                upLevel();
            }
            else
            {
                if (evenAnswer == false)
                    finishGame();
                else
                    evenAnswer = false;
            }
            lblBalance.Text = user.getBalance().ToString();
        }

        private void finishGame()
        {
            BtnFinish.Enabled = false;
            BtnA.Enabled = false;
            BtnB.Enabled = false;
            BtnC.Enabled = false;
            BtnD.Enabled = false;
            BtnJokerChangeLevel.Enabled = false;
            BtnJokerChangeQuestion.Enabled = false;
            BtnJokerEvenAnswer.Enabled = false;
            textQuestion.Clear();
            BtnA.Text = "";
            BtnB.Text = "";
            BtnC.Text = "";
            BtnD.Text = "";
            textQuestion.Text = "Oyun bitti! Oynamak için oyuna yeniden giriş yapın.";
            timer1.Stop();
        }

        private long calculateEarnings()
        {
            switch (Array.IndexOf(levels, currentLevel))
            {
                case 0:
                    return 100;
                case 1:
                    return 500;
                case 2:
                    return 3000;
                case 3:
                    return 6000;
                case 4:
                    return 10000;
                case 5:
                    return 35000;
                case 6:
                    return 65000;
                case 7:
                    return 125000;
                case 8:
                    return 250000;
                case 9:
                    return 1000000;
                default:
                    return 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = gameTime.ToString();
            if (gameTime == 0)
            {
                finishGame();
            }
            gameTime--;
        }

        private void BtnHowPlay_Click(object sender, EventArgs e)
        {
            string gameRules =
            "Soru başına ödül kazanırsınız. \n" +
            "Üç tane jokeriniz vardır. \n" +
            "1) Düzey değiştirme jokeri: Bulunduğunuz sorunun düzeyini kolaya indirir. Kolay sorularda kullanılamaz! \n" +
            "2) Çift cevap jokeri: Bir soruya 2 cevap verme olanağı sunar. \n" +
            "3) Soru değiştirme jokeri: Bulunduğunuz soruyu düzeyi aynı olmak şartıyla değiştirir.\n" +
            "Süreniz kolay-orta düzeylerde 60, zor düzeyde 150, akademik düzeyde 240 saniyedir. \n" +
            "Tek yanlış yapma hakkınız vardır. İlk yanlışta oyun biter.";
            JokerMessageBox message = new JokerMessageBox("Milyoner Oyun Kuralları", gameRules);
            message.Show();
            //MetroMessageBox.Show(this, gameRules, "OYUN KURALLARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnComeBack_Click(object sender, EventArgs e)
        {
            Jokerboy joker = new Jokerboy();
            Jokerboy.TabNo = 3;
            joker.Show();
            this.Hide();
        }
    }
}