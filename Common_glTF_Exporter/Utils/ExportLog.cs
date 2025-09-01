using System;
using System.IO;
using System.Text;

namespace Common_glTF_Exporter.Utils
{
    public class ExportLog
    {
        private static string logFilePath => Path.Combine(Exporter.exportOptions.TempDirectory, Exporter.exportOptions.TxtFileName);

        public static void StartLog()
        {
            try
            {
                using (var writer = File.CreateText(logFilePath))
                {
                    writer.WriteLine($"Convert to GLB started at {DateTime.Now}");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error writing to log: {ex.Message}");
            }
        }

        public static void EndLog()
        {
            try
            {
                using (var writer = File.AppendText(logFilePath))
                {
                    writer.WriteLine($"Convert to GLB ended at {DateTime.Now}");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error writing to log: {ex.Message}");
            }
        }

        public static void Write(string message)
        {
            try
            {
                using (var writer = File.AppendText(logFilePath))
                {
                    writer.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error writing to log: {ex.Message}");
            }
        }

        public static void WriteException(Exception ex)
        {
            try
            {
                using (var writer = File.AppendText(logFilePath))
                {
                    writer.WriteLine($"Error: {ex.Message}");
                    writer.WriteLine(ex.StackTrace);
                }
            }
            catch (Exception logEx)
            {
                Console.Error.WriteLine($"Error writing exception to log: {logEx.Message}");
            }
        }

    }

}
