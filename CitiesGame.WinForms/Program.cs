namespace CitiesGame.WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            while (true)
            {
                using (var startForm = new StartForm())
                {
                    if (startForm.ShowDialog() != DialogResult.OK)
                        break;

                    using (var mainForm = new MainForm(startForm.GameSettings))
                    {
                        mainForm.ShowDialog();

                        if (mainForm.ExitApplicationRequested)
                            break;
                    }
                }
            }
        }
    }
}