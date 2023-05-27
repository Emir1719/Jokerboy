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
    public partial class GameFastKeyboard : Form
    {
        public GameFastKeyboard()
        {
            InitializeComponent();
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

        }
    }
}
