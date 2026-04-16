namespace CitiesGame.WinForms
{
    partial class StartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            lblTitle = new Label();
            rbVsComputer = new RadioButton();
            rb2Players = new RadioButton();
            rb3Players = new RadioButton();
            rb4Players = new RadioButton();
            btnStart = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = SystemColors.ActiveCaptionText;
            lblTitle.BorderStyle = BorderStyle.Fixed3D;
            lblTitle.Font = new Font("Cascadia Mono", 25.2F);
            lblTitle.ForeColor = Color.LimeGreen;
            lblTitle.Location = new Point(63, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(501, 58);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Выберите режим игры";
            // 
            // rbVsComputer
            // 
            rbVsComputer.AutoSize = true;
            rbVsComputer.BackColor = SystemColors.ActiveCaptionText;
            rbVsComputer.Font = new Font("Cascadia Mono", 15F);
            rbVsComputer.ForeColor = Color.LimeGreen;
            rbVsComputer.Location = new Point(102, 101);
            rbVsComputer.Name = "rbVsComputer";
            rbVsComputer.Size = new Size(306, 37);
            rbVsComputer.TabIndex = 1;
            rbVsComputer.TabStop = true;
            rbVsComputer.Text = "Игра с компьютером";
            rbVsComputer.UseVisualStyleBackColor = false;
            // 
            // rb2Players
            // 
            rb2Players.AutoSize = true;
            rb2Players.BackColor = SystemColors.ActiveCaptionText;
            rb2Players.Font = new Font("Cascadia Mono", 15F);
            rb2Players.ForeColor = Color.LimeGreen;
            rb2Players.Location = new Point(102, 145);
            rb2Players.Name = "rb2Players";
            rb2Players.Size = new Size(156, 37);
            rb2Players.TabIndex = 2;
            rb2Players.TabStop = true;
            rb2Players.Text = "2 игрока";
            rb2Players.UseVisualStyleBackColor = false;
            // 
            // rb3Players
            // 
            rb3Players.AutoSize = true;
            rb3Players.BackColor = SystemColors.ActiveCaptionText;
            rb3Players.Font = new Font("Cascadia Mono", 15F);
            rb3Players.ForeColor = Color.LimeGreen;
            rb3Players.Location = new Point(102, 189);
            rb3Players.Name = "rb3Players";
            rb3Players.Size = new Size(156, 37);
            rb3Players.TabIndex = 3;
            rb3Players.TabStop = true;
            rb3Players.Text = "3 игрока";
            rb3Players.UseVisualStyleBackColor = false;
            // 
            // rb4Players
            // 
            rb4Players.AutoSize = true;
            rb4Players.BackColor = SystemColors.ActiveCaptionText;
            rb4Players.FlatAppearance.BorderColor = Color.LimeGreen;
            rb4Players.FlatAppearance.CheckedBackColor = Color.LimeGreen;
            rb4Players.FlatAppearance.MouseDownBackColor = Color.LimeGreen;
            rb4Players.FlatAppearance.MouseOverBackColor = Color.LimeGreen;
            rb4Players.Font = new Font("Cascadia Mono", 15F);
            rb4Players.ForeColor = Color.LimeGreen;
            rb4Players.Location = new Point(102, 233);
            rb4Players.Name = "rb4Players";
            rb4Players.Size = new Size(156, 37);
            rb4Players.TabIndex = 4;
            rb4Players.TabStop = true;
            rb4Players.Text = "4 игрока";
            rb4Players.UseVisualStyleBackColor = false;
            // 
            // btnStart
            // 
            btnStart.BackColor = SystemColors.ActiveCaptionText;
            btnStart.FlatAppearance.BorderColor = Color.LimeGreen;
            btnStart.FlatAppearance.MouseDownBackColor = Color.LimeGreen;
            btnStart.FlatAppearance.MouseOverBackColor = Color.LimeGreen;
            btnStart.Font = new Font("Cascadia Mono", 15F);
            btnStart.ForeColor = Color.LimeGreen;
            btnStart.Location = new Point(83, 288);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(188, 65);
            btnStart.TabIndex = 5;
            btnStart.Text = "Начать";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = SystemColors.ActiveCaptionText;
            btnExit.Font = new Font("Cascadia Mono", 15F);
            btnExit.ForeColor = Color.LimeGreen;
            btnExit.Location = new Point(352, 288);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(165, 65);
            btnExit.TabIndex = 6;
            btnExit.Text = "Выход";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // StartForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(615, 396);
            Controls.Add(btnExit);
            Controls.Add(btnStart);
            Controls.Add(rb4Players);
            Controls.Add(rb3Players);
            Controls.Add(rb2Players);
            Controls.Add(rbVsComputer);
            Controls.Add(lblTitle);
            Name = "StartForm";
            Text = "Cities";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private RadioButton rbVsComputer;
        private RadioButton rb2Players;
        private RadioButton rb3Players;
        private RadioButton rb4Players;
        private Button btnStart;
        private Button btnExit;
    }
}