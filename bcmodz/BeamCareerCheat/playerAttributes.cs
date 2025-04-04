using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace BeamCareerCheat
{
    public class playerAttributes
    {
        // file path to the attributes file
        careerProfile careerProfile = new careerProfile();
        public static string autosavePath = $"{careerProfile.autosavePath}";

        private readonly Dictionary<string, string> optionMappings = new Dictionary<string, string>
        {
            // limited to changing xp values only at the moment (apart from money and vouchers) - hoping to expand on this in the future

            { "Money", "money" },
            { "Vouchers", "vouchers" },

            { "Logistics XP", "logistics" },
            { "Cargo Delivery XP", "logistics-delivery" },
            { "Car Jockey XP", "logistics-vehicleDelivery" },

            { "Freestyle XP", "freestyle" },

            { "BMRA XP", "bmra" },

            { "APM XP", "apm" },
            { "Motorsports XP", "apm-motorsport" },
            { "Commercial XP", "apm-commercial" }
        };


        public void modifyAttributes(string option, double value)
        {
            string attributesFilePath = Path.Combine(autosavePath, "career", "playerAttributes.json"); 
            // modify the playerAttributes.json file accordingly to what the user selected

            logger.log($"attributesFilePath was set to {attributesFilePath}"); 

            if (File.Exists(attributesFilePath))
            {
                try
                {
                    string json = File.ReadAllText(attributesFilePath);
                    dynamic data = JsonConvert.DeserializeObject(json);
                    string jsonKey = optionMappings[option];

                    if (data == null)
                    {
                        logger.log("Deserialized JSON is null.");
                        errorBox.sendMSB();
                        return;
                    }

                    if (data.ContainsKey(jsonKey))
                    {
                        data[jsonKey]["value"] = value;
                        logger.log($"jsonKey value = {value}");
                    }
                    else
                    {
                        errorBox.sendMSB();
                        logger.log($"Option '{option}' not found in JSON");
                        return;
                    }

                    string updatedJson = JsonConvert.SerializeObject(data, Formatting.Indented);

                    File.WriteAllText(attributesFilePath, updatedJson);
                    logger.log($"playerAttributes written");
                    MessageBox.Show($"Set {option} to {value}", "BCModZ", MessageBoxButton.OK, MessageBoxImage.Information);
                    logger.log($"MSB: Set {option} to {value}");
                }
                catch (Exception ex)
                {
                    logger.log($"Error modifying attributes: {ex.Message}.");
                    errorBox.sendMSB();
                }
            }
            else 
            {
                logger.log($"File playerAttributes does not exist: {attributesFilePath}");
                errorBox.sendMSB();
            }
        }
    }
}
