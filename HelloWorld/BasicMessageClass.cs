using System;
using System.IO;


namespace HelloWorld
{
    class BasicMessageClass
    {
        private string message;
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }

        public BasicMessageClass(string m)
        {
            message = m;
        }

        BasicMessageClass()
        {
            message = "No message Set";
        }

        public void ShowMessageInConsole()
        {
            Console.WriteLine(Message);

        }

        public void WriteMessageToFile()
        {
            StreamWriter sw = new StreamWriter("out4.txt");
            sw.WriteLine(Message);
            sw.Close();

        }
    }
}