using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using static System.Windows.Forms.LinkLabel;
using Newtonsoft.Json;
using System.IO;

namespace MyDrawingForm
{
    public class Model
    {
        internal Shapes shapes = new Shapes();
        public CommandManager commandManager = new CommandManager();
        public event ModelChangedEventHandler ModelChanged;
        public delegate void ModelChangedEventHandler();
        public bool isChanged;
        private string _mode = "";

        internal IState pointerState;
        IState drawingState;
        IState drawLineState;
        List<Line> lines = new List<Line>();
        public IState currentState;
        public Model()
        {
            pointerState = new PointerState();
            drawingState = new DrawingState((PointerState)pointerState);
            drawLineState = new DrawLineState();
            currentState = pointerState;
        }

        public void EnterPointerState()
        {
            pointerState.Initialize(this);
            currentState = pointerState;
        }

        public void EnterDrawingState()
        {
            drawingState.Initialize(this);
            currentState = drawingState;
        }

        public void EnterDrawLineState()
        {
            drawLineState.Initialize(this);
            currentState = drawLineState;
        }

        public void NotifyModelChanged()
        {
            isChanged = true;
            if (ModelChanged != null)
                ModelChanged();
        }

        public void PointerPressed(int x, int y)
        {
            currentState.MouseDown(x, y);
        }

        public void PointerMoved(int x, int y)
        {
            currentState.MouseMove(x, y);
        }

        public void PointerReleased(int x, int y)
        {
            currentState.MouseUp(x, y);
        }

        public void Draw(IGraphics graphics)
        {
            currentState.OnPaint(graphics);
        }

        public List<Shape> GetShapes()
        {
            return shapes.GetShapes();
        }

        public Shape GetShape(string shape, string name, int x, int y, int height, int width)
        {
            return shapes.GetNewShape(shape, name, x, y, height, width);
        }

        public void AddShape(Shape s)
        {
            shapes.AddShape(s);
            SetSelectMode();
            NotifyModelChanged();
        }

        public void RemoveShape(Shape s)
        {
            shapes.RemoveShape(s);
            EnterPointerState();
            NotifyModelChanged();
        }

        public void AddLine(Line l)
        {
            lines.Add(l);
            NotifyModelChanged();
        }
        public void RemoveLine(Line l)
        {
            lines.Remove(l);
            NotifyModelChanged();
        }

        public List<Line> GetLines()
        {
            return lines;
        }

        public string GetDrawingMode()
        {
            return _mode;
        }

        public void SetDrawingMode(string mode)
        {
            _mode = mode;
            EnterDrawingState();
            NotifyModelChanged();
        }

        public void SetSelectMode()
        {
            _mode = "";
            EnterPointerState();
            NotifyModelChanged();
        }

        public void SetDrawLineMode()
        {
            _mode = "Line";
            EnterDrawLineState();
            NotifyModelChanged();
        }

        public void Undo()
        {
            commandManager.Undo();
            NotifyModelChanged();
        }
        public void Redo()
        {
            commandManager.Redo();
            NotifyModelChanged();
        }

        public void AddShapeFromDataGrid(Shape shape)
        {
            commandManager.Execute(new DataGridCommand(this, shape, true));
            NotifyModelChanged();
        }

        public void RemoveShapeFromDataGrid(Shape shape)
        {
            commandManager.Execute(new DataGridCommand(this, shape, false));
            NotifyModelChanged();
        }

        public void UpdateShapeList(DataGridView dataGridViewShapes)
        {
            dataGridViewShapes.Rows.Clear();
            var shapeList = GetShapes();
            foreach (Shape shape in shapeList)
            {
                dataGridViewShapes.Rows.Add("刪除", shape.ShapeId, shape.GetType().Name, shape.Text, shape.X, shape.Y, shape.Height, shape.Width);
            }
        }

        public async Task SaveAsync(string filePath)
        {
            // 模擬延遲
            await Task.Delay(3000);

            // 序列化 Model 並保存到文件
            string json = JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            });

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                await writer.WriteAsync(json);
            }
        }

        public void Load(string filePath)
        {
            // 反序列化 Model 從文件中加載
            string json = File.ReadAllText(filePath);
            var loadedModel = JsonConvert.DeserializeObject<Model>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            // 更新當前 Model 的狀態
            this.shapes = loadedModel.shapes;
            this.commandManager = loadedModel.commandManager;
            this._mode = loadedModel._mode;
            this.pointerState = new PointerState();
            this.drawingState = new DrawingState((PointerState)pointerState);
            this.drawLineState = new DrawLineState();
            this.lines = loadedModel.lines;
            this.currentState = pointerState;

            // 初始化狀態
            pointerState.Initialize(this);
            drawingState.Initialize(this);
            drawLineState.Initialize(this);

            // 更新狀態
            NotifyModelChanged();
        }
    }
}
