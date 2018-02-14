using System;
using System.IO;
using System.Threading;


namespace HR_Report_Format
{
	public class Format
	{
		public static void FormatDirectory(string inputDir, string outputDir)
		{
			string[] files = Directory.GetFiles(inputDir);
			foreach (string file in files)
			{
				string text3 = null;
				int num = 0;
				string fileName = Path.GetFileName(file);
				string outFile = Path.Combine(outputDir, fileName);
				using (StreamReader streamReader = new StreamReader(file))
				{
					using (StreamWriter streamWriter = new StreamWriter(outFile))
					{
						while ((text3 = streamReader.ReadLine()) != null)
						{
							num++;
							if (num % 2 != 0 || num == 2)
							{
								streamWriter.WriteLine(text3);
							}
						}
					}
				}
			}
		}

		public static void CheckDirectory(string dir)
		{
			if (!Directory.Exists(dir))
			{
				Console.WriteLine("The path " + dir + " does not currently exist. Are you missing the desktop folder?");
				Thread.Sleep(10000);
				Environment.Exit(0);
			}
		}
	}
}