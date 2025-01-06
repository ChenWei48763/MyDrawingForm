using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingForm;
using MyDrawingFormTests;

namespace MyDrawingForm.Tests
{
    [TestClass()]
    public class ConnectorCommandTests
    {
        private Model _model;
        private Line _line;
        private ConnectorCommand _connectorCommand;

        [TestInitialize]
        public void Setup()
        {
            _model = new Model();
            Shape fromShape = new Process(1, "from", 10, 20, 30, 40);
            Shape toShape = new Process(2, "to", 50, 60, 70, 80);
            _line = new Line(fromShape, toShape, 1, 2);
            _connectorCommand = new ConnectorCommand(_model, _line);
        }

        [TestMethod]
        public void ExecuteTest()
        {
            _connectorCommand.Execute();
            var lines = _model.GetLines();
            Assert.AreEqual(1, lines.Count);
            Assert.AreEqual(_line, lines[0]);
        }

        [TestMethod]
        public void UnExecuteTest()
        {
            _connectorCommand.Execute();
            _connectorCommand.UnExecute();
            var lines = _model.GetLines();
            Assert.AreEqual(0, lines.Count);
        }
    }
}
