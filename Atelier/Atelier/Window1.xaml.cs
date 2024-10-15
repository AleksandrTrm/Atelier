/*
 * Created by SharpDevelop.
 * User: sanya
 * Date: 14.04.2024
 * Time: 19:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Atelier
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public Window1()
		{		
			InitializeComponent();
		}

		private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
			this.Close();        
        }
    }
}