using System.IO.Ports;

namespace Logger
{
    public class Program
    {

        static void Main(string[] args)
        {

            using (SerialPort port = new SerialPort("COM3", 921600))
            {
                
                port.Open();

                while (true)
                {
                    if(port.BytesToRead > 0)
                    {
                        using (StreamWriter writer = new(DateTime.Now.ToString() + ".txt", append: true))
                        {
                            while (true)
                            {
                                if (port.BytesToRead > 0)
                                {
                                    string logEntry = port.ReadLine();
                                    writer.WriteLine(logEntry);
                                    writer.Flush();
                                    if(logEntry == "[END]")
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    
                }
            }
        }
    }
}