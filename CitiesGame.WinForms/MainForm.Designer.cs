namespace CitiesGame.WinForms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            lblRule = new Label();
            btnMove = new Button();
            lstUsedCities = new ListBox();
            lblStatus = new Label();
            btnSurrender = new Button();
            btnBackToMenu = new Button();
            btnAbortGame = new Button();
            txtCity = new TextBox();
            SuspendLayout();
            // 
            // lblRule
            // 
            lblRule.AutoSize = true;
            lblRule.BackColor = SystemColors.ActiveCaptionText;
            lblRule.BorderStyle = BorderStyle.Fixed3D;
            lblRule.Font = new Font("Cascadia Mono", 15F);
            lblRule.ForeColor = Color.LimeGreen;
            lblRule.Location = new Point(417, 12);
            lblRule.Name = "lblRule";
            lblRule.Size = new Size(302, 35);
            lblRule.TabIndex = 0;
            lblRule.Text = "Введите любой город";
            // 
            // btnMove
            // 
            btnMove.AutoSize = true;
            btnMove.BackColor = SystemColors.ActiveCaptionText;
            btnMove.Font = new Font("Cascadia Mono", 15F);
            btnMove.ForeColor = Color.LimeGreen;
            btnMove.Location = new Point(470, 158);
            btnMove.Name = "btnMove";
            btnMove.Size = new Size(190, 60);
            btnMove.TabIndex = 2;
            btnMove.Text = "Сделать ход";
            btnMove.UseVisualStyleBackColor = false;
            btnMove.Click += btnMove_Click;
            // 
            // lstUsedCities
            // 
            lstUsedCities.BackColor = SystemColors.MenuText;
            lstUsedCities.Font = new Font("Cascadia Mono", 10F);
            lstUsedCities.ForeColor = Color.LimeGreen;
            lstUsedCities.FormattingEnabled = true;
            lstUsedCities.ItemHeight = 22;
            lstUsedCities.Location = new Point(12, 12);
            lstUsedCities.Name = "lstUsedCities";
            lstUsedCities.Size = new Size(286, 576);
            lstUsedCities.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = SystemColors.ActiveCaptionText;
            lblStatus.BorderStyle = BorderStyle.Fixed3D;
            lblStatus.Font = new Font("Cascadia Mono", 15F);
            lblStatus.ForeColor = Color.LimeGreen;
            lblStatus.Location = new Point(318, 311);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(182, 35);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Статус игры";
            // 
            // btnSurrender
            // 
            btnSurrender.AutoSize = true;
            btnSurrender.BackColor = SystemColors.ActiveCaptionText;
            btnSurrender.Font = new Font("Cascadia Mono", 15F);
            btnSurrender.ForeColor = Color.LimeGreen;
            btnSurrender.Location = new Point(470, 235);
            btnSurrender.Name = "btnSurrender";
            btnSurrender.Size = new Size(190, 60);
            btnSurrender.TabIndex = 5;
            btnSurrender.Text = "Сдаться";
            btnSurrender.UseVisualStyleBackColor = false;
            btnSurrender.Click += btnSurrender_Click;
            // 
            // btnBackToMenu
            // 
            btnBackToMenu.AutoSize = true;
            btnBackToMenu.BackColor = SystemColors.ActiveCaptionText;
            btnBackToMenu.Font = new Font("Cascadia Mono", 15F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnBackToMenu.ForeColor = Color.LimeGreen;
            btnBackToMenu.Location = new Point(687, 524);
            btnBackToMenu.Name = "btnBackToMenu";
            btnBackToMenu.Size = new Size(220, 60);
            btnBackToMenu.TabIndex = 6;
            btnBackToMenu.Text = "Назад";
            btnBackToMenu.UseVisualStyleBackColor = false;
            btnBackToMenu.Click += btnBackToMenu_Click;
            // 
            // btnAbortGame
            // 
            btnAbortGame.AutoSize = true;
            btnAbortGame.BackColor = SystemColors.ActiveCaptionText;
            btnAbortGame.Font = new Font("Cascadia Mono", 15F);
            btnAbortGame.ForeColor = Color.LimeGreen;
            btnAbortGame.Location = new Point(687, 449);
            btnAbortGame.Name = "btnAbortGame";
            btnAbortGame.Size = new Size(220, 60);
            btnAbortGame.TabIndex = 7;
            btnAbortGame.Text = "Прервать игру";
            btnAbortGame.UseVisualStyleBackColor = false;
            btnAbortGame.Click += btnAbortGame_Click;
            // 
            // txtCity
            // 
            txtCity.BackColor = SystemColors.ActiveCaptionText;
            txtCity.BorderStyle = BorderStyle.FixedSingle;
            txtCity.Font = new Font("Cascadia Mono", 12F);
            txtCity.ForeColor = Color.LimeGreen;
            txtCity.Location = new Point(426, 108);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(282, 31);
            txtCity.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonShadow;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(919, 679);
            Controls.Add(txtCity);
            Controls.Add(btnAbortGame);
            Controls.Add(btnBackToMenu);
            Controls.Add(btnSurrender);
            Controls.Add(lblStatus);
            Controls.Add(lstUsedCities);
            Controls.Add(btnMove);
            Controls.Add(lblRule);
            Name = "MainForm";
            Text = "Cities";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRule;
        private Button btnMove;
        private ListBox lstUsedCities;
        private Label lblStatus;
        private Button btnSurrender;
        private Button btnBackToMenu;
        private Button btnAbortGame;
        private TextBox txtCity;
    }
}
