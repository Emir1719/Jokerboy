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
    public partial class JokerMessageBox : Form
    {
        public JokerMessageBox()
        {
            InitializeComponent();
        }

        public JokerMessageBox(string title, string content)
        {
            InitializeComponent();

            lblTitle.Text = title;
            lblContent.Text = content;
        }
    }
}
