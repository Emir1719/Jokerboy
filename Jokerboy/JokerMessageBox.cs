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
        private String title, content;

        public JokerMessageBox()
        {
            InitializeComponent();
        }

        public JokerMessageBox(string title, string content)
        {
            InitializeComponent();

            this.title = title;
            this.content = content;
        }

        private void JokerMessageBox_Load(object sender, EventArgs e)
        {
            lblTitle.Text = title;
            lblContent.Text = content;
        }

        public void setTitle(String title)
        {
            this.title = title;
        }

        public void setContent(String content)
        {
            this.content = content;
        }
    }
}
