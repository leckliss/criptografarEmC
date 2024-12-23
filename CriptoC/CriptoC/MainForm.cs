/*
 * Created by SharpDevelop.
 * User: marco
 * Date: 31/08/2023
 * Time: 13:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace CriptoC
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{

			
		}
		void Button1Click(object sender, EventArgs e)
		{
			Crypt clCrypt = new Crypt();
			textBox2.Text = clCrypt.Criptografa(textBox1.Text);
			clCrypt = null;
		}
		void Button2Click(object sender, EventArgs e)
		{	
			Crypt clCrypt = new Crypt();
			textBox2.Text = clCrypt.Descriptografa(textBox1.Text);
			clCrypt = null;
		}
	}
}
