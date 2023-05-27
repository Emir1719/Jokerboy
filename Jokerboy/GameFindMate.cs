using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jokerboy
{
    public partial class GameFindMate : Form
    {
        public GameFindMate()
        {
            InitializeComponent();
        }

        private void OyunEsiniBul_Load(object sender, EventArgs e)
        {

        }

        private void BtnGeri_Click(object sender, EventArgs e)
        {
            Jokerboy.TabNo = 3;
            Jokerboy joker = new Jokerboy();
            joker.Show();
            this.Hide();
        }
    }
}
