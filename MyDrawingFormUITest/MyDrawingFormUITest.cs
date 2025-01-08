using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.IO;

namespace MyDrawingFormUITest
{
    [TestClass]
    public class MyDrawingFormUITest
    {
        private const string WinAppDriverUrl = "http://127.0.0.1:4723";
        private UITest uiTest;
        private string targetAppPath;

        [TestInitialize]
        public void Initialize()
        {
            var projectName = "MyDrawingForm";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "MyDrawingForm.exe");
            Console.Write(targetAppPath);
            uiTest = new UITest(targetAppPath, "MyDrawingForm"); // 替換為你的主窗體名稱
        }

        [TestCleanup]
        public void Cleanup()
        {
            uiTest.CleanUp();
        }

        [TestMethod]
        public void Tests()
        {
            TestDrawShapes(); //選取工具列上的各種圖形，並在畫布上繪製簡易流程圖
            TestUndo(); //將Line Undo掉
            TestUndo(); //將Line Undo掉
            TestRemove(); //用DataGridView刪除所有圖形
            TestUndo();  //Undo剛剛DataGridView刪除
            TestRedo(); //Redo剛剛DataGridView刪除
            TestSelect(); //畫一個圖形，測試圖形拖曳、文字框拖曳、文字框編輯
            TestDataGridView(); //測試DataGridView新增圖形
            TestRemove(); //用DataGridView刪除所有圖形
            TestSaveAndLoad(); //畫三個圖形，save，刪除一個圖型，load變回三個圖形
        }

        public void TestDrawShapes()
        {
            uiTest.ClickButton("Start"); 
            uiTest.AssertChecked("Start", true);
            uiTest.AssertChecked("Terminator", false);
            uiTest.AssertChecked("Process", false);
            uiTest.AssertChecked("Decision", false);
            uiTest.AssertChecked("Select", false);
            uiTest.AssertChecked("Line", false);

            uiTest.MouseClickAndHold(50,50, 100,100);

            uiTest.ClickButton("Terminator");
            uiTest.AssertChecked("Start", false);
            uiTest.AssertChecked("Terminator", true);
            uiTest.AssertChecked("Process", false);
            uiTest.AssertChecked("Decision", false);
            uiTest.AssertChecked("Select", false);
            uiTest.AssertChecked("Line", false);
            uiTest.MouseClickAndHold(200, 50, 200, 100);

            uiTest.ClickButton("Process");
            uiTest.AssertChecked("Start", false);
            uiTest.AssertChecked("Terminator", false);
            uiTest.AssertChecked("Process", true);
            uiTest.AssertChecked("Decision", false);
            uiTest.AssertChecked("Select", false);
            uiTest.AssertChecked("Line", false);
            uiTest.MouseClickAndHold(50, 200, 100, 100);

            uiTest.ClickButton("Decision");
            uiTest.AssertChecked("Start", false);
            uiTest.AssertChecked("Terminator", false);
            uiTest.AssertChecked("Process", false);
            uiTest.AssertChecked("Decision", true);
            uiTest.AssertChecked("Select", false);
            uiTest.AssertChecked("Line", false);
            uiTest.MouseClickAndHold(200, 200, 200, 100);

            uiTest.ClickButton("Line");
            uiTest.AssertChecked("Start", false);
            uiTest.AssertChecked("Terminator", false);
            uiTest.AssertChecked("Process", false);
            uiTest.AssertChecked("Decision", false);
            uiTest.AssertChecked("Select", false);
            uiTest.AssertChecked("Line", true);
            uiTest.MouseMove(100, 200);
            uiTest.Sleep(1000);
            uiTest.MouseClickAndHold(100, 200, 0, -50);

            uiTest.ClickButton("Line");
            uiTest.MouseMove(100, 200);
            uiTest.Sleep(1000);
            uiTest.MouseClickAndHold(150, 100, 50, 0);
            uiTest.MouseMove(300, 300);

            uiTest.Sleep(1000);
        }

        public void TestUndo()
        {
            uiTest.ClickButton("Undo");
            uiTest.Sleep(1000);
        }

        public void TestRedo()
        {
            uiTest.ClickButton("Redo");
            uiTest.Sleep(1000);
        }

        public void TestRemove()
        {
            for (int i = 3; i >= 0; i--)
            {
                uiTest.ClickRemoveDataGridViewRow("dataGridViewShapes", i);
            }
        }

        public void TestDataGridView()
        {
            uiTest.EnterTextBox("textBoxText", "test1");
            uiTest.EnterTextBox("textBoxX", "50");
            uiTest.EnterTextBox("textBoxY", "50");
            uiTest.EnterTextBox("textBoxHeight", "100");
            uiTest.EnterTextBox("textBoxWidth", "100");
            uiTest.EnterComboBox("comboBoxShape", "Start");
            uiTest.ClickButton("Add");

            uiTest.EnterTextBox("textBoxText", "test2");
            uiTest.EnterTextBox("textBoxX", "200");
            uiTest.EnterTextBox("textBoxY", "50");
            uiTest.EnterTextBox("textBoxHeight", "200");
            uiTest.EnterTextBox("textBoxWidth", "100");
            uiTest.EnterComboBox("comboBoxShape", "Terminator");
            uiTest.ClickButton("Add");

            uiTest.EnterTextBox("textBoxText", "test3");
            uiTest.EnterTextBox("textBoxX", "50");
            uiTest.EnterTextBox("textBoxY", "200");
            uiTest.EnterTextBox("textBoxHeight", "100");
            uiTest.EnterTextBox("textBoxWidth", "100");
            uiTest.EnterComboBox("comboBoxShape", "Process");
            uiTest.ClickButton("Add");

            uiTest.EnterTextBox("textBoxText", "test4");
            uiTest.EnterTextBox("textBoxX", "200");
            uiTest.EnterTextBox("textBoxY", "200");
            uiTest.EnterTextBox("textBoxHeight", "100");
            uiTest.EnterTextBox("textBoxWidth", "100");
            uiTest.EnterComboBox("comboBoxShape", "Decision");
            uiTest.ClickButton("Add");

            uiTest.Sleep(2000);
        }

        public void TestSelect()
        {
            uiTest.ClickButton("Process");
            uiTest.MouseClickAndHold(100, 100, 300, 300);
            uiTest.Sleep(1000);
            uiTest.ClickButton("Select");
            uiTest.AssertChecked("Start", false);
            uiTest.AssertChecked("Terminator", false);
            uiTest.AssertChecked("Process", false);
            uiTest.AssertChecked("Decision", false);
            uiTest.AssertChecked("Select", true);
            uiTest.AssertChecked("Line", false);
            uiTest.MouseClickAndHold(110, 110, 100, 0);
            uiTest.MouseClickAndHold(335,200,50,50);
            uiTest.ClickAt("drawPanel", 385, 250);
            uiTest.ClickAt("drawPanel", 385, 250);
            uiTest.EnterTextBox("textBoxShpaeText", "12345678");
            uiTest.ClickButton("確定");
            uiTest.Sleep(2000);
            uiTest.ClickRemoveDataGridViewRow("dataGridViewShapes", 0);
        }

        public void TestSaveAndLoad()
        {
            uiTest.ClickButton("Decision");
            uiTest.MouseClickAndHold(200, 200, 200, 100);
            uiTest.ClickButton("Start");
            uiTest.MouseClickAndHold(50, 50, 100, 100);
            uiTest.ClickButton("Process");
            uiTest.MouseClickAndHold(50, 200, 100, 100);
            uiTest.ClickButton("Line");
            uiTest.MouseMove(100, 200);
            uiTest.Sleep(1000);
            uiTest.MouseClickAndHold(100, 200, 0, -50);

            uiTest.ClickButton("Save");
            uiTest.ClickButton("存檔(S)");
            uiTest.Sleep(6000);
            uiTest.ClickButton("確定");
            uiTest.Sleep(2000);
            uiTest.ClickRemoveDataGridViewRow("dataGridViewShapes", 0);
            uiTest.Sleep(2000);
            uiTest.ClickButton("Load");
            uiTest.ClickButton("開啟(O)");
            uiTest.Sleep(3000);
            uiTest.ClickButton("確定");
            uiTest.Sleep(6000);
        }
    }
}

