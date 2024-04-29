using System.IO.Ports;

namespace Logger
{
    public class Program
    {
        static string path = Environment.CurrentDirectory;

        static void Main(string[] args)
        {

            using (SerialPort port = new SerialPort("COM5", 921600))
            {
                
                port.Open();
                using (StreamWriter writer = new(path + "\\Logfile.txt", append: true))
                {
                    while (true)
                    {
                        if (port.BytesToRead > 0)
                        {
                            string logEntry = port.ReadLine();
                            if(logEntry.Contains("[START]"))
                            {
                                writer.WriteLine(logEntry + DateTime.Now.ToString());
                            }
                            else
                            {
                                writer.WriteLine(logEntry);
                            }
                            
                            writer.Flush();
                        }
                    }
                }   
            }
        }
    }
}