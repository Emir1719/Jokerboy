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
        public enum FormSize {
            small, medium, large
        }

        public enum ColorTheme {
            orange, blue, green, red
        }

        private String title, content;
        private FormSize formSize;
        private ColorTheme colorTheme;

        public JokerMessageBox()
        {
            InitializeComponent();
            setSize(FormSize.medium);
            setColorTheme(ColorTheme.orange);
        }

        public JokerMessageBox(string title, string content)
        {
            InitializeComponent();

            setTitle(title);
            setContent(content);
            setSize(FormSize.medium);
            setColorTheme(ColorTheme.orange);
        }

        public JokerMessageBox(FormSize size, string title, string content)
        {
            InitializeComponent();

            setTitle(title);
            setContent(content);
            setSize(size);
            setColorTheme(ColorTheme.orange);
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

        public void setSize(FormSize size)
        {
            this.formSize = size;

            switch (formSize)
            {
                case FormSize.small:
                    this.Width = 500;
                    this.Height = 300;
                    break;
                case FormSize.medium:
                    this.Width = 700;
                    this.Height = 450;
                    break;
                case FormSize.large:
                    this.Width = 900;
                    this.Height = 560;
                    break;
            }
        }

        public void setColorTheme(ColorTheme colorTheme) 
        {
            this.colorTheme = colorTheme;

            switch (this.colorTheme)
            {
                case ColorTheme.orange:
                    lblTitle.ForeColor = Color.FromArgb(255, 128, 0);
                    bottomLine.BackColor = Color.Chocolate;
                    break;
                case ColorTheme.blue:
                    lblTitle.ForeColor = Color.DeepSkyBlue;
                    bottomLine.BackColor = Color.Aqua;
                    break;
                case ColorTheme.green:
                    lblTitle.ForeColor = Color.SeaGreen;
                    bottomLine.BackColor = Color.LimeGreen;
                    break;
                case ColorTheme.red:
                    lblTitle.ForeColor = Color.Red;
                    bottomLine.BackColor = Color.Red;
                    break;
            }
        }
    }
}
