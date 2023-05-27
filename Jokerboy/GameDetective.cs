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
    public partial class GameDetective : Form
    {
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader data;
        User user = new User(Jokerboy.userID);
        JokerSafe safe = new JokerSafe();
        byte trueCount = 0, falseCount = 0, quesCount, counter = 0, gameTime = 90;
        string[] person1 = new string[5];
        string[] person2 = new string[5];
        string[] person3 = new string[5];
        string[] lier = new string[5];
        string[] explanation = new string[5];//Olayın çözümü / açıklaması
        string[] happen = new string[5];
        string lierPerson, explanationOfHappen, condition = "Start";
        //quesID ekle!

        public GameDetective()
        {
            InitializeComponent();
        }

        private void OyunDedektif_Load(object sender, EventArgs e)
        {
            lblBalance.Text = user.getBalance().ToString();
            safe.downloadJokerSafe();
            if (user.getAuthority() == "Admin")
                BtnAddQues.Enabled = true;
            else
                BtnAddQues.Enabled = false;
        }

        private void downloadQuestions()
        {
            //Veritanından rastgele 5 soru alır:
            Array.Clear(person1, 0, person1.Length);
            Array.Clear(person2, 0, person2.Length);
            Array.Clear(person3, 0, person3.Length);
            if (connect.State == ConnectionState.Closed) {
                connect.Open();
            }
            cmd.Connection = connect;
            cmd.CommandText = "SELECT TOP 5 * FROM GameDetective WHERE ID not in (Select QuesID from UsedQuesDetective where UserID=@p1) ORDER BY Rnd(-ID * time());";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@p1", user.getID());
            //cmd.CommandText = "SELECT TOP 5 * FROM GameDetective ORDER BY Rnd(-ID * time());"; eski sql komutu
            //ORDER BY Rnd(-ID * time()) rastgele sıralayan sql komutu
            data = cmd.ExecuteReader();
            for (quesCount = 0; data.Read(); quesCount++)
            {
                happen[quesCount] = data[1].ToString();
                person1[quesCount] = data[2].ToString();
                person2[quesCount] = data[3].ToString();
                person3[quesCount] = data[4].ToString();
                explanation[quesCount] = data[5].ToString();
                lier[quesCount] = data[6].ToString();
            }
            data.Close();
            if (connect.State == ConnectionState.Open) {
                connect.Close();
            }
        }
        
        private void showQuestion()
        {
            //Dizideki soruyu formdaki nesnelere aktarır.
            if (counter < 5)
            {
                //Sorular bitemmişse oyun devam eder:
                lblOlay.Text = happen[counter].ToString();
                textKisi1.Text = person1[counter].ToString();
                textKisi2.Text = person2[counter].ToString();
                textKisi3.Text = person3[counter].ToString();
                lierPerson = lier[counter].ToString();
                explanationOfHappen = explanation[counter].ToString(); 
                gameTime = 90;
                counter++;
                timer1.Start();
            }
            else
            {
                //Tüm sorular bittiyse:
                lblOlay.Text = "?";
                BtnGame.Text = "Başla";
                condition = "Start";
                textKisi1.Clear();
                textKisi2.Clear();
                textKisi3.Clear();
                timer1.Stop();
                if (trueCount > falseCount)
                {
                    //Kullanıcı oyunu kazandı.
                    int result = user.isWin(true, calculateEarnings());
                    if (result == 1)
                        MetroFramework.MetroMessageBox.Show(this, "Sorularımız burada bitmiştir. Geri kalan tüm iş polisin artık. Dedektif olarak iyi bir iş yaptınız.", "Oyun Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (result == -1)
                        MetroFramework.MetroMessageBox.Show(this, "Kasamızdaki bakiye yetersiz kaldı. Borcumuzu en yakın zamanda ödeyeceğiz!", "Oyun Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblBalance.Text = user.getBalance().ToString();
                }
                else
                {
                    //Kullanıcı oyunu kaybettiyse:
                    MetroFramework.MetroMessageBox.Show(this, "Biraz daha çalışmanız gerekir sayın dedektif! Bir sonraki sefere görüşürüz!", "Oyun Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void findLier()
        {
            //Yalancıyı bulan fonksiyon:
            timer1.Stop();
            if (comboBox1.Text == lierPerson) {
                JokerMessageBox message = new JokerMessageBox("Tebrikler!", "Yalancının "+lierPerson+" olduğunu buldunuz.");
                message.Show();
                //MetroFramework.MetroMessageBox.Show(this, "Tebrikler dedektif! yalancıyı yakaladın.", "Yalancıyı Buldun",MessageBoxButtons.OK,MessageBoxIcon.Information);
                trueCount++;
            }
            else {
                JokerMessageBox message = new JokerMessageBox("Yalancı: " + lierPerson, "Olayın Çözümü: "+explanationOfHappen);
                message.Show();
                //MetroFramework.MetroMessageBox.Show(this, "Üzgünüz dedektif! yalancının " + lierPerson + " oluduğunu bulamadın!", "Yalancı Kimdi?", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //MetroFramework.MetroMessageBox.Show(this, explanationOfHappen, "Olayın Çözümü", MessageBoxButtons.OK, MessageBoxIcon.Information);
                falseCount++;
            }
            printScore();
            showQuestion();
        }

        private long calculateEarnings()
        {
            switch (trueCount)
            {
                case 3:
                    return 300;
                case 4:
                    return 600;
                case 5:
                    return 1000;
                default:
                    //trueCount = 0, 1, 2 olursa default'a girecek.
                    return 0;
            }
        }

        private void printScore()
        {
            lblTrue.Text = trueCount + "D";
            lblFalse.Text = falseCount + "Y";
        }

        private void BtnComeBack_Click(object sender, EventArgs e)
        {
            Jokerboy joker = new Jokerboy();
            Jokerboy.TabNo = 3;
            joker.Show();
            this.Hide();
        }

        private void BtnGame_Click(object sender, EventArgs e)
        {
            switch (condition)
            {
                case "Start":
                    counter = 0;
                    trueCount = 0;
                    falseCount = 0;
                    printScore();
                    downloadQuestions();
                    showQuestion();
                    BtnGame.Text = "Tahmin Et";
                    condition = "Estimate";
                    break;
                case "Estimate":
                    if (comboBox1.Text.Trim() != "")
                        findLier();
                    else
                        MetroFramework.MetroMessageBox.Show(this, "Lütfen yalancıyı seçiniz!","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    break;
            }
        }

        private void BtnSoruEkle_Click(object sender, EventArgs e)
        {
            AddDetective soruEkleme = new AddDetective();
            soruEkleme.Show();
            this.Hide();
        }

        private void BtnOyunKural_Click(object sender, EventArgs e)
        {
            string gameRules =
            "Tüm soruları yanıtladıktan sonra ödülünüz bakiyenize eklenir.\n" +
            "Cinayet, hırsızlık gibi olaylar sonrasında şüphelilerin verdiği ifadelerindeki yalanı yakalayın. Sadece bir kişi yalan söylüyor. Kim?\n" +
            "Süreniz her soru için 90 saniyedir. \n" +
            "Soru cevaplanmadan süre biterse doğru ya da yanlış sayısı artmaz! \n" +
            "Ödül kazanmada önemli olan doğru sayısıdır.";
            JokerMessageBox message = new JokerMessageBox("Dedektif Oyun Kuralı", gameRules);
            message.Show();
            //MetroFramework.MetroMessageBox.Show(this, gameRules, "OYUN KURALLARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gameTime--;
            lblSüre.Text = gameTime.ToString();
            if (gameTime == 0)
            {
                timer1.Stop();
                gameTime = 90;
                showQuestion();
            }
        }
    }
}