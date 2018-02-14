using System;
using System.IO;
using System.Threading;


namespace HR_Report_Format
{
	public class Format
	{
		public static bool ValidateSelection(string inputDir)
		{
			string[] files = Directory.GetFiles(inputDir);
			foreach(string file in files)
			{
				if(Path.GetExtension(file) != ".txt")
				{
					return false;
				}
			}
			return true;
		}

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
	}
}