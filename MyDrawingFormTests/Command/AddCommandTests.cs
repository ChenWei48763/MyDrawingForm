using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyDrawingForm.Tests
{
    [TestClass()]
    public class AddCommandTests
    {
        private Model _model;
        private Shape _shape;
        private AddCommand _addCommand;

        [TestInitialize]
        public void Setup()
        {
            _model = new Model();
            _shape = new Process(1, "test", 10, 20, 30, 40);
            _addCommand = new AddCommand(_model, _shape);
        }

        [TestMethod]
        public void ExecuteTest()
        {
            _addCommand.Execute();
            var shapes = _model.GetShapes();
            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual(_shape, shapes[0]);
        }

        [TestMethod]
        public void UnExecuteTest()
        {
            _addCommand.Execute();
            _addCommand.UnExecute();
            var shapes = _model.GetShapes();
            Assert.AreEqual(0, shapes.Count);
        }
    }
}
