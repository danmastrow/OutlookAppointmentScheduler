namespace OutlookAppointmentSchedulerGUI
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using Newtonsoft.Json;
    using OutlookAppointmentScheduler;

    public static class BookingDataFileWriter
    {

        /// <summary>Writes the booking data to json file.</summary>
        /// <param name="directory">The directory.</param>
        /// <param name="bookingData">The booking data.</param>
        /// <returns>The filename written to.</returns>
        public static string WriteBookingDataToJsonFile(string directory, IBookingData bookingData, string fullFileName = null)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            Directory.CreateDirectory(directory); // Interestingly enough it doesnt matter whether this already exists when attempting to create.
            fullFileName = fullFileName ?? directory + "\\" + $"{bookingData.Name.Replace(" ", "-").Trim()}{DateTime.Now.ToString(@"yyyy-MMM-dd-hh-mm-ss")}.json";

            //var invalidFileName = string.IsNullOrEmpty(fullFileName) ||
            //  fullFileName.IndexOfAny(Path.GetInvalidFileNameChars()) < 0;


            using (StreamWriter file = File.CreateText(fullFileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, bookingData);
            }

            return fullFileName;
        }
    }
}
