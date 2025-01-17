using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BeamCareerCheat
{
    public class careerProfile
    {
        public bool isValidProfile = false;
        public bool dirsExist = false;
        public string careerProfileName = "";
        public string careerProfilePath = "";
        public static string autosavePath = "";
        public async Task checkProfileAsync(MainWindow mw)
        {
            rearrangeSaveDirs rearrangeDirs = new rearrangeSaveDirs();
            playerAttributes playerAttributes = new playerAttributes();
            // loading animation
            animCF anim = new animCF();
            anim.canvasLoadAnim(mw);

            await Task.Run(() =>
            {
                Thread.Sleep(2500);
            });

            await Task.Run(() => 
            {
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string basePath = Path.Combine(appDataPath, "BeamNG.drive");

                // check if base directory exists
                if (!Directory.Exists(basePath)) 
                {
                    mw.Dispatcher.Invoke(() =>
                    {
                        MessageBox.Show("BeamNG.drive directory not found. Please verify your installation.", 
                            "BCModZ", MessageBoxButton.OK, MessageBoxImage.Error);
                        logger.log("MSB: BeamNG.drive directory not found. Please verify your installation.");
                    });
                    return;
                }

                // find the highest version folder (0.30 or above)
                string? highestVersionPath = Directory.GetDirectories(basePath)
                .Where(dir => Path.GetFileName(dir).StartsWith("0.")
                    && double.TryParse(Path.GetFileName(dir).Substring(2), out double version)
                    && version >= 30)
                .OrderByDescending(dir => double.Parse(Path.GetFileName(dir).Substring(2)))
                .FirstOrDefault();

                if (highestVersionPath == null)
                {
                    mw.Dispatcher.Invoke(() =>
                    {
                        logger.log("No valid version folder (0.30 or above) found");
                        errorBox.sendMSB();
                    });
                    return;
                }

                // construct the full path to the saves directory
                string profilesPath = Path.Combine(highestVersionPath, "settings", "cloud", "saves");

                if (Directory.Exists(profilesPath))
                {
                    logger.log($"Profile directory found: {profilesPath}");

                    logger.log($"{profilesPath} exists");

                    // check if the name the user entered into the textbox is a career profile in the saves folder
                    string profileName = string.Empty;
                    mw.Dispatcher.Invoke(() =>
                    {
                        profileName = mw.tbProfileName.Text.Trim();
                    });


                    if (string.IsNullOrWhiteSpace(profileName))
                    {
                        logger.log($"User entered a non-valid career profile name: {profileName}");
                        mw.Dispatcher.Invoke(() =>
                        {
                            MessageBox.Show($"Please enter a valid career profile name.",
                                            "BCModZ", MessageBoxButton.OK, MessageBoxImage.Error);
                            logger.log("MSB: Please enter a valid career profile name.");
                        });
                        isValidProfile = false;
                        logger.log("isValidProfile = false");
                    }
                    else
                    {
                        string profilePath = Path.Combine(profilesPath, profileName);

                        if (Directory.Exists(profilePath))
                        {
                            logger.log($"profile {profileName} exists at {profilePath}");

                            isValidProfile = true;
                            logger.log("isValidProfile = true");

                            careerProfileName = $"{profileName}";
                            careerProfilePath = $"{profilePath}";

                            Debug.WriteLine($"career profile set as {careerProfileName} and path set to {careerProfilePath}");
                            logger.log($"career profile set as {careerProfileName} and path set to {careerProfilePath}");

                            // make sure that the autosave files were successfully rearranged
                            bool success = rearrangeDirs.rearrangeAutosaves(this);

                            if (success)
                            {
                                logger.log("rearrangeAutosaves function returned 'success'; setting dirsExist = true");

                                dirsExist = true;
                            }


                            Task.Delay(1500).Wait();
                        }
                        else
                        {
                            logger.log($"profile {profileName} was not found at {profilePath}");
                            mw.Dispatcher.Invoke(() =>
                            {
                                MessageBox.Show($"The career profile, {profileName}, does not exist. " +
                                $"Please double check if this is truly the name of your career profile, free from any spelling errors.",
                                "BCModZ", MessageBoxButton.OK, MessageBoxImage.Error);

                                logger.log($"MSB: The career profile, {profileName}, does not exist. Please double check if this is truly the name of your career profile, free from any spelling errors.");
                            });
                            isValidProfile = false;
                            logger.log("isValidProfile = false");
                        }
                    }
                }
                else
                {
                    mw.Dispatcher.Invoke(() =>
                    {
                        logger.log("Saves directory not found in the selected version folder.");
                        MessageBox.Show("An error occured locating user data folder, please ensure you have started and played career mode first.", 
                            "BCModZ", MessageBoxButton.OK, MessageBoxImage.Error);
                        logger.log("MSB: An error occured locating user data folder, please ensure you have started and played career mode first.");
                    });

                    isValidProfile = false;
                    logger.log("isValidProfile = false");
                }
            });


            
            if (isValidProfile == true && dirsExist == true)
            {
                autosavePath = rearrangeDirs.keptAutosaveDir;
                logger.log($"autosavePath = {autosavePath}");

                logger.log("isValidProfile returned true and dirsExist returned true");

                anim.canvasLoadAnimOUT(mw);
                await Task.Run(() =>
                {
                    Thread.Sleep(1500);
                });
                anim.canvasAnim(mw);
            }
            else
            {
                logger.log("Either isValidProfile or dirsExist didn't return true");
                anim.canvasLoadAnimOUT(mw);
            }

        }
    }
}