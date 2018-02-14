using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace HR_Report_Format
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private static void DirSelect(TextBox textbox)
		{
			var folderDialog = new System.Windows.Forms.FolderBrowserDialog();
			var result = folderDialog.ShowDialog();
			switch(result)
			{
				case System.Windows.Forms.DialogResult.OK:
					var folder = folderDialog.SelectedPath;
					textbox.Text = folder;
					textbox.ToolTip = folder;
					break;
				case System.Windows.Forms.DialogResult.Cancel:
					textbox.Text = null;
					textbox.ToolTip = null;
					break;
			}
		}

		private void DirInButton_Click(object sender, RoutedEventArgs e)
		{
			DirSelect(InputFolderText);
		}

		private void DirOutButton_Click(object sender, RoutedEventArgs e)
		{
			DirSelect(OutputFolderText);
		}

		private void EnterButton_Click(object sender, RoutedEventArgs e)
		{
			if(InputFolderText.Text != "" && OutputFolderText.Text != "")
			{
				if (Format.ValidateSelection(InputFolderText.Text))
				{
					Format.FormatDirectory(InputFolderText.Text, OutputFolderText.Text);
					Application.Current.Shutdown();
				}
				else
				{
					MessageBoxResult errorBox = MessageBox.Show("The selected input folder should only contain text files.", "Error", MessageBoxButton.OK);
				}
			}
		}
	}
}
