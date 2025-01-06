using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDrawingForm
{
    public static class Prompt
    {
        public static string ShowDialog(string title, string promptText, string defaultText = "")
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 20, Top = 20, Text = promptText };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 240, Text = defaultText };
            Button confirmation = new Button() { Text = "確定", Left = 20, Width = 100, Top = 80, DialogResult = DialogResult.OK, Enabled = false };
            Button cancel = new Button() { Text = "取消", Left = 160, Width = 100, Top = 80, DialogResult = DialogResult.Cancel };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            cancel.Click += (sender, e) => { prompt.Close(); };

            textBox.TextChanged += (sender, e) =>
            {
                confirmation.Enabled = textBox.Text != defaultText && !string.IsNullOrEmpty(textBox.Text);
            };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancel;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : null;
        }
    }
}
