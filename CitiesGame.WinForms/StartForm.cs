using CitiesGame.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace CitiesGame.WinForms
{
    public partial class StartForm : Form
    {
        public GameSettings GameSettings { get; private set; } = new GameSettings();

        public StartForm()
        {
            InitializeComponent();
            rbVsComputer.FlatStyle = FlatStyle.Flat;
            rb2Players.FlatStyle = FlatStyle.Flat;
            rb3Players.FlatStyle = FlatStyle.Flat;
            rb4Players.FlatStyle = FlatStyle.Flat;

            btnStart.FlatAppearance.BorderColor = Color.White;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 70, 50);
            btnStart.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 50, 35);

            btnExit.FlatAppearance.BorderColor = Color.White;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 70, 50);
            btnExit.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 50, 35);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (rbVsComputer.Checked)
            {
                GameSettings.IsVsComputer = true;
                GameSettings.PlayerCount = 1;
            }
            else if (rb2Players.Checked)
            {
                GameSettings.IsVsComputer = false;
                GameSettings.PlayerCount = 2;
            }
            else if (rb3Players.Checked)
            {
                GameSettings.IsVsComputer = false;
                GameSettings.PlayerCount = 3;
            }
            else if (rb4Players.Checked)
            {
                GameSettings.IsVsComputer = false;
                GameSettings.PlayerCount = 4;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}   
