using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDrawingForm
{
    public partial class Form2 : Form
    {
        private List<Shape> shapeList = new List<Shape>();
        private PresentationModel presentationModel;
        public Form2(string initialText)
        {
            InitializeComponent();
            presentationModel = new PresentationModel(new Model());
            presentationModel.InitialText = initialText;
            textBoxModifyText.Text = initialText;
            ButtonOK.DataBindings.Add("Enabled", presentationModel, "IsButtonOKEnabled");
        }

        private void TextBoxModifyText_Changed(object sender, EventArgs e)
        {
            presentationModel.TextBoxModifyTextChanged(textBoxModifyText.Text);
        }


        private void ButtonOK_Click(object sender, EventArgs e)
        {

        }

        public string GetTextBoxText()
        {
            return textBoxModifyText.Text;
        }
    }
}
