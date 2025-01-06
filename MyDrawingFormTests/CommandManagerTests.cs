using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyDrawingForm.Tests
{

    [TestClass]
    public class CommandManagerTests
    {
        private CommandManager commandManager;

        [TestInitialize]
        public void Setup()
        {
            commandManager = new CommandManager();
        }

        [TestMethod]
        public void Execute_AddsCommandToUndoStackAndClearsRedoStack()
        {
            // Arrange
            var mockCommand = new MockCommand();

            // Act
            commandManager.Execute(mockCommand);

            // Assert
            Assert.IsTrue(mockCommand.Executed, "Command should be executed.");
            Assert.IsTrue(commandManager.IsUndoEnabled, "Undo should be enabled.");
            Assert.IsFalse(commandManager.IsRedoEnabled, "Redo should not be enabled.");
        }

        [TestMethod]
        public void Undo_MovesCommandToRedoStackAndCallsUnExecute()
        {
            // Arrange
            var mockCommand = new MockCommand();
            commandManager.Execute(mockCommand);

            // Act
            commandManager.Undo();

            // Assert
            Assert.IsTrue(mockCommand.UnExecuted, "Command should be unexecuted.");
            Assert.IsFalse(commandManager.IsUndoEnabled, "Undo should not be enabled.");
            Assert.IsTrue(commandManager.IsRedoEnabled, "Redo should be enabled.");
        }

        [TestMethod]
        public void Redo_MovesCommandToUndoStackAndCallsExecute()
        {
            // Arrange
            var mockCommand = new MockCommand();
            commandManager.Execute(mockCommand);
            commandManager.Undo();

            // Act
            commandManager.Redo();

            // Assert
            Assert.IsTrue(mockCommand.Executed, "Command should be re-executed.");
            Assert.IsTrue(commandManager.IsUndoEnabled, "Undo should be enabled.");
            Assert.IsFalse(commandManager.IsRedoEnabled, "Redo should not be enabled.");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Cannot Undo exception\n")]
        public void Undo_ThrowsExceptionWhenUndoStackIsEmpty()
        {
            // Act
            commandManager.Undo();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Cannot Redo exception\n")]
        public void Redo_ThrowsExceptionWhenRedoStackIsEmpty()
        {
            // Act
            commandManager.Redo();
        }

    }
}