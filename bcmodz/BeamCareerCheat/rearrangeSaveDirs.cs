using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace BeamCareerCheat
{
    public class rearrangeSaveDirs
    {
        // deletes older autosave folders to prevent the game from reading data from a different folder
        public string keptAutosaveDir {  get; private set; }
        public bool rearrangeAutosaves(careerProfile profile)
        {
            string pathToAutoSaves = profile.careerProfilePath;
            string nameOfCareerProfile = profile.careerProfileName;

            logger.log($"Starting rearrangeAutosaves for profile {nameOfCareerProfile} at path {pathToAutoSaves}");


            // this hurts my eyes to look at
            if (Directory.Exists(pathToAutoSaves))
            {
                // get all the directories matching the pattern -> autosave1 autosave2 etc
                var autoSaveDirs = Directory.GetDirectories(pathToAutoSaves, "autosave*")
                                            .Select(dir => new { Path = dir, Match = Regex.Match(Path.GetFileName(dir), @"^autosave(\d+)$") })
                                            .Where(x => x.Match.Success)
                                            .Select(x => new { x.Path, Number = int.Parse(x.Match.Groups[1].Value) })
                                            .ToList();

                if (autoSaveDirs.Any())
                {
                    // find the dir that has the highest number
                    var maxDir = autoSaveDirs.OrderByDescending(x => x.Number).First();
                    keptAutosaveDir = maxDir.Path;
                    logger.log($"keptAutosaveDir is {keptAutosaveDir}");

                    // delete the other dirs
                    foreach (var dir in autoSaveDirs.Where(x => x.Path != maxDir.Path))
                    {
                        try
                        {
                            Directory.Delete(dir.Path, true);
                            logger.log($"Deleted dir: {dir.Path}");
                        }
                        catch (Exception ex)
                        {
                            logger.log($"Error deleting {dir.Path}: {ex}");

                            errorBox.sendMSB();
                            return false;
                        }
                    }
                    logger.log($"Kept dir: {maxDir.Path}");
                    return true;
                }
                else
                {
                    logger.log($"No dirs found");
                    errorBox.sendMSB();
                    return false;
                }
            }
            else
            {
                logger.log($"Path {pathToAutoSaves} does not exist");
                errorBox.sendMSB();
                return false;
            }
        }
    }
}
