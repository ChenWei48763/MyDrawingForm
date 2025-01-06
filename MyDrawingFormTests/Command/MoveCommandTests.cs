using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingForm;
using MyDrawingFormTests;

namespace MyDrawingForm.Tests
{
    [TestClass()]
    public class MoveCommandTests
    {
        private Shape _shape;
        private MoveCommand _moveCommand;

        [TestInitialize]
        public void Setup()
        {
            _shape = new Process(1, "test", 10, 20, 30, 40);
            _moveCommand = new MoveCommand(_shape, 10, 20, 50, 60);
        }

        [TestMethod]
        public void ExecuteTest()
        {
            _moveCommand.Execute();
            Assert.AreEqual(50, _shape.X);
            Assert.AreEqual(60, _shape.Y);
            Assert.AreEqual(63, _shape.TextX);
            Assert.AreEqual(70, _shape.TextY);
        }

        [TestMethod]
        public void UnExecuteTest()
        {
            _moveCommand.Execute();
            _moveCommand.UnExecute();
            Assert.AreEqual(10, _shape.X);
            Assert.AreEqual(20, _shape.Y);
            Assert.AreEqual(23, _shape.TextX);
            Assert.AreEqual(30, _shape.TextY);
        }
    }
}














