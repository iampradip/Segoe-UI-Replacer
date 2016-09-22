using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SegoeUIReplacer {
    public partial class MainForm : Form {
		private RegistryKey substituteKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\FontSubstitutes");
		private RegistryKey fontsKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts");

        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
			string value = (string)substituteKey.GetValue("Segoe UI");

			foreach (FontFamily fontFamily in FontFamily.Families) {
				int index = list.Items.Add(fontFamily.Name);
				if (fontFamily.Name.Equals(value)) {
					list.SelectedIndex = index;
				}
			}
        }

		private void list_DoubleClick(object sender, EventArgs e) {
			substituteKey.SetValue("Segoe UI", list.Text, RegistryValueKind.String);
			Dictionary<string, string> data = new Dictionary<string, string>();
			data["Segoe UI (TrueType)"] = "segoeui.ttf";
			data["Segoe UI Bold (TrueType)"] = "segoeuib.ttf";
			data["Segoe UI Bold Italic (TrueType)"] = "segoeuiz.ttf";
			data["Segoe UI Italic (TrueType)"] = "segoeuii.ttf";
			data["Segoe UI Light (TrueType)"] = "segoeuil.ttf";
			data["Segoe UI Semibold (TrueType)"] = "seguisb.ttf";
			data["Segoe UI Symbol (TrueType)"] = "seguisym.ttf";
			if (list.Text == "Segoe UI") {
				foreach (var pair in data) {
					fontsKey.SetValue(pair.Key, pair.Value, RegistryValueKind.String);
				}
			} else {
				foreach (var pair in data) {
					fontsKey.SetValue(pair.Key, "", RegistryValueKind.String);
				}
			}
			this.Close();
		}

		private void list_SelectedIndexChanged(object sender, EventArgs e) {
			Label[] labels = new Label[] { label1, label2, label3, label4, label5 };
			for (int i = 0; i < labels.Length; i++) {
				labels[i].Font = new Font(list.Text, 5 * (i + 1), FontStyle.Regular, this.Font.Unit, this.Font.GdiCharSet, this.Font.GdiVerticalFont);
				if (i != labels.Length - 1) {
					labels[i + 1].Top = labels[i].Top + labels[i].Height;
				}
			}
		}
    }
}
