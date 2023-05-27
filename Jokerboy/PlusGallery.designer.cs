namespace Jokerboy
{
    partial class PlusGallery
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlusGallery));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblPictureCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.radioMove = new System.Windows.Forms.RadioButton();
            this.radioCopy = new System.Windows.Forms.RadioButton();
            this.iTalk_ChatBubble_R3 = new iTalk.iTalk_ChatBubble_R();
            this.iTalk_ChatBubble_L3 = new iTalk.iTalk_ChatBubble_L();
            this.BtnComeBack = new System.Windows.Forms.Button();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.iTalk_ChatBubble_R2 = new iTalk.iTalk_ChatBubble_R();
            this.iTalk_ChatBubble_L2 = new iTalk.iTalk_ChatBubble_L();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.iTalk_ChatBubble_R1 = new iTalk.iTalk_ChatBubble_R();
            this.iTalk_ChatBubble_L1 = new iTalk.iTalk_ChatBubble_L();
            this.monoFlat_Label1 = new MonoFlat.MonoFlat_Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblPictureCount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.radioMove);
            this.panel1.Controls.Add(this.radioCopy);
            this.panel1.Controls.Add(this.iTalk_ChatBubble_R3);
            this.panel1.Controls.Add(this.iTalk_ChatBubble_L3);
            this.panel1.Controls.Add(this.BtnComeBack);
            this.panel1.Controls.Add(this.linkLabel2);
            this.panel1.Controls.Add(this.iTalk_ChatBubble_R2);
            this.panel1.Controls.Add(this.iTalk_ChatBubble_L2);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.iTalk_ChatBubble_R1);
            this.panel1.Controls.Add(this.iTalk_ChatBubble_L1);
            this.panel1.Controls.Add(this.monoFlat_Label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Calibri", 17F);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1218, 735);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1218, 33);
            this.panel2.TabIndex = 40;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(8, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(74, 65);
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // lblPictureCount
            // 
            this.lblPictureCount.AutoSize = true;
            this.lblPictureCount.BackColor = System.Drawing.Color.Transparent;
            this.lblPictureCount.Font = new System.Drawing.Font("Calibri", 17F);
            this.lblPictureCount.Location = new System.Drawing.Point(278, 667);
            this.lblPictureCount.Name = "lblPictureCount";
            this.lblPictureCount.Size = new System.Drawing.Size(23, 28);
            this.lblPictureCount.TabIndex = 38;
            this.lblPictureCount.Text = "?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 17F);
            this.label1.Location = new System.Drawing.Point(61, 667);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 28);
            this.label1.TabIndex = 37;
            this.label1.Text = "Yüklenen Resim Sayısı:";
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.Lime;
            this.progressBar1.Location = new System.Drawing.Point(64, 698);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1136, 20);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 36;
            // 
            // radioMove
            // 
            this.radioMove.AutoSize = true;
            this.radioMove.BackColor = System.Drawing.Color.White;
            this.radioMove.Location = new System.Drawing.Point(183, 433);
            this.radioMove.Name = "radioMove";
            this.radioMove.Size = new System.Drawing.Size(93, 32);
            this.radioMove.TabIndex = 35;
            this.radioMove.Text = "Taşıma";
            this.radioMove.UseVisualStyleBackColor = false;
            // 
            // radioCopy
            // 
            this.radioCopy.AutoSize = true;
            this.radioCopy.BackColor = System.Drawing.Color.White;
            this.radioCopy.Checked = true;
            this.radioCopy.Location = new System.Drawing.Point(40, 433);
            this.radioCopy.Name = "radioCopy";
            this.radioCopy.Size = new System.Drawing.Size(132, 32);
            this.radioCopy.TabIndex = 34;
            this.radioCopy.TabStop = true;
            this.radioCopy.Text = "Kopyalama";
            this.radioCopy.UseVisualStyleBackColor = false;
            // 
            // iTalk_ChatBubble_R3
            // 
            this.iTalk_ChatBubble_R3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iTalk_ChatBubble_R3.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_ChatBubble_R3.BubbleColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.iTalk_ChatBubble_R3.DrawBubbleArrow = true;
            this.iTalk_ChatBubble_R3.Font = new System.Drawing.Font("Calibri", 17F);
            this.iTalk_ChatBubble_R3.Location = new System.Drawing.Point(815, 81);
            this.iTalk_ChatBubble_R3.Name = "iTalk_ChatBubble_R3";
            this.iTalk_ChatBubble_R3.Size = new System.Drawing.Size(388, 56);
            this.iTalk_ChatBubble_R3.TabIndex = 32;
            this.iTalk_ChatBubble_R3.Text = "PlusGallery ne işe yarıyor?";
            // 
            // iTalk_ChatBubble_L3
            // 
            this.iTalk_ChatBubble_L3.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_ChatBubble_L3.BubbleColor = System.Drawing.Color.White;
            this.iTalk_ChatBubble_L3.DrawBubbleArrow = true;
            this.iTalk_ChatBubble_L3.Font = new System.Drawing.Font("Calibri", 17F);
            this.iTalk_ChatBubble_L3.Location = new System.Drawing.Point(19, 143);
            this.iTalk_ChatBubble_L3.Name = "iTalk_ChatBubble_L3";
            this.iTalk_ChatBubble_L3.Size = new System.Drawing.Size(447, 101);
            this.iTalk_ChatBubble_L3.TabIndex = 31;
            this.iTalk_ChatBubble_L3.Text = "PlusGallery, resimlerinizin hangi yılda ve hangi ayda çekildiğine göre klasör olu" +
    "şturup resimlerinizi uygun klasöre yerleştirir.";
            // 
            // BtnComeBack
            // 
            this.BtnComeBack.BackColor = System.Drawing.Color.Transparent;
            this.BtnComeBack.FlatAppearance.BorderSize = 0;
            this.BtnComeBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.BtnComeBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.BtnComeBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnComeBack.Font = new System.Drawing.Font("Calibri", 15F);
            this.BtnComeBack.ForeColor = System.Drawing.Color.Transparent;
            this.BtnComeBack.Image = ((System.Drawing.Image)(resources.GetObject("BtnComeBack.Image")));
            this.BtnComeBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnComeBack.Location = new System.Drawing.Point(14, 671);
            this.BtnComeBack.Name = "BtnComeBack";
            this.BtnComeBack.Size = new System.Drawing.Size(42, 47);
            this.BtnComeBack.TabIndex = 30;
            this.BtnComeBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnComeBack.UseVisualStyleBackColor = false;
            this.BtnComeBack.Click += new System.EventHandler(this.BtnComeBack_Click);
            // 
            // linkLabel2
            // 
            this.linkLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.linkLabel2.Enabled = false;
            this.linkLabel2.Font = new System.Drawing.Font("Calibri", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.linkLabel2.LinkColor = System.Drawing.Color.Navy;
            this.linkLabel2.Location = new System.Drawing.Point(817, 507);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(44, 28);
            this.linkLabel2.TabIndex = 9;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Seç";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // iTalk_ChatBubble_R2
            // 
            this.iTalk_ChatBubble_R2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iTalk_ChatBubble_R2.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_ChatBubble_R2.BubbleColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.iTalk_ChatBubble_R2.DrawBubbleArrow = true;
            this.iTalk_ChatBubble_R2.Font = new System.Drawing.Font("Calibri", 17F);
            this.iTalk_ChatBubble_R2.Location = new System.Drawing.Point(812, 476);
            this.iTalk_ChatBubble_R2.Name = "iTalk_ChatBubble_R2";
            this.iTalk_ChatBubble_R2.Size = new System.Drawing.Size(388, 69);
            this.iTalk_ChatBubble_R2.TabIndex = 8;
            this.iTalk_ChatBubble_R2.Text = "Kaydedeceğin resimlerim:";
            // 
            // iTalk_ChatBubble_L2
            // 
            this.iTalk_ChatBubble_L2.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_ChatBubble_L2.BubbleColor = System.Drawing.Color.White;
            this.iTalk_ChatBubble_L2.DrawBubbleArrow = true;
            this.iTalk_ChatBubble_L2.Font = new System.Drawing.Font("Calibri", 17F);
            this.iTalk_ChatBubble_L2.Location = new System.Drawing.Point(20, 399);
            this.iTalk_ChatBubble_L2.Name = "iTalk_ChatBubble_L2";
            this.iTalk_ChatBubble_L2.Size = new System.Drawing.Size(447, 73);
            this.iTalk_ChatBubble_L2.TabIndex = 7;
            this.iTalk_ChatBubble_L2.Text = "Hangi resimlerinizi nasıl kaydedelim?";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.linkLabel1.Font = new System.Drawing.Font("Calibri", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.linkLabel1.LinkColor = System.Drawing.Color.Navy;
            this.linkLabel1.Location = new System.Drawing.Point(820, 354);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(44, 28);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Seç";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // iTalk_ChatBubble_R1
            // 
            this.iTalk_ChatBubble_R1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iTalk_ChatBubble_R1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_ChatBubble_R1.BubbleColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.iTalk_ChatBubble_R1.DrawBubbleArrow = true;
            this.iTalk_ChatBubble_R1.Font = new System.Drawing.Font("Calibri", 17F);
            this.iTalk_ChatBubble_R1.Location = new System.Drawing.Point(815, 321);
            this.iTalk_ChatBubble_R1.Name = "iTalk_ChatBubble_R1";
            this.iTalk_ChatBubble_R1.Size = new System.Drawing.Size(388, 71);
            this.iTalk_ChatBubble_R1.TabIndex = 5;
            this.iTalk_ChatBubble_R1.Text = "Resimlerimi bu konuma kaydet: ";
            // 
            // iTalk_ChatBubble_L1
            // 
            this.iTalk_ChatBubble_L1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_ChatBubble_L1.BubbleColor = System.Drawing.Color.White;
            this.iTalk_ChatBubble_L1.DrawBubbleArrow = true;
            this.iTalk_ChatBubble_L1.Font = new System.Drawing.Font("Calibri", 17F);
            this.iTalk_ChatBubble_L1.Location = new System.Drawing.Point(20, 258);
            this.iTalk_ChatBubble_L1.Name = "iTalk_ChatBubble_L1";
            this.iTalk_ChatBubble_L1.Size = new System.Drawing.Size(447, 56);
            this.iTalk_ChatBubble_L1.TabIndex = 3;
            this.iTalk_ChatBubble_L1.Text = "Resimleriniz nereye kaydedilecek?";
            // 
            // monoFlat_Label1
            // 
            this.monoFlat_Label1.AutoSize = true;
            this.monoFlat_Label1.BackColor = System.Drawing.Color.Transparent;
            this.monoFlat_Label1.Font = new System.Drawing.Font("Segoe UI", 23F);
            this.monoFlat_Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.monoFlat_Label1.Location = new System.Drawing.Point(76, 57);
            this.monoFlat_Label1.Name = "monoFlat_Label1";
            this.monoFlat_Label1.Size = new System.Drawing.Size(169, 42);
            this.monoFlat_Label1.TabIndex = 1;
            this.monoFlat_Label1.Text = "PlusGallery";
            // 
            // PlusGallery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1218, 735);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PlusGallery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlusGallery";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MonoFlat.MonoFlat_Label monoFlat_Label1;
        private iTalk.iTalk_ChatBubble_L iTalk_ChatBubble_L1;
        private iTalk.iTalk_ChatBubble_L iTalk_ChatBubble_L2;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private iTalk.iTalk_ChatBubble_R iTalk_ChatBubble_R2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private iTalk.iTalk_ChatBubble_R iTalk_ChatBubble_R1;
        private System.Windows.Forms.Button BtnComeBack;
        private iTalk.iTalk_ChatBubble_R iTalk_ChatBubble_R3;
        private iTalk.iTalk_ChatBubble_L iTalk_ChatBubble_L3;
        private System.Windows.Forms.RadioButton radioMove;
        private System.Windows.Forms.RadioButton radioCopy;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblPictureCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
    }
}

