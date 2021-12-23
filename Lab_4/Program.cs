using McMaster.Extensions.CommandLineUtils;
using System;
using System.IO;
using System.Diagnostics;
using Lab_3_lib;

namespace Lab_4
{
    class Program
    {
        static int Main(string[] args)
        {
            var app = new CommandLineApplication
            {
                Name = "PR4",
                Description = "Console application pr4",
            };

            app.Command("version", versionCmd =>
            {
                versionCmd.OnExecute(() =>
                {
                    Console.WriteLine("Author: Alex Hlopenko, IPZ-41\nVersion: 99.0");

                });
                
            });

            app.Command("run", runCmd =>
            {
                runCmd.OnExecute(() =>
                {
                    Console.WriteLine("Missed lab subcommand");

                });

                runCmd.Command("lab3", lab3Cmd => 
                {
                    

                    var input = lab3Cmd.Option("-i|--input", "input file path", CommandOptionType.SingleValue);
                    var output = lab3Cmd.Option("-o|--output", "output file path", CommandOptionType.SingleValue);
                    string result_path;

                    lab3Cmd.OnExecute(() =>
                    {
                        
                        if (input.HasValue() && output.HasValue())
                        {
                            result_path = input.Value() + "|" + output.Value();
                        }
                        else if (Environment.GetEnvironmentVariable("LAB_PATH") != null)
                        {
                            result_path = Environment.GetEnvironmentVariable("LAB_PATH").ToString();
                        }
                        else
                        {
                            string homepath;

                            if ((Environment.OSVersion.Platform).ToString() == "Unix")
                            {
                                homepath = "HOME";
                            }
                            else
                            {
                                homepath = "HOMEPATH";
                            }

                            string home_input = Environment.GetEnvironmentVariable(homepath).ToString() + @"\INPUT.txt";
                            string home_output = Environment.GetEnvironmentVariable(homepath).ToString() + @"\OUTPUT.txt";

                            if (System.IO.File.Exists(home_input) && (System.IO.File.Exists(home_output)))
                            {
                                result_path = home_input + "|" + home_output;
                            }
                            else
                            {
                                Console.WriteLine("Enter correct path");
                                result_path = "";
                            }

                        }

                        if (result_path != "")
                        {
                            var c = new Class1(result_path);
                            c.main_code();
                        }

                        else
                        {
                            var c = new Class1("C:\\Users\\Карина\\Desktop\\cross_platform\\cross_platform\\Lab_3_console\\Files");
                            c.main_code();
                        }

                    });

                });

            });

            app.Command("set-path", spathCmd =>
            {
                static void ExecuteBashCommand(string command)
                {
                    command = command.Replace("\"", "\"\"");
                    var proc = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = "/bin/bash",
                            Arguments = "-c \"" + command + "\"",
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            CreateNoWindow = true
                        }
                    };

                    proc.Start();
                    proc.WaitForExit();

                }

                var path = spathCmd.Option("-p|--path", "files folder path", CommandOptionType.SingleOrNoValue); 
                Console.WriteLine(path.HasValue()); //не работает, всегда false
                Console.WriteLine(Environment.GetEnvironmentVariable("LAB_PATH"));

                if ((Environment.OSVersion.Platform).ToString() == "Unix")
                {
                    ExecuteBashCommand($"export LAB_PATH={path.Value()}");
                }
                else
                {
                    Environment.SetEnvironmentVariable("LAB_PATH", path.Value());
                }


            });

            app.OnExecute(() =>
            {
                Console.WriteLine("Nice try");
                return 1;
            });

            return app.Execute(args);
        }
    }
}
