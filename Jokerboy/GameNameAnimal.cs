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
    public partial class GameNameAnimal : Form
    {
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader data;
        User user = new User(Jokerboy.userID);
        JokerSafe safe = new JokerSafe();
        string name, city, animal, plant, furniture, famous;
        string[] words;
        byte gameTime = 180;

        public GameNameAnimal()
        {
            InitializeComponent();
        }

        private void GameNameAnimal_Load(object sender, EventArgs e)
        {
            safe.downloadJokerSafe();
            lblBalance.Text = user.getBalance().ToString();

            if (user.getAuthority() == "Admin")
                BtnAddQues.Enabled = true;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            words = new string[] {//25 harf var
                "A", "B", "C", "Ç", "D", "E", "F", "G", "H", "İ", "I", "K",
                "L", "M", "N", "O", "P", "R", "S", "Ş", "T", "U", "V", "Y", "Z"
            };
            Random rnd = new Random();
            byte index = Convert.ToByte(rnd.Next(0, words.Length - 1));

            if (connect.State == ConnectionState.Closed)
                connect.Open();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT * FROM GameNameCity WHERE Word=@w1 ORDER BY Rnd(-QuesID * time());";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@w1", words[0]);//words[0], words[index] ile değiştirilecek!
            data = cmd.ExecuteReader();
            data.Read();

            name = data["AnsName"].ToString().ToLower();
            city = data["AnsCity"].ToString().ToLower();
            animal = data["AnsAnimal"].ToString().ToLower();
            plant = data["AnsPlant"].ToString().ToLower();
            furniture = data["AnsFurniture"].ToString().ToLower();
            famous = data["AnsFamous"].ToString().ToLower();

            lblName.Text = data["ClueName"].ToString();
            lblCiity.Text = data["ClueCity"].ToString();
            lblAnimal.Text = data["ClueAnimal"].ToString();
            lblPlant.Text = data["CluePlant"].ToString();
            lblFurniture.Text = data["ClueFurniture"].ToString();
            lblFamous.Text = data["ClueFamous"].ToString();
            lblWord.Text = data["Word"].ToString();
            timer1.Start();
            BtnControl.Enabled = true;
            BtnStart.Enabled = false;
            textName.Clear();
            textCity.Clear();
            textAnimal.Clear();
            textPlant.Clear();
            textFurniture.Clear();
            textFamous.Clear();
            pictureName.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Pictures\\faq-icon.png");
            pictureCity.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Pictures\\faq-icon.png");
            pictureAnimal.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Pictures\\faq-icon.png");
            picturePlant.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Pictures\\faq-icon.png");
            pictureFurniture.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Pictures\\faq-icon.png");
            pictureFamous.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Pictures\\faq-icon.png");

            data.Close();
            connect.Close();
        }

        private void BtnControl_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (name == textName.Text.ToLower()) {
                user.isWin(true, 80);
                pictureName.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Pictures\\trueAnswer.png");
            }
            else
                pictureName.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Pictures\\falseAnswer.png");

            if (city == textCity.Text.ToLower())
            {
                user.isWin(true, 80);
                pictureCity.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Pictures\\trueAnswer.png");
            }
            else
                pictureCity.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Pictures\\falseAnswer.png");

            if (animal == textAnimal.Text.ToLower())
            {
                user.isWin(true, 80);
                pictureAnimal.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Pictures\\trueAnswer.png");
            }
            else
                pictureAnimal.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Pictures\\falseAnswer.png");

            if (plant == textPlant.Text.ToLower())
            {
                user.isWin(true, 80);
                picturePlant.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Pictures\\trueAnswer.png");
            }
            else
                picturePlant.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Pictures\\falseAnswer.png");

            if (furniture == textFurniture.Text.ToLower())
            {
                user.isWin(true, 80);
                pictureFurniture.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Pictures\\trueAnswer.png");
            }
            else
                pictureFurniture.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Pictures\\falseAnswer.png");

            if (famous == textFamous.Text.ToLower())
            {
                user.isWin(true, 80);
                pictureFamous.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Pictures\\trueAnswer.png");
            }
            else
                pictureFamous.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Pictures\\falseAnswer.png");

            BtnStart.Enabled = true;
            BtnControl.Enabled = false;
            lblBalance.Text = user.getBalance().ToString();
        }

        private void BtnComeBack_Click(object sender, EventArgs e)
        {
            Jokerboy joker = new Jokerboy();
            Jokerboy.TabNo = 3;
            joker.Show();
            this.Hide();
        }

        private void BtnGameRules_Click(object sender, EventArgs e)
        {
            string gameRules =
            "Ulusal bir oyun olan İsim Şehir Hayvanı ipucu kavramını ekleyerek yorumladık. \n" +
            "İpucular sayesinde birden fazla cevap yazma seçeneğiniz bire indi. \n" +
            "Süreniz her soru için 180 saniyedir. \n" +
            "Her doğru cevap için 80 TL kazanırsınız. Maksimum kazanç: 480 TL \n" +
            "Yanlış cevaplar için bir para kaybı yaşanmaz! \n" +
            "Cevabınız size vereceğimiz harf ile başlar. \n" +
            "Oyun, Türkçe dilbilginiz de ölçülüyor yani bir cevabın yazımı yanlış olursa soru yanlış kabul edilir. \n" +
            "Fakat büyük-küçük harf duyarlılığı yoktur.";
            JokerMessageBox box = new JokerMessageBox("Oyun Kuralları", gameRules);
            box.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = gameTime.ToString();
            if (gameTime == 0)
            {
                BtnControl_Click(sender, e);
            }
            gameTime--;
        }
    }
}