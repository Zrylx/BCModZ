using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BeamCareerCheat
{
    public static class errorBox
    {
        public static void sendMSB()
        {
            if (MessageBox.Show($"An unexpected error occured. Please send the log file to support. Do you wish to show the log file?",
                                            "BCModZ", MessageBoxButton.YesNo, MessageBoxImage.Error) == MessageBoxResult.Yes)
            {
                logger.openLog();
            }
            logger.log("MSB: An unexpected error occured. Please send the log file to support. Do you wish to show the log file?");
        }
    }
}
