using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Jokerboy
{
    public partial class PlusGallery : Form
    {
        string PhotoSavePath, Yıl, Ay; //PhotoPath, PhotoName
        int Move1, PhotoCount = 0;
        int Mouse_X;
        int Mouse_Y;

        public PlusGallery()
        {
            InitializeComponent();
        }

        #region#FormunHareketKodları
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Move1 = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move1 == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Move1 = 0;
        }

        #endregion

        private void BtnComeBack_Click(object sender, EventArgs e)
        {
            Jokerboy.TabNo = 2;
            Jokerboy joker = new Jokerboy();
            joker.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                PhotoSavePath = folderBrowser.SelectedPath;
                linkLabel1.Text = PhotoSavePath;
                linkLabel2.Enabled = true;
            }
            lblPictureCount.Text = "0";
            progressBar1.Value = 0;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void WhichMonth(string Month)
        {
            switch (Month)
            {
                case "1": Ay = "Ocak"; break;
                case "2": Ay = "Şubat"; break;
                case "3": Ay = "Mart"; break;
                case "4": Ay = "Nisan"; break;
                case "5": Ay = "Mayıs"; break;
                case "6": Ay = "Haziran"; break;
                case "7": Ay = "Temmuz"; break;
                case "8": Ay = "Ağustos"; break;
                case "9": Ay = "Eylül"; break;
                case "10": Ay = "Ekim"; break;
                case "11": Ay = "Kasım"; break;
                case "12": Ay = "Aralık"; break;
            }
        }

        private void MoveOrCopy(string file1, string file2)
        {
            if (!File.Exists(file2))
            {
                if (radioMove.Checked == true)
                {
                    File.Move(file1, file2);
                }
                else if (radioCopy.Checked == true)
                {
                    File.Copy(file1, file2);
                }
                progressBar1.Value++;
                lblPictureCount.Text = progressBar1.Value.ToString();
                radioMove.Enabled = true;
                radioCopy.Enabled = true;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            //dialog.Filter = "Resim ve Müzik | (*.mp4|*.png|*.jpg)";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string[] FileName = dialog.SafeFileNames;
                string[] FilePath = dialog.FileNames;
                radioMove.Enabled = false;
                radioCopy.Enabled = false;
                foreach (string Pictures in dialog.FileNames)
                {
                    PhotoCount++;
                }
                progressBar1.Maximum = PhotoCount;

                int i = 0;
                foreach (string Pictures in dialog.FileNames)//yolu ve ismi
                {
                    FileInfo info = new FileInfo(FilePath[i]);
                    DateTime date = new DateTime();
                    date = Convert.ToDateTime(info.CreationTime.ToString());
                    Yıl = date.Year.ToString();
                    WhichMonth(date.Month.ToString());
                    if (!Directory.Exists(@PhotoSavePath + @"\PlusGallery"))
                    {
                        Directory.CreateDirectory(@PhotoSavePath + @"\PlusGallery");
                    }
                    if (!Directory.Exists(@PhotoSavePath + @"\PlusGallery" + @"\" + Yıl.ToString()))
                    {
                        Directory.CreateDirectory(@PhotoSavePath + @"\PlusGallery" + @"\" + Yıl.ToString());
                    }
                    if (!Directory.Exists(@PhotoSavePath + @"\PlusGallery" + @"\" + Yıl.ToString() + @"\" + Ay.ToString()))
                    {
                        Directory.CreateDirectory(@PhotoSavePath + @"\PlusGallery" + @"\" + Yıl.ToString() + @"\" + Ay.ToString());
                    }
                    MoveOrCopy(@Pictures, @PhotoSavePath + @"\PlusGallery" + @"\" + Yıl.ToString() + @"\" + Ay.ToString() + @"\" +FileName[i]);
                    i++;
                }
                MetroFramework.MetroMessageBox.Show(this, "Resimleriniz Başarıyla Yüklenmiştir. Aynı Resimler Varsa Onları Yüklemedik.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
