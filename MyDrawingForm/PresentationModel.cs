using MyDrawingForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDrawingForm
{
    public class PresentationModel : INotifyPropertyChanged
    {
        Model _model;
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isDecisionChecked;
        private bool _isProcessChecked;
        private bool _isStartChecked;
        private bool _isTerminatorChecked;
        private bool _isSelectChecked;
        private bool _isCreateEnabled;
        private bool _isButtonOKEnabled;
        private bool _isUndoEnabled = false;
        private bool _isRedoEnabled = false;
        private bool _isLineChecked;
        private Cursor _cursor;
        private string _shape;
        private string _text;
        private string _x;
        private string _y;
        private string _height;
        private string _width;
        private string _initialText;
        private string _modifyText;

        public Model model
        {
            get
            {
                return _model;
            }
        }

        public PresentationModel(Model model)
        {
            this._model = model;
            _model.ModelChanged += UpdateState;
        }

        public void Notify(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsDecisionChecked()
        {
            return _isDecisionChecked;
        }

        public bool IsProcessChecked()
        {
            return _isProcessChecked;
        }

        public bool IsStartChecked()
        {
            return _isStartChecked;
        }

        public bool IsTerminatorChecked()
        {
            return _isTerminatorChecked;
        }

        public bool IsSelectChecked()
        {
            return _isSelectChecked;
        }

        public bool IsLineChecked()
        {
            return _isLineChecked;
        }

        public bool IsCreateEnabled
        {
            get
            {
                return _isCreateEnabled;
            }
        }

        public bool IsButtonOKEnabled
        {
            get
            {
                return _isButtonOKEnabled;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _isUndoEnabled;
            }
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _isRedoEnabled;
            }
        }


        public Cursor GetCursor()
        {
            return _cursor;
        }

        public void UpdateState()
        {
            string mode = _model.GetDrawingMode();

            if (mode != "")
            {
                _cursor = Cursors.Cross;
            }
            else
            {
                _cursor = Cursors.Default;
            }

            _isStartChecked = mode == "Start";
            _isTerminatorChecked = mode == "Terminator";
            _isProcessChecked = mode == "Process";
            _isDecisionChecked = mode == "Decision";
            _isLineChecked = mode == "Line";
            _isSelectChecked = mode == "";

            _isUndoEnabled = _model.commandManager.IsUndoEnabled;
            _isRedoEnabled = _model.commandManager.IsRedoEnabled;
        }

        public void SetStartMode()
        {
            _model.SetDrawingMode("Start");
        }

        public void SetTerminatorMode()
        {
            _model.SetDrawingMode("Terminator");
        }

        public void SetProcessMode()
        {
            _model.SetDrawingMode("Process");
        }

        public void SetDecisionMode()
        {
            _model.SetDrawingMode("Decision");
        }

        public void SetSelectMode()
        {
            _model.SetSelectMode();
        }

        public void SetDrawLineMode()
        {
            _model.SetDrawLineMode();
        }

        public void Undo()
        {
            _model.Undo();
        }

        public void Redo()
        {
            _model.Redo();
        }

        public void TextBoxTextChanged(string text)
        {
            _text = text;
            CreateBlockChanged();
        }

        public void TextBoxXChanged(string x)
        {
            _x = x;
            CreateBlockChanged();
        }

        public void TextBoxYChanged(string y)
        {
            _y = y;
            CreateBlockChanged();
        }

        public void TextBoxHeightChanged(string height)
        {
            _height = height;
            CreateBlockChanged();
        }

        public void TextBoxWidthChanged(string width)
        {
            _width = width;
            CreateBlockChanged();
        }

        public void ComboBoxShapeSelectedIndexChanged(string shape)
        {
            _shape = shape;
            CreateBlockChanged();
        }

        public string InitialText
        {
            get { return _initialText; }
            set
            {
                _initialText = value;
                Notify("InitialText");
            }
        }

        public void TextBoxModifyTextChanged(string text)
        {
            _modifyText = text;
            if (_modifyText != "" && _modifyText != _initialText)
            {
                _isButtonOKEnabled = true;
            }
            else
            {
                _isButtonOKEnabled = false;
            }
            Notify("IsButtonOKEnabled");
        }

        public bool IsShapeValid()
        {
            return _shape == "Start" || _shape == "Terminator" || _shape == "Process" || _shape == "Decision";
        }

        public bool IsTextValid()
        {
            return _text != "";
        }

        public bool IsXValid()
        {
            try
            {
                int x = Convert.ToInt32(_x);
                return x > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsYValid()
        {
            try
            {
                int y = Convert.ToInt32(_y);
                return y > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsHeightValid()
        {
            try
            {
                int height = Convert.ToInt32(_height);
                return height > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsWidthValid()
        {
            try
            {
                int width = Convert.ToInt32(_width);
                return width > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void CreateBlockChanged()
        {

            if (IsTextValid() && IsShapeValid() && IsXValid() && IsYValid() && IsHeightValid() && IsWidthValid())
            {
                _isCreateEnabled = true;
            }
            else
            {
                _isCreateEnabled = false;
            }
            Notify("IsCreateEnabled");
        }

        public Color TextLabelColor
        {
            get
            {
                if (!IsTextValid())
                {
                    return Color.Red;
                }
                else
                {
                    return Color.Black;
                }
            }
        }

        public Color XLabelColor
        {
            get
            {
                if (!IsXValid())
                {
                    return Color.Red;
                }
                else
                {
                    return Color.Black;
                }
            }
        }

        public Color YLabelColor
        {
            get
            {
                if (!IsYValid())
                {
                    return Color.Red;
                }
                else
                {
                    return Color.Black;
                }
            }
        }

        public Color HeightLabelColor
        {
            get
            {
                if (!IsHeightValid())
                {
                    return Color.Red;
                }
                else
                {
                    return Color.Black;
                }
            }
        }

        public Color WidthLabelColor
        {
            get
            {
                if (!IsWidthValid())
                {
                    return Color.Red;
                }
                else
                {
                    return Color.Black;
                }
            }
        }

        public void AddShape()
        {
            Shape s = _model.GetShape(_shape, _text, Convert.ToInt32(_x), Convert.ToInt32(_y), Convert.ToInt32(_height), Convert.ToInt32(_width));
            _model.AddShapeFromDataGrid(s);
        }

        public void UpdateShapeList(DataGridView dataGridViewShapes)
        {
            dataGridViewShapes.Rows.Clear();
            var shapeList = _model.GetShapes();
            foreach (Shape shape in shapeList)
            {
                dataGridViewShapes.Rows.Add("刪除", shape.ShapeId, shape.GetType().Name, shape.Text, shape.X, shape.Y, shape.Height, shape.Width);
            }
        }
        public void UpdateShapeText(Shape shape, string newText)
        {
            string oldText = shape.Text;
            ICommand command = new TextChangedCommand(shape, oldText, newText);
            _model.commandManager.Execute(command);
            Notify("ShapeTextUpdated");
        }

        public void ManageBackupFiles(string backupFolder)
        {
            var backupFiles = new DirectoryInfo(backupFolder).GetFiles()
                .OrderByDescending(f => f.CreationTime)
                .Skip(5)
                .ToList();

            foreach (var file in backupFiles)
            {
                file.Delete();
            }
        }

        public void AutoSaveAsync(string originalTitle)
        {
            if (_model.isChanged)
            {
                string backupFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "drawing_backup");
                Directory.CreateDirectory(backupFolder);

                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string backupFileName = $"{timestamp}_bak.mydrawing";
                string backupFilePath = Path.Combine(backupFolder, backupFileName);

                SaveAsync(backupFilePath);
                ManageBackupFiles(backupFolder);
            }
        }


        public void SaveAsync(string filePath)
        {
            Thread.Sleep(3000);
            // Create a StringBuilder to build the custom format string
            var sb = new StringBuilder();

            // Add shapes to the string
            sb.AppendLine("Shape ID X Y H W Text");
            List<Task> shapeTasks = new List<Task>();
            foreach (var shape in _model.GetShapes())
            {
                shapeTasks.Add(Task.Run(() =>
                {
                    if (shape.ShapeName != "Line")
                    {
                        sb.AppendLine($"{shape.ShapeName} {shape.ShapeId} {shape.X} {shape.Y} {shape.Height} {shape.Width} {shape.Text}");
                    }
                }));
            }

            // Wait for all shape tasks to complete
            Task.WaitAll(shapeTasks.ToArray());

            // Add lines to the string
            sb.AppendLine("---------");
            sb.AppendLine("Line ID Connection_ShapeID1 Connection_Point1 Connection_ShapeID2 Connection_Point2");
            List<Task> lineTasks = new List<Task>();
            foreach (var line in _model.GetLines())
            {
                lineTasks.Add(Task.Run(() =>
                {
                    var (connShapeId1, connPoint1) = (line.FromShape.ShapeId, line.FromConnector);
                    var (connShapeId2, connPoint2) = (line.ToShape.ShapeId, line.ToConnector);
                    sb.AppendLine($"Line {line.FromShape.ShapeId} {connShapeId1} {connPoint1} {connShapeId2} {connPoint2}");
                }));
            }

            // Wait for all line tasks to complete
            Task.WaitAll(lineTasks.ToArray());

            sb.AppendLine("---------");
            // Write the formatted string to the file
            File.WriteAllText(filePath, sb.ToString());

            _model.isChanged = false;
            // Log success message
            Console.WriteLine("Save completed successfully.");
        }


        public void Load(string filePath)
        {
            Thread.Sleep(3000);
            // Read the file content
            var lines = File.ReadAllLines(filePath);

            // Clear existing shapes
            _model.shapes = new Shapes();

            // Parse shapes
            int i = 1; // Start after the header line
            while (i < lines.Length && !lines[i].StartsWith("---------"))
            {
                var parts = lines[i].Split(' ');
                if (parts.Length >= 7)
                {
                    string shapeName = parts[0];
                    int id = int.Parse(parts[1]);
                    int x = int.Parse(parts[2]);
                    int y = int.Parse(parts[3]);
                    int h = int.Parse(parts[4]);
                    int w = int.Parse(parts[5]);
                    string text = parts[6];

                    var shape = _model.shapes.GetNewShape(shapeName, text, x, y, h, w);
                    shape.ShapeId = id; // Set the ID explicitly
                    _model.shapes.AddShape(shape);
                }
                i++;
            }

            // Parse lines (connections)
            i += 2; // Skip the "---------" line and the header line for lines
            while (i < lines.Length && !lines[i].StartsWith("---------"))
            {
                var parts = lines[i].Split(' ');
                if (parts.Length >= 6)
                {
                    int id = int.Parse(parts[1]);
                    int connShapeId1 = int.Parse(parts[2]);
                    int connPoint1 = int.Parse(parts[3]);
                    int connShapeId2 = int.Parse(parts[4]);
                    int connPoint2 = int.Parse(parts[5]);

                    var fromShape = _model.shapes.GetShapes().FirstOrDefault(s => s.ShapeId == connShapeId1);
                    var toShape = _model.shapes.GetShapes().FirstOrDefault(s => s.ShapeId == connShapeId2);

                    if (fromShape != null && toShape != null)
                    {
                        var line = new Line(fromShape, toShape, connPoint1, connPoint2);
                        _model.AddLine(line);
                    }
                }
                i++;
            }
        }
    }
}
