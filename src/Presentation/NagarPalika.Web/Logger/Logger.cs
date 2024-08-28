namespace NagarPalika.Web
{
    public class Loggers
    {
        public static void WriteLog(string Log)
        {
            string filepath = AppDomain.CurrentDomain.BaseDirectory;
            filepath = filepath + "Logs";

            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            string filename = "\\Log_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter((filepath + filename), true))
            {
                sw.WriteLine(Log);
                sw.Close();
            }
        }
    }
}
