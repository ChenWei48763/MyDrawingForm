using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingForm;
using MyDrawingFormTests;

namespace MyDrawingForm.Tests
{
    [TestClass()]
    public class TextChangedCommandTests
    {
        private Shape _shape;
        private TextChangedCommand _textChangedCommand;

        [TestInitialize]
        public void Setup()
        {
            _shape = new Process(1, "oldText", 10, 20, 30, 40);
            _textChangedCommand = new TextChangedCommand(_shape, "oldText", "newText");
        }

        [TestMethod]
        public void ExecuteTest()
        {
            _textChangedCommand.Execute();
            Assert.AreEqual("newText", _shape.Text);
        }

        [TestMethod]
        public void UnExecuteTest()
        {
            _textChangedCommand.Execute();
            _textChangedCommand.UnExecute();
            Assert.AreEqual("oldText", _shape.Text);
        }
    }
}

























