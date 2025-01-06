using MyDrawingForm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MyDrawingForm
{
    public partial class Form1 : Form
    {
        private Model _model;
        private PresentationModel presentationModel;

        public Form1(PresentationModel presentationModel)
        {
            InitializeComponent();
            this.presentationModel = presentationModel;
            this._model = presentationModel.model;

            drawPanel.MouseDown += HandleCanvasPointerPressed;
            drawPanel.MouseUp += HandleCanvasPointerReleased;
            drawPanel.MouseMove += HandleCanvasPointerMoved;
            drawPanel.Paint += HandleCanvasPaint;

            _model.ModelChanged += HandleModelChanged;
            ButtonAdd.DataBindings.Add("Enabled", presentationModel, "IsCreateEnabled");

            // 啟用雙重緩衝
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            DoubleBuffered = true;
            _model.EnterPointerState();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            presentationModel.AddShape();
        }

        private void dataGridViewShapes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                Shape shape = _model.GetShapes()[e.RowIndex];
                _model.RemoveShapeFromDataGrid(shape);
                HandleModelChanged();
            }
        }

        public void RefreshState()
        {
            UpdateButtonStates();
            UpdateCursor();
            _model.UpdateShapeList(dataGridViewShapes);
        }

        private void UpdateButtonStates()
        {
            ButtonStart.Checked = presentationModel.IsStartChecked();
            ButtonTerminator.Checked = presentationModel.IsTerminatorChecked();
            ButtonProcess.Checked = presentationModel.IsProcessChecked();
            ButtonDecision.Checked = presentationModel.IsDecisionChecked();
            ButtonSelect.Checked = presentationModel.IsSelectChecked();
            ButtonLine.Checked = presentationModel.IsLineChecked();

            ButtonUndo.Enabled = presentationModel.IsUndoEnabled;
            ButtonRedo.Enabled = presentationModel.IsRedoEnabled;
        }

        private void UpdateCursor()
        {
            drawPanel.Cursor = presentationModel.GetCursor();
        }

        public void HandleCanvasPointerPressed(object sender, MouseEventArgs e)
        {
            _model.PointerPressed(e.X, e.Y);
        }

        public void HandleCanvasPointerReleased(object sender, MouseEventArgs e)
        {
            _model.PointerReleased(e.X, e.Y);
        }

        public void HandleCanvasPointerMoved(object sender, MouseEventArgs e)
        {
            _model.PointerMoved(e.X, e.Y);
        }

        public void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            _model.Draw(new FormGraphicAdapter(e.Graphics));
        }

        public void HandleModelChanged()
        {
            Invalidate(true);
            RefreshState();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            presentationModel.SetStartMode();
        }

        private void ButtonTerminator_Click(object sender, EventArgs e)
        {
            presentationModel.SetTerminatorMode();
        }

        private void ButtonProcess_Click(object sender, EventArgs e)
        {
            presentationModel.SetProcessMode();
        }

        private void ButtonDecision_Click(object sender, EventArgs e)
        {
            presentationModel.SetDecisionMode();
        }

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            presentationModel.SetSelectMode();
        }

        private void ButtonLine_Click(object sender, EventArgs e)
        {
            presentationModel.SetDrawLineMode();
        }

        private void TextBoxText_Changed(object sender, EventArgs e)
        {
            presentationModel.TextBoxTextChanged(textBoxText.Text);
            TextLabel.ForeColor = presentationModel.TextLabelColor;
        }

        private void TextBoxX_Changed(object sender, EventArgs e)
        {
            presentationModel.TextBoxXChanged(textBoxX.Text);
            XLabel.ForeColor = presentationModel.XLabelColor;
        }

        private void TextBoxY_Changed(object sender, EventArgs e)
        {
            presentationModel.TextBoxYChanged(textBoxY.Text);
            YLabel.ForeColor = presentationModel.YLabelColor;
        }

        private void TextBoxHeight_Changed(object sender, EventArgs e)
        {
            presentationModel.TextBoxHeightChanged(textBoxHeight.Text);
            HeightLabel.ForeColor = presentationModel.HeightLabelColor;
        }

        private void TextBoxWidth_Changed(object sender, EventArgs e)
        {
            presentationModel.TextBoxWidthChanged(textBoxWidth.Text);
            WidthLabel.ForeColor = presentationModel.WidthLabelColor;
        }

        private void ComboBoxShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            presentationModel.ComboBoxShapeSelectedIndexChanged(comboBoxShape.SelectedItem.ToString());
        }

        private void ButtonUndo_Click(object sender, EventArgs e)
        {
            presentationModel.Undo();
        }

        private void ButtonRedo_Click(object sender, EventArgs e)
        {
            presentationModel.Redo();
        }
    }
}
