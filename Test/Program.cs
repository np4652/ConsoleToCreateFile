using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Test
{
    class Program
    {
        static string CurrentDirectory() => (new Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath.Split(new string[] { "/bin" }, StringSplitOptions.None)[0];
        static string GetMachineName() => Environment.MachineName;
        static string docPath() => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static void Main(string[] args)
        {
            string result = "Hello world";
            try
            {
                string c = CurrentDirectory();
                string parentDir = $"{c}/__Test/";
                if (!Directory.Exists(parentDir))
                {
                    Directory.CreateDirectory(parentDir);
                }
                if (!Directory.Exists($"{parentDir}/Orgs"))
                {
                    Directory.CreateDirectory($"{parentDir}/Orgs");
                }
                if (!Directory.Exists($"{parentDir}/Orgs/cyberdyne"))
                {
                    Directory.CreateDirectory($"{parentDir}/Orgs/cyberdyne");
                }
                if (!Directory.Exists($"{parentDir}/Orgs/tyrell"))
                {
                    Directory.CreateDirectory($"{parentDir}/Orgs/tyrell");
                }
                if (!Directory.Exists($"{parentDir}/Orgs/bluesun"))
                {
                    Directory.CreateDirectory($"{parentDir}/Orgs/bluesun");
                }
                Console.WriteLine("Enter text:");
                string _text = Console.ReadLine();
                var directories = Directory.GetDirectories($"{parentDir}/Orgs");
                foreach (var item in directories)
                {
                    Console.WriteLine($"Directory Name : {item}");
                    DirectoryInfo directoryInfo = new DirectoryInfo(item);
                    var fileName = Path.Combine(item, $"{GetMachineName()}-{directoryInfo.Name}.txt");
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }
                    // Create a new file     
                    using (FileStream fs = File.Create(fileName))
                    {
                        // Add some text to file    
                        Byte[] title = new UTF8Encoding(true).GetBytes(_text);
                        fs.Write(title, 0, title.Length);
                    }
                    result = "Text file created.";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            Console.WriteLine(result);
        }
    }
}