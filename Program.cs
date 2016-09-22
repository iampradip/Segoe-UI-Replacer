using System;
using System.Windows.Forms;

namespace SegoeUIReplacer {
	class Program {
		[STAThread]
		static void Main(string[] args) {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
			Environment.Exit(0);
		}
	}
}
