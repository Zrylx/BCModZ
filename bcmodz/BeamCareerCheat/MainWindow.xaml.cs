using MaterialDesignThemes.Wpf;
using MaterialDesignColors;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Media.Animation;
using Microsoft.VisualBasic.FileIO;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Linq.Expressions;

namespace BeamCareerCheat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PaletteHelper paletteHelper = new PaletteHelper();
        private const string version = "1.1";
        public MainWindow()
        {
            InitializeComponent();


            Theme theme = new();
            theme.SetDarkTheme();
            theme.SetPrimaryColor(Color.FromArgb(0xFF, 0x71, 0x60, 0xE8));
            paletteHelper.SetTheme(theme);
            logger.log("User ran application");

            // on the first run of the application
            if (Properties.Settings.Default.IsFirstRun)
            {
                logger.log("User ran the application for the first time");
                try
                {
                    // attempt to create shortcut in startmenu folder
                    string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BCModZ.exe");
                    string startMenuPath = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.StartMenu),
                        "Programs", "BCModZ.lnk"
                    );

                    logger.log("Attempting to create Start Menu shortcut...");

                    if (!System.IO.File.Exists(startMenuPath))
                    {
                        string psScript = $@"
                        $WshShell = New-Object -ComObject WScript.Shell
                        $Shortcut = $WshShell.CreateShortcut('{startMenuPath}')
                        $Shortcut.TargetPath = '{exePath}'
                        $Shortcut.WorkingDirectory = '{Path.GetDirectoryName(exePath)}'
                        $Shortcut.Save()";

                        // execute PowerShell script to create shortcut
                        var processStartInfo = new ProcessStartInfo("powershell.exe", psScript)
                        {
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        };
                        var process = Process.Start(processStartInfo);
                        process.WaitForExit();

                        logger.log($"Shortcut created successfully at: {startMenuPath}");
                    }
                    else
                    {
                        logger.log("Shortcut already exists, skipping creation.");
                    }
                }
                catch (Exception ex)
                {
                    logger.log($"Error creating Start Menu shortcut: {ex.Message}");
                }

                MessageBox.Show("IMPORTANT: Before making any modifications to career mode, please back" +
                    " up your career profile folder. A tutorial on how to do this is available on the Zrylx " +
                    "Solutions Discord server and YouTube channel. Please note that BCModZ is designed to " +
                    "function with BeamNG.drive version 0.30 and above. Usage with versions below 0.30 is " +
                    "considered experimental and is at your own risk.", "BCModZ", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                Properties.Settings.Default.IsFirstRun = false;
                Properties.Settings.Default.Save();
            }

            // check for outdated version
            string latestVersion = "https://pastebin.com/raw/U8K8bYP9";

            CheckUpdate(version, latestVersion);
        }

        private async void CheckUpdate(string currentVersion, string newVersion)
        {
            try
            {
                using HttpClient client = new();
                string latestVersion = await client.GetStringAsync(newVersion);
                latestVersion = latestVersion.Trim();

                if (currentVersion != latestVersion)
                {
                    MessageBox.Show($"This version of BCModZ is outdated and may be unstable. \n\nLatest Version: {latestVersion}\nCurrent Version: {currentVersion} " +
                        $"\n\nPlease download the latest version of the application on the Zrylx Solutions website.", "BCModZ",
                        MessageBoxButton.OK, MessageBoxImage.Warning);

                    logger.log("Application is outdated. Current version: " + currentVersion + ", latest version: " + latestVersion);
                    // i should probably make a function to do this instead :p
                    logger.log($"MSB: This version of BCModZ is outdated and may be unstable. \n\nLatest Version: {latestVersion}\nCurrent Version: {currentVersion}. \n\nPlease download the latest version of the application on the Zrylx Solutions website.");
                }
            }
            catch (Exception ex)
            {
                logger.log("Failed to check for updates. Error: " + ex.Message);

                MessageBox.Show($"Failed to check for updates. Error: {ex.Message}", "BCModZ", MessageBoxButton.OK, MessageBoxImage.Error);
                logger.log($"MSB: Failed to check for updates. Error: {ex.Message}");
            }
        }

        // window dragging
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            // apply what option the user selected and the value the user entered
            
            if (double.TryParse(tbAmount.Text, out double value))
            {
                if (cboxOptions.SelectedItem is ComboBoxItem selectedItem)
                {
                    playerAttributes playerAttributes = new playerAttributes();

                    if (selectedItem.Content != null)
                    {
                        string option = selectedItem.Content.ToString();

                        try
                        {
                            playerAttributes.modifyAttributes(option, value);
                            logger.log($"Attempted to set the {option} value to {value}");
                        }
                        catch (Exception ex)
                        {
                            errorBox.sendMSB();
                            logger.log($"Error initializing playerAttributes: {ex.Message}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select an option.", "BCModZ", MessageBoxButton.OK, MessageBoxImage.Error);
                        logger.log("MSB: Please select an option.");
                        logger.log("Selected item returned null.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select an option from the ComboBox.", "BCModZ", MessageBoxButton.OK, MessageBoxImage.Error);
                    logger.log("MSB: Please select an option from the ComboBox.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number only.", "BCModZ", MessageBoxButton.OK, MessageBoxImage.Error);
                logger.log("MSB: Please enter a valid number only.");
            }
        }


        private void btnZrylx_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProcessStartInfo linktr = new ProcessStartInfo();
                linktr.FileName = "cmd.exe";
                linktr.Arguments = "/C start https://linktr.ee/Zrylx";
                linktr.CreateNoWindow = true;

                Process.Start(linktr);
                logger.log("Link tree successfully opened");
            }
            catch (Exception ex)
            {
                logger.log($"Link tree didn't open: {ex}");
            }
            
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            logger.log("User shutdown the application");
        }

        private async void NextButton_Click(object sender, RoutedEventArgs e)
        {
            logger.log("Next button clicked");
            careerProfile careerProfile = new careerProfile();
            await careerProfile.checkProfileAsync(this);
        }
    }
}