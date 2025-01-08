namespace hwashu_ai
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            MsgLabel = new Label();
            panel1 = new Panel();
            MsgTitle = new Label();
            EnterMessage = new Button();
            TextMsg = new TextBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel2, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Location = new Point(0, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(390, 447);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(TextMsg);
            panel2.Controls.Add(EnterMessage);
            panel2.Controls.Add(MsgTitle);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 226);
            panel2.Name = "panel2";
            panel2.Size = new Size(384, 218);
            panel2.TabIndex = 2;
            // 
            // MsgLabel
            // 
            MsgLabel.BackColor = SystemColors.Window;
            MsgLabel.BorderStyle = BorderStyle.Fixed3D;
            MsgLabel.Location = new Point(9, 27);
            MsgLabel.Name = "MsgLabel";
            MsgLabel.Size = new Size(367, 175);
            MsgLabel.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(MsgLabel);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(384, 217);
            panel1.TabIndex = 1;
            // 
            // MsgTitle
            // 
            MsgTitle.Location = new Point(27, 35);
            MsgTitle.Name = "MsgTitle";
            MsgTitle.Size = new Size(74, 23);
            MsgTitle.TabIndex = 3;
            MsgTitle.Text = "請輸入問題";
            // 
            // EnterMessage
            // 
            EnterMessage.Location = new Point(108, 153);
            EnterMessage.Name = "EnterMessage";
            EnterMessage.Size = new Size(148, 45);
            EnterMessage.TabIndex = 0;
            EnterMessage.Text = "確認";
            EnterMessage.UseVisualStyleBackColor = true;
            EnterMessage.Click += EnterMessage_Click;
            // 
            // TextMsg
            // 
            TextMsg.AcceptsReturn = true;
            TextMsg.Location = new Point(27, 61);
            TextMsg.Multiline = true;
            TextMsg.Name = "TextMsg";
            TextMsg.Size = new Size(330, 86);
            TextMsg.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(308, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(49, 43);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Location = new Point(9, 4);
            label1.Name = "label1";
            label1.Size = new Size(74, 23);
            label1.TabIndex = 4;
            label1.Text = "AI回答";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(391, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "樺塑AI資料庫";
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button EnterMessage;
        private Panel panel1;
        private TextBox TextMsg;
        private Panel panel2;
        private Label MsgLabel;
        private Label MsgTitle;
        private PictureBox pictureBox1;
        private Label label1;
    }
}
