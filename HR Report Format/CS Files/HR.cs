using System;
using System.IO;
using System.Threading;

//needs to be gutted and re-written

internal class MainClass
{
	public static void Main(string[] args)
	{
		string text = "C:\\Users\\cm112243\\Desktop\\original";
		string text2 = "C:\\Users\\cm112243\\Desktop\\final";
		MainClass.CheckDirectory(text);
		MainClass.CheckDirectory(text2);
		string[] files = Directory.GetFiles(text);
		string[] array = files;
		foreach (string path in array)
		{
			string text3 = null;
			int num = 0;
			string fileName = Path.GetFileName(path);
			string path2 = Path.Combine(text2, fileName);
			using (StreamReader streamReader = new StreamReader(path))
			{
				using (StreamWriter streamWriter = new StreamWriter(path2))
				{
					while ((text3 = streamReader.ReadLine()) != null)
					{
						num++;
						if (!MainClass.IsEven(num) || num == 2)
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

	public static bool IsEven(int num)
	{
		if (num % 2 == 0)
		{
			return true;
		}
		return false;
	}
}