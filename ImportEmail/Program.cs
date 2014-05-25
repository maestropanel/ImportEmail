using MpMigrate.MaestroPanel.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportEmail
{
    class Program
    {
        private static ApiClient _client;

        static void Main(string[] args)
        {
            var host = GetArgument(args,"--host");
            var apikey = GetArgument(args, "--apikey");
            var port = GetArgument(args, "--port");
            var apiPort = 9715;

            string[] lines = null;

            if (!File.Exists("Emails.txt"))
                throw new FileNotFoundException("Email.txt not found");

            if (String.IsNullOrEmpty(host))
                throw new ArgumentException("--host parameter not found");

            if (String.IsNullOrEmpty(apikey))
                throw new ArgumentException("--apikey parameter not found");

            if (String.IsNullOrEmpty(port))
                throw new ArgumentException("--port parameter not found");

            
            if(!int.TryParse(port, out apiPort))
                throw new ArgumentException("Invalid port number");

            lines = File.ReadAllLines("Emails.txt");

            _client = new ApiClient(apikey, host, port: apiPort);
            var login = _client.Whoami();
            if (login.ErrorCode == 0)
            {
                Console.WriteLine("Login success... ({0})", login.Details.Username);

                Console.WriteLine("Importing Email Users");
                StartImport(lines);
            }
            else
            {
                Console.WriteLine(login.Message);
            }
        }

        private static string GetArgument(string[] args, string name)
        {
            var param = args.FirstOrDefault(m => m.StartsWith(name));
            return param.Split('=').LastOrDefault();
        }

        private static void StartImport(string[] lines)
        {
            foreach (var item in lines)
            {
                var _row = item.Split(',');
                if (_row.Length == 4)
                {
                    var fullName = _row[0];
                    var mailboxName = _row[1].Split('@').FirstOrDefault();
                    var domainName = _row[1].Split('@').LastOrDefault();
                    var password = _row[2];            

                    double quota = -1;
                    double.TryParse(_row[3], out quota);

                    var addEmailResult = _client.AddMailBox(domainName, mailboxName, password, quota, "", "", fullName);

                    if (addEmailResult.ErrorCode == 0)
                    {
                        Console.WriteLine("Email Added: {0}", _row[1]);
                    }
                    else
                    {
                        Console.WriteLine("Error: {1}, {0}", addEmailResult.Message, _row[1]);
                    }
                }
            }
        }
    }
}
