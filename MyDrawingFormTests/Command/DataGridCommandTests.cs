using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyDrawingForm.Tests
{
    [TestClass()]
    public class DataGridCommandTests
    {
        private Model _model;
        private Shape _shape;
        private DataGridCommand _addCommand;
        private DataGridCommand _removeCommand;

        [TestInitialize]
        public void Setup()
        {
            _model = new Model();
            _shape = new Process(1, "test", 10, 20, 30, 40);
            _addCommand = new DataGridCommand(_model, _shape, true);
            _removeCommand = new DataGridCommand(_model, _shape, false);
        }

        [TestMethod]
        public void ExecuteAddTest()
        {
            _addCommand.Execute();
            var shapes = _model.GetShapes();
            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual(_shape, shapes[0]);
        }

        [TestMethod]
        public void ExecuteRemoveTest()
        {
            _addCommand.Execute();
            _removeCommand.Execute();
            var shapes = _model.GetShapes();
            Assert.AreEqual(0, shapes.Count);
        }

        [TestMethod]
        public void UnExecuteAddTest()
        {
            _addCommand.Execute();
            _addCommand.UnExecute();
            var shapes = _model.GetShapes();
            Assert.AreEqual(0, shapes.Count);
        }

        [TestMethod]
        public void UnExecuteRemoveTest()
        {
            _addCommand.Execute();
            _removeCommand.Execute();
            _removeCommand.UnExecute();
            var shapes = _model.GetShapes();
            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual(_shape, shapes[0]);
        }
    }
}
