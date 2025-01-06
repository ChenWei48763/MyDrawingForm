using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingForm;
using MyDrawingFormTests;

namespace MyDrawingForm.Tests
{
    [TestClass()]
    public class TextMoveCommandTests
    {
        private Shape _shape;
        private TextMoveCommand _textMoveCommand;

        [TestInitialize]
        public void Setup()
        {
            _shape = new Process(1, "test", 10, 20, 30, 40);
            _textMoveCommand = new TextMoveCommand(_shape, 15, 25, 50, 60);
        }

        [TestMethod]
        public void ExecuteTest()
        {
            _textMoveCommand.Execute();
            Assert.AreEqual(50, _shape.TextX);
            Assert.AreEqual(60, _shape.TextY);
        }

        [TestMethod]
        public void UnExecuteTest()
        {
            _textMoveCommand.Execute();
            _textMoveCommand.UnExecute();
            Assert.AreEqual(15, _shape.TextX);
            Assert.AreEqual(25, _shape.TextY);
        }
    }
}















