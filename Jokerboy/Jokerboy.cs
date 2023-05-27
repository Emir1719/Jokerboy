using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using MetroFramework;

namespace Jokerboy
{
    public partial class Jokerboy : MetroFramework.Forms.MetroForm
    {
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader data;
        public static string userID = "0";
        public static byte TabNo = 1;
        string condition = "Login";

        public Jokerboy()
        {
            InitializeComponent();
        }

        private void Jokerboy_Load(object sender, EventArgs e)
        {
            beginningTab(TabNo);
            printUserData();
            if (userID != "0") {
                //Kullanıcı daha önceden giriş yaptıysa:
                isLogin(true);
                printUserData();
            }
            else isLogin(false);
        }

        private void Jokerboy_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void beginningTab(byte Tab)
        {
            //Kullanıcı ana sayfaya geri döndüğünde hangi sekmenin açık kalacağını belirler:
            if (Tab == 1) metroTabControl1.SelectedTab = metroTabPage1;
            else if (Tab == 2) metroTabControl1.SelectedTab = metroTabPage2;
            else if (Tab == 3) metroTabControl1.SelectedTab = metroTabPage3;
        }

        #region#Giriş

        private void BtnMain_Click(object sender, EventArgs e)
        {
            //Bu buton duruma göre ya giriş ya da çıkış butonudur.
            switch (condition)
            {
                case "Login": login(); break;
                case "Exit": isLogin(false); break;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) login();
        }

        private void login()
        {
            //Kullanıcının sisteme girişinin sağlar:
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }
            cmd.Connection = connect;
            cmd.CommandText = "Select * From Account where Name=@p1 and Password=@p2";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@p1", textUserName.Text);
            cmd.Parameters.AddWithValue("@p2", textPassword.Text);
            data = cmd.ExecuteReader();
            if (data.HasRows)
            {
                data.Read();
                userID = data["ID"].ToString();
                data.Close();
                textUserName.Clear();
                textPassword.Clear();
                BtnMain.Text = "Çıkış";
                linkPassword.Enabled = false;
                linkRegester.Enabled = false;
                condition = "Exit";
                isLogin(true);
                printUserData();
            }
            else
            {
                data.Close();
                MetroFramework.MetroMessageBox.Show(this, "Kullanıcı adı veya şifre hatalı! Böyle bir kullanıcı sistemimizde mevcut değil", "Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            connect.Close();
        }

        private void printUserData()
        {
            //Kullanıcının verilerini "Kişisel Bilgiler" sekmesine yazar.
            User user = new User(userID);
            if (user.getAuthority() == "Üye")
            {
                BtnUser.Enabled = false;
            }
            lblName.Text = user.getName();
            lblBalance.Text = user.getBalance().ToString();
            lblPassword.Text = user.getPassword();
            lblAuthority.Text = user.getAuthority();
            lblGender.Text = user.getGender();
            lblGmail.Text = user.getGmail();
        }

        private void isLogin(bool value)
        {
            switch (value)
            {
                case true:
                    BtnMain.Text = "Çıkış";
                    condition = "Exit";
                    linkPassword.Enabled = false;
                    linkRegester.Enabled = false;

                    BtnPlusGallery.Enabled = true;
                    BtnUser.Enabled = true;
                    BtnUpdate.Enabled = true;
                    BtnJokerMessage.Enabled = true;

                    BtnGameDedektif.Enabled = true;
                    BtnGameFind.Enabled = true;
                    BtnGameHorse.Enabled = true;
                    BtnGameKlavye.Enabled = true;
                    BtnGameMilyoner.Enabled = true;
                    BtnGamePass.Enabled = true;
                    BtnGameWord.Enabled = true;
                    break;

                case false:
                    BtnMain.Text = "Giriş";
                    condition = "Login";
                    linkPassword.Enabled = true;
                    linkRegester.Enabled = true;

                    BtnPlusGallery.Enabled = false;
                    BtnUser.Enabled = false;
                    BtnUpdate.Enabled = false;
                    BtnJokerMessage.Enabled = false;

                    BtnGameDedektif.Enabled = false;
                    BtnGameFind.Enabled = false;
                    BtnGameHorse.Enabled = false;
                    BtnGameKlavye.Enabled = false;
                    BtnGameMilyoner.Enabled = false;
                    BtnGamePass.Enabled = false;
                    BtnGameWord.Enabled = false;

                    lblName.Text = "";
                    lblBalance.Text = "";
                    lblPassword.Text = "";
                    lblAuthority.Text = "";
                    lblGender.Text = "";
                    lblGmail.Text = "";
                    userID = "0";//Kullanıcının ID'si kaybedildi.
                    break;
            }
        }

        private void linkRegester_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            JokerboyRegister register = new JokerboyRegister();
            register.Show();
            this.Hide();
        }

        #endregion

        #region#Ana Sayfa

        private void BtnUser_Click(object sender, EventArgs e)
        {
            JokerUserEdit user = new JokerUserEdit();
            user.Show();
            this.Hide();
        }

        private void BtnPlusGallery_Click(object sender, EventArgs e)
        {
            PlusGallery gallery = new PlusGallery();
            gallery.Show();
            this.Hide();
        }

        #endregion

        #region#Oyunlar

        private void BtnGameDedektif_Click(object sender, EventArgs e)
        {
            GameDetective dedektif = new GameDetective();
            dedektif.Show();
            this.Hide();
        }

        private void BtnGameFind_Click(object sender, EventArgs e)
        {
            GameFindMate bul = new GameFindMate();
            bul.Show();
            this.Hide();
        }

        private void BtnGameKlavye_Click(object sender, EventArgs e)
        {
            GameFastKeyboard klavye = new GameFastKeyboard();
            klavye.Show();
            this.Hide();
        }

        private void BtnGameWord_Click(object sender, EventArgs e)
        {
            GameNameAnimal kelime = new GameNameAnimal();
            kelime.Show();
            this.Hide();
        }

        private void BtnGamePass_Click(object sender, EventArgs e)
        {
            GamePassaparola passa = new GamePassaparola();
            passa.Show();
            this.Hide();
        }

        private void BtnGameMilyoner_Click(object sender, EventArgs e)
        {
            GameMillionaire milyoner = new GameMillionaire();
            milyoner.Show();
            this.Hide();
        }

        private void BtnGameHorse_Click(object sender, EventArgs e)
        {
            GameHorseRace horseRace = new GameHorseRace();
            horseRace.Show();
            this.Hide();
        }

        #endregion

        #region Kişisel Bilgiler

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (textNewName.Text.Trim() != "" || textNewPassword.Text.Trim() != "" || textNewGmail.Text.Trim() != "" || comboNewGender.Text.Trim() != "")
            {
                User user = new User(userID);
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                cmd.Connection = connect;
                cmd.CommandText = "UPDATE Account SET Name=@p1 and Password=@p2 and Gmail=@p3 and Gender=@p4 WHERE ID=@p5";
                cmd.Parameters.Clear();

                if (textNewName.Text.Trim() != "")
                    cmd.Parameters.AddWithValue("@p1", textNewName.Text);
                else
                    cmd.Parameters.AddWithValue("@p1", user.getName());

                if (textNewPassword.Text.Trim() != "")
                    cmd.Parameters.AddWithValue("@p2", textNewPassword.Text);
                else
                    cmd.Parameters.AddWithValue("@p2", user.getPassword());

                if (textNewGmail.Text.Trim() != "")
                    cmd.Parameters.AddWithValue("@p3", textNewGmail.Text);
                else
                    cmd.Parameters.AddWithValue("@p3", user.getGmail());

                if (comboNewGender.Text.Trim() != "")
                    cmd.Parameters.AddWithValue("@p4", comboNewGender.Text);
                else
                    cmd.Parameters.AddWithValue("@p4", user.getGender());

                cmd.Parameters.AddWithValue("@p5", Convert.ToInt16(user.getID()));
                cmd.ExecuteNonQuery();
                connect.Close();

                printUserData();
            }
            else
            {
                MetroMessageBox.Show(this, "Bütün alanlar boş olamaz!", "Uyarı");
            }
        }

        #endregion
    }
}
/*
 
 User user = new User(userID);
                string cmdText = "UPDATE Account SET";
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                cmd.Connection = connect;
                cmd.CommandText = "UPDATE Account SET Name=@p1, Password=@p2, Gmail=@p3, Gender=@p4 WHERE ID=@p5;";

                if (textNewName.Text.Trim() != "")
                    cmd.Parameters.AddWithValue("@p1", textNewName.Text);
                else
                    cmd.Parameters.AddWithValue("@p1", user.getName());

                if (textNewPassword.Text.Trim() != "")
                    cmd.Parameters.AddWithValue("@p2", textNewPassword.Text);
                else
                    cmd.Parameters.AddWithValue("@p2", user.getPassword());

                if (textNewGmail.Text.Trim() != "")
                    cmd.Parameters.AddWithValue("@p3", textNewGmail.Text);
                else
                    cmd.Parameters.AddWithValue("@p3", user.getGmail());

                if (comboNewGender.Text.Trim() != "")
                    cmd.Parameters.AddWithValue("@p4", comboNewGender.Text);
                else
                    cmd.Parameters.AddWithValue("@p4", user.getGender());

                cmd.Parameters.AddWithValue("@p5", userID);
                cmd.ExecuteNonQuery();
                connect.Close();

                printUserData();









User user = new User(userID);
                string cmdText = "UPDATE Account SET";
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                if (textNewName.Text.Trim() != "")
                    cmdText += " Name=@p1,";

                if (textNewPassword.Text.Trim() != "")
                    cmdText += " Password=@p2,";

                if (textNewGmail.Text.Trim() != "")
                    cmdText += " Gmail=@p3,";

                if (comboNewGender.Text.Trim() != "")
                    cmdText += " Gender=@p4,";

                cmdText = cmdText.Remove(cmdText.Length - 1, 1);
                cmdText += " WHERE ID=@p5;";

                cmd.Connection = connect;
                cmd.CommandText = cmdText;
                cmd.Parameters.AddWithValue("@p1", textNewName.Text);
                cmd.Parameters.AddWithValue("@p2", textNewPassword.Text);
                cmd.Parameters.AddWithValue("@p3", textNewGmail.Text);
                cmd.Parameters.AddWithValue("@p4", comboNewGender.Text);
                cmd.Parameters.AddWithValue("@p5", userID);
                int d = cmd.ExecuteNonQuery();
                MessageBox.Show(d.ToString());
                connect.Close();

                printUserData();
 
 */