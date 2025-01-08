//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;

//namespace MyDrawingFormUITest
//{
//    [TestClass()]
//    public class MainFormUITest
//    {
//        private Robot _robot;
//        private const string APP_NAME = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";
//        private const string CALCULATOR_TITLE = "小算盤";
//        private const string EXPECTED_VALUE = "顯示是 444";
//        private const string RESULT_CONTROL_NAME = "CalculatorResults";

//        [TestInitialize()]
//        public void Initialize()
//        {
//            _robot = new Robot(APP_NAME, CALCULATOR_TITLE);
//        }

//        [TestCleanup()]
//        public void Cleanup()
//        {
//            _robot.CleanUp();
//        }

//        private void RunScriptAdd()
//        {
//            _robot.ClickButton("清除");
//            _robot.ClickButton("一");
//            _robot.ClickButton("二");
//            _robot.ClickButton("三");
//            _robot.ClickButton("加");
//            _robot.ClickButton("三");
//            _robot.ClickButton("二");
//            _robot.ClickButton("一");
//            _robot.ClickButton("等於");
//        }

//        [TestMethod]
//        public void TestAdd()
//        {
//            RunScriptAdd();
//            _robot.AssertText(RESULT_CONTROL_NAME, EXPECTED_VALUE);
//        }

//    }

//}
