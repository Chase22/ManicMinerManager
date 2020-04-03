using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManicMiner
{
    class Program
    {
        static void Main(string[] args)
        {
            List<DirectoryInfo> installations = Directory.GetDirectories(".", "ManicMiners*").ToList()
                .Select(name => new DirectoryInfo(name)).ToList()
                .FindAll(dir => Directory.GetFiles(dir.FullName, "ManicMiners.exe").Length >= 1);

            if (installations.Count == 0)
            {
                Console.WriteLine("No ManicMiner installations found");
                Console.ReadKey();
                Environment.Exit(1);
            }

            syncLevels(installations);
            DirectoryInfo activeInstalation = selectInstallation(installations);

            Process.Start(activeInstalation.GetFiles("ManicMiners.exe").First().FullName);
        }

        static DirectoryInfo selectInstallation(List<DirectoryInfo> installations)
        {
            if (installations.Count == 1) return installations.First();

            short index = 0;
            bool error = false;

            while (true)
            {
                Console.WriteLine("Multiple Installations found. Please select one");
                for (int i = 0; i < installations.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {installations[i].Name}");
                }

                if (error) Console.WriteLine($"Please input a number between 1 and {installations.Count}");

                if (short.TryParse(Console.ReadLine(), out index) && index > 0 && index < installations.Count + 1)
                {
                    Console.WriteLine(index);
                    return installations[index - 1];
                }
                else
                {
                    Console.WriteLine($"Please input a number between 1 and {installations.Count}");
                }
            }
        }
        static void syncLevels(List<DirectoryInfo> installations)
        {
            DirectoryInfo levelDir = new DirectoryInfo("Levels");

            if (levelDir.Exists)
            {
                List<FileInfo> levelFiles = Directory.GetFiles(levelDir.FullName, "*.dat").ToList().Select(name => new FileInfo(name)).ToList();

                installations.ForEach(installation =>
                {
                    string installationLevelDir = Path.Combine(installation.FullName, "ManicMiners\\Levels");
                    if (Directory.Exists(installationLevelDir))
                    {
                        levelFiles.ForEach(level =>
                        {
                            string targetPath = Path.Combine(installationLevelDir, level.Name);
                            if (!File.Exists(targetPath))
                            {
                                File.Copy(level.FullName, targetPath);
                                Console.WriteLine($"{level.Name} doesn't exist in ${installation.Name}. Copying...");
                            }
                        });
                    }
                    else
                    {
                        Console.WriteLine($"No Levels folder in installation {installation.Name}");
                    }
                });
            }
            else
            {
                Console.WriteLine("Levels Folder not found. Not trying to synchronize Level Files");
            }
            Console.WriteLine();
        }
    }


}
