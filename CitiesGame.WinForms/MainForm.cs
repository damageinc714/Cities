using CitiesGame.Core.Game;
using CitiesGame.Core.Models;
using CitiesGame.Core.Services;
using System;

namespace CitiesGame.WinForms
{
    public partial class MainForm : Form
    {
        private readonly CityDictionary _dictionary;
        private readonly GameEngine _gameEngine;
        private readonly GameSettings _settings;
        private readonly Random _random = new();

        private bool _gameAborted = false;

        public bool ExitApplicationRequested { get; private set; } = false;

        public MainForm(GameSettings settings)
        {
            InitializeComponent();

            btnMove.FlatAppearance.BorderColor = Color.White;
            btnMove.FlatStyle = FlatStyle.Flat;
            btnMove.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 70, 50);
            btnMove.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 50, 35);

            btnSurrender.FlatAppearance.BorderColor = Color.White;
            btnSurrender.FlatStyle = FlatStyle.Flat;
            btnSurrender.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 70, 50);
            btnSurrender.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 50, 35);

            btnAbortGame.FlatAppearance.BorderColor = Color.White;
            btnAbortGame.FlatStyle = FlatStyle.Flat;
            btnAbortGame.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 70, 50);
            btnAbortGame.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 50, 35);

            btnBackToMenu.FlatAppearance.BorderColor = Color.White;
            btnBackToMenu.FlatStyle = FlatStyle.Flat;
            btnBackToMenu.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 70, 50);
            btnBackToMenu.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 50, 35);

            _settings = settings;
            _dictionary = new CityDictionary();
            _gameEngine = new GameEngine(_dictionary);

            this.Load += MainForm_Load;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                _gameAborted = false;

                string filePath = Path.Combine(Application.StartupPath, "Data", "cities.txt");

                _dictionary.LoadFromFile(filePath);

                int totalPlayers = _settings.IsVsComputer ? 2 : _settings.PlayerCount;
                _gameEngine.StartNewGame(totalPlayers);

                UpdateTurnLabel();
                lblStatus.Text = $"Загружено городов: {_dictionary.Count}";

                txtCity.Enabled = true;
                btnMove.Enabled = true;
                btnSurrender.Enabled = true;
                btnAbortGame.Enabled = true;
                btnBackToMenu.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка загрузки списка городов:\n{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            var enteredCity = txtCity.Text.Trim();
            var result = _gameEngine.TryMakeMove(enteredCity);

            lblStatus.Text = result.Message;

            if (!result.Success)
                return;

            if (_settings.IsVsComputer)
            {
                if (result.CurrentPlayerIndex == 0)
                    lstUsedCities.Items.Add($"Вы: {enteredCity}");
                else
                    lstUsedCities.Items.Add($"Компьютер: {enteredCity}");
            }
            else
            {
                lstUsedCities.Items.Add($"Игрок {result.CurrentPlayerIndex + 1}: {enteredCity}");
            }

            txtCity.Clear();
            txtCity.Focus();

            if (result.IsGameOver)
            {
                EndGame(result.Message);
                return;
            }

            UpdateTurnLabel();

            if (_settings.IsVsComputer && _gameEngine.State.CurrentPlayerIndex == 1)
            {
                MakeComputerMove();
            }
        }

        private void btnSurrender_Click(object sender, EventArgs e)
        {
            var result = _gameEngine.SurrenderCurrentPlayer(_settings.IsVsComputer);
            EndGame(result.Message);
        }

        private void btnAbortGame_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Прервать текущую игру?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            _gameAborted = true;
            _gameEngine.FinishGame();

            lblStatus.Text = "Игра была прервана.";
            lblRule.Text = "Игра окончена.";

            txtCity.Enabled = false;
            btnMove.Enabled = false;
            btnSurrender.Enabled = false;
            btnAbortGame.Enabled = false;
            btnBackToMenu.Enabled = true;

            MessageBox.Show(
                "Игра прервана.\r\nПобедители не определены.",
                "Прерывание игры",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            if (!btnBackToMenu.Enabled)
                return;

            Close();
        }

        private void UpdateTurnLabel()
        {
            if (_gameEngine.State.IsGameOver)
            {
                lblRule.Text = "Игра окончена.";
                return;
            }

            if (_settings.IsVsComputer)
            {
                if (_gameEngine.State.CurrentPlayerIndex == 0)
                {
                    if (_gameEngine.State.RequiredLetter == '\0')
                        lblRule.Text = "Ваш ход.\r\nВведите любой город";
                    else
                        lblRule.Text = $"Ваш ход.\r\nВведите город на букву '{char.ToUpper(_gameEngine.State.RequiredLetter)}'";
                }
                else
                {
                    lblRule.Text = "Ход компьютера...";
                }
            }
            else
            {
                int playerNumber = _gameEngine.State.CurrentPlayerIndex + 1;

                if (_gameEngine.State.RequiredLetter == '\0')
                    lblRule.Text = $"Ход игрока {playerNumber}.\r\nВведите любой город";
                else
                    lblRule.Text = $"Ход игрока {playerNumber}.\r\nВведите город на букву '{char.ToUpper(_gameEngine.State.RequiredLetter)}'";
            }
        }

        private void MakeComputerMove()
        {
            if (_gameAborted)
                return;

            char requiredLetter = _gameEngine.State.RequiredLetter;

            var possibleCities = _dictionary.GetCitiesByLetter(requiredLetter)
                .Where(c => !_gameEngine.State.UsedCities.Contains(c))
                .ToList();

            if (possibleCities.Count == 0)
            {
                _gameEngine.FinishGame();
                EndGame("Компьютер не смог назвать город.\r\nВы победили!");
                return;
            }

            string computerCity = possibleCities[_random.Next(possibleCities.Count)];

            var result = _gameEngine.TryMakeMove(computerCity);

            if (!result.Success)
            {
                EndGame($"Ошибка хода компьютера: {result.Message}");
                return;
            }

            lstUsedCities.Items.Add($"Компьютер: {char.ToUpper(computerCity[0]) + computerCity.Substring(1)}");

            if (result.IsGameOver)
            {
                EndGame(result.Message);
                return;
            }

            lblStatus.Text = $"Компьютер выбрал: {char.ToUpper(computerCity[0]) + computerCity.Substring(1)}\r\n{result.Message}";
            UpdateTurnLabel();
        }

        private void EndGame(string message)
        {
            if (_gameAborted)
                return;

            lblStatus.Text = message;
            lblRule.Text = "Игра окончена.";

            txtCity.Enabled = false;
            btnMove.Enabled = false;
            btnSurrender.Enabled = false;
            btnAbortGame.Enabled = false;
            btnBackToMenu.Enabled = true;

            MessageBox.Show(
                message + "\r\n\r\nНажмите «Назад», чтобы начать новую игру.",
                "Конец игры",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}