using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;
using System.Media;

namespace Jokerboy
{
    public partial class GamePassaparola : Form
    {
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader data;
        SoundPlayer sound = new SoundPlayer();
        User user = new User(Jokerboy.userID);
        JokerSafe safe = new JokerSafe();
        Button[] gameButtons;
        Button currentButton;
        byte gameTime = 50, trueCount = 0, falseCount = 0, passCount = 0;
        string question, answer;

        public GamePassaparola()
        {
            InitializeComponent();
        }

        private void OyunPassaparola_Load(object sender, EventArgs e)
        {
            disableAllButtons();
            printScore();
            BtnA.Enabled = true;
            gameButtons = new Button[] {
                BtnA, BtnB, BtnC, BtnC2, BtnD, BtnE, BtnF, BtnG, BtnH, BtnI, BtnK, BtnL, BtnM,
                BtnN, BtnO, BtnP, BtnR, BtnS, BtnS2, BtnT, BtnU, BtnU2, BtnV, BtnY, BtnZ, BtnW
            };
            safe.downloadJokerSafe();
            //Array.IndexOf(gameButtons, BtnW); BtnW'nun index sırasını verir: 25
        }

        private void downloadQuestion(string BtnWord)
        {
            //Butondaki harfe göre veri tabanından rastegele 1 soru alır:
            if (connect.State == ConnectionState.Closed)
                connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "Select Top 1 * From GamePassaparola where Word=@p1 ORDER BY Rnd(-QuesID * time());";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@p1", BtnWord);
            data = cmd.ExecuteReader();
            if (data.HasRows)
            {
                //Veri tabanından gelen veriler değişkenlere aktarılır:
                data.Read();
                //quesID = data[0].ToString();
                question = data[1].ToString();
                answer = data[2].ToString();
                data.Close();

                //Alınan veriler forma aktarılır:
                textQuestion.Text = question;

                //Oyun başlayınca nesneler aktifleştirilir:
                BtnSubmit.Enabled = true;
                BtnPass.Enabled = true;
                textAnswer.Enabled = true;
                currentButton.Enabled = false;
                gameTime = 50;
                timer1.Start();
            }
            connect.Close();
        }

        private void disableAllButtons()
        {
            //Oyun bitince ve başlamadan önce butonlar pasif yapılır:
            BtnA.Enabled = false;
            BtnB.Enabled = false;
            BtnC.Enabled = false;
            BtnC2.Enabled = false;
            BtnD.Enabled = false;
            BtnE.Enabled = false;
            BtnF.Enabled = false;
            BtnG.Enabled = false;
            BtnH.Enabled = false;
            BtnI.Enabled = false;
            BtnK.Enabled = false;
            BtnL.Enabled = false;
            BtnM.Enabled = false;
            BtnN.Enabled = false;
            BtnO.Enabled = false;
            BtnP.Enabled = false;
            BtnR.Enabled = false;
            BtnS.Enabled = false;
            BtnS2.Enabled = false;
            BtnT.Enabled = false;
            BtnU.Enabled = false;
            BtnU2.Enabled = false;
            BtnV.Enabled = false;
            BtnY.Enabled = false;
            BtnZ.Enabled = false;
            BtnW.Enabled = false;
            BtnPass.Enabled = false;
            BtnSubmit.Enabled = false;
            textAnswer.Enabled = false;
        }

        private void printScore()
        {
            lblTrue.Text = trueCount.ToString();
            lblFalse.Text = falseCount.ToString();
            lblPass.Text = passCount.ToString();
            lblBalance.Text = user.getBalance().ToString();
        }

        private void clearAndPassive()
        {
            currentButton.Enabled = false;
            BtnSubmit.Enabled = false;
            BtnPass.Enabled = false;
            textAnswer.Enabled = false;
            textAnswer.Clear();
            textQuestion.Clear();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            //Cevap boş değilse kontrol yapılır:
            if (textAnswer.Text.Trim() != "")
            {
                int index = Array.IndexOf(gameButtons, currentButton);
                string path;

                //Sorunun cevabı doğru bilinmişse:
                if (textAnswer.Text.Trim().ToUpper() == answer.Trim().ToUpper())
                {
                    trueCount++;
                    user.isWin(true, 50);
                    gameButtons[index].BackColor = Color.Green;
                    path = Application.StartupPath + "\\Music\\true-sound.wav";
                }
                else
                {
                    falseCount++;
                    gameButtons[index].BackColor = Color.Red;
                    path = Application.StartupPath + "\\Music\\false-sound.wav";
                    MetroFramework.MetroMessageBox.Show(this, answer, "Doğru Cevap");
                }
                sound.SoundLocation = path;
                sound.Play();

                if (index + 1 < gameButtons.Length)
                    gameButtons[index + 1].Enabled = true;

                timer1.Stop();
                printScore();
                clearAndPassive();
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Lütfen cevap alanını boş bırakmayınız! Cevabınız yoksa soruyu pas geçebilirsiniz.");
            }
        }

        private void BtnPass_Click(object sender, EventArgs e)
        {
            passCount++;
            //Seçili buton bulunup pasif yapılır:
            int index = Array.IndexOf(gameButtons, currentButton);
            gameButtons[index].Enabled = false;
            gameButtons[index].BackColor = Color.Gray;

            //Seçili butondan sonraki buton aktif edilir:
            if (index + 1 < gameButtons.Length)
                gameButtons[index + 1].Enabled = true;

            timer1.Stop();
            printScore();
            clearAndPassive();
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {
            string gameRules =
            "Her soru başına 50 TL kazanacaksınız. \n" +
            "Pas butonuna bastığınızda bulunduğunuz soruyu atlar. Bakiyeniz azalmaz! \n" +
            "Soruyu doğru cevaplayamazsanız bile bakiyeniz asla azalmaz! \n" +
            "Cevabınız büyük butonda yazılan harf ile başlar.\n" +
            "Cevabınızda büyük-küçük harf önemi yoktur ama birleşik-ayrı kelime farkı vardır.\n" +
            "Bu oyun Türkçe dil bilginizi de ölçüyor. Yani bir cevabın yazımını yanlış yazarsanız soru yanlış kabul edilir.";

            JokerMessageBox message = new JokerMessageBox("Passaparola Oyun Kuralları", gameRules);
            message.Show();
        }

        private void BtnComeBack_Click(object sender, EventArgs e)
        {
            Jokerboy joker = new Jokerboy();
            Jokerboy.TabNo = 3;
            joker.Show();
            this.Hide();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                BtnSubmit_Click(sender, e);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gameTime--;
            lblTime.Text = gameTime.ToString();
            if (gameTime == 0)
            {
                timer1.Stop();
                BtnPass_Click(sender, e);
                gameTime = 50;
            }
        }

        #region Buttons A...W

        private void BtnW_Click(object sender, EventArgs e)
        {
            BtnMain.Text = "W";
            currentButton = BtnW;
            downloadQuestion(BtnMain.Text);
        }

        private void BtnZ_Click(object sender, EventArgs e)
        {
            BtnMain.Text = "Z";
            currentButton = BtnZ;
            downloadQuestion(BtnMain.Text);
        }

        private void BtnY_Click(object sender, EventArgs e)
        {
            BtnMain.Text = "Y";
            currentButton = BtnY;
            downloadQuestion(BtnMain.Text);
        }

        private void BtnV_Click(object sender, EventArgs e)
        {
            BtnMain.Text = "V";
            currentButton = BtnV;
            downloadQuestion(BtnMain.Text);
        }

        private void BtnU2_Click(object sender, EventArgs e)
        {
            BtnMain.Text = "Ü";
            currentButton = BtnU2;
            downloadQuestion(BtnMain.Text);
        }

        private void BtnU_Click(object sender, EventArgs e)
        {
            BtnMain.Text = "U";
            currentButton = BtnU;
            downloadQuestion(BtnMain.Text);
        }

        private void BtnT_Click(object sender, EventArgs e)
        {
            BtnMain.Text = "T";
            currentButton = BtnT;
            downloadQuestion(BtnMain.Text);
        }

        private void BtnS2_Click(object sender, EventArgs e)
        {
            BtnMain.Text = "Ş";
            currentButton = BtnS2;
            downloadQuestion(BtnMain.Text);
        }

        private void BtnS_Click(object sender, EventArgs e)
        {
            BtnMain.Text = "S";
            currentButton = BtnS;
            downloadQuestion(BtnMain.Text);
        }

        private void BtnR_Click(object sender, EventArgs e)
        {
            BtnMain.Text = "R";
            currentButton = BtnR;
            downloadQuestion(BtnMain.Text);
        }

        private void BtnP_Click(object sender, EventArgs e)
        {
            BtnMain.Text = "P";
            currentButton = BtnP;
            downloadQuestion(BtnMain.Text);
        }

        private void BtnO_Click(object sender, EventArgs e)
        {
            BtnMain.Text = "O";
            currentButton = BtnO;
            downloadQuestion(BtnMain.Text);
        }

        private void BtnN_Click(object sender, EventArgs e)
        {
            BtnMain.Text = "N";
            currentButton = BtnN;
            downloadQuestion(BtnMain.Text);
        }

        private void BtnM_Click(object sender, EventArgs e)
        {
            BtnMain.Text = "M";
            currentButton = BtnM;
            downloadQuestion(BtnMain.Text);
        }

        private void BtnL_Click(object sender, EventArgs e)
        {
            BtnMain.Text = "L";
            currentButton = BtnL;
            downloadQuestion(BtnMain.Text);
        }

        private void BtnK_Click(object sender, EventArgs e)
        {
            BtnMain.Text = "K";
            currentButton = BtnK;
            downloadQuestion(BtnMain.Text);
        }

        private void BtnI_Click(object sender, EventArgs e)
        {
            BtnMain.Text = "İ";
            currentButton = BtnI;
            downloadQuestion(BtnMain.Text);
        }

        private void BtnH_Click(object sender, EventArgs e)
        {
            BtnMain.Text = "H";
            currentButton = BtnH;
            downloadQuestion(BtnMain.Text);
        }

        private void BtnG_Click(object sender, EventArgs e)
        {
            BtnMain.Text = "G";
            currentButton = BtnG;
            downloadQuestion(BtnMain.Text);
        }

        private void BtnF_Click(object sender, EventArgs e)
        {
            BtnMain.Text = "F";
            currentButton = BtnF;
            downloadQuestion(BtnMain.Text);
        }

        private void BtnE_Click(object sender, EventArgs e)
        {
            BtnMain.Text = "E";
            currentButton = BtnE;
            downloadQuestion(BtnMain.Text);
        }

        private void BtnD_Click(object sender, EventArgs e)
        {
            BtnMain.Text = "D";
            currentButton = BtnD;
            downloadQuestion(BtnMain.Text);
        }

        private void BtnA_Click(object sender, EventArgs e)
        {
            BtnMain.Text = "A";
            currentButton = BtnA;
            downloadQuestion(BtnMain.Text);
        }

        private void BtnB_Click(object sender, EventArgs e)
        {
            BtnMain.Text = "B";
            currentButton = BtnB;
            downloadQuestion(BtnMain.Text);
        }

        private void BtnC_Click(object sender, EventArgs e)
        {
            BtnMain.Text = "C";
            currentButton = BtnC;
            downloadQuestion(BtnMain.Text);
        }

        private void BtnC2_Click(object sender, EventArgs e)
        {
            BtnMain.Text = "Ç";
            currentButton = BtnC2;
            downloadQuestion(BtnMain.Text);
        }

        #endregion
    }
}