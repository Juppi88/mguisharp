using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MGUI;

namespace TestApp
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();

			Renderer.Initialize( this, Width, Height );
			MyllyGUI.Initialize( this.Handle, Renderer.Handle );
		}

		~MainWindow()
		{
			MyllyGUI.Shutdown();
			Renderer.Shutdown();
		}

		private void MainWindow_Load( object sender, EventArgs e )
		{
			testLabel = new MGUI.Label();
		}

		private MGUI.Label testLabel;
	}
}
