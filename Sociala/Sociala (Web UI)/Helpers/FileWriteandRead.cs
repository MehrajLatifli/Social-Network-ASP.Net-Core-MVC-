using System.Diagnostics;

namespace Sociala__Web_UI_.Helpers
{
    public static class FileWriteandRead
    {


        public static void writetextfile(string text)
        {
            try
            {
                using (StreamWriter writetext = new StreamWriter(@"wwwroot\currentpost.txt"))
                {
                    writetext.WriteLine(text);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Debug.WriteLine("Executing finally block.");
            }
        }

        public static string readtextfile()
        {
            string line = string.Empty;
            try
            {
                using (StreamReader readtext = new StreamReader(@"wwwroot\currentpost.txt"))
                {
                    line = readtext.ReadLine();
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Debug.WriteLine("Executing finally block.");
            }

            return line;
        }
    }
}
