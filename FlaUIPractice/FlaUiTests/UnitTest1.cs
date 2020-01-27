using System;
using System.Diagnostics;
using System.Threading;
using FlaUI.Core;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.Shapes;
using FlaUI.Core.WindowsAPI;
using FlaUI.UIA2;
using FlaUI.UIA3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlaUiTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBasicControls()
        {
            var application = FlaUI.Core.Application.Launch(@"C:\Data\Visual Studio Workspace\FlaUiPractice\FlaUIPractice\BankSystem\bin\Release\BankSystem.exe");
            var automation = new UIA3Automation();
            var mainWindow = application.GetMainWindow(automation);
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());

            mainWindow.FindFirstDescendant(cf.ByName("Registration")).AsButton().Click();
            mainWindow.FindFirstDescendant(cf.ByAutomationId("InFName")).AsTextBox().Enter("Yadagiri");
            mainWindow.FindFirstDescendant(cf.ByAutomationId("InLName")).AsTextBox().Enter("Reddy");
            mainWindow.FindFirstDescendant(cf.ByAutomationId("InAge")).AsComboBox().Select(4).Click();
            mainWindow.FindFirstDescendant(cf.ByAutomationId("InCountry")).AsComboBox().Select("India").Click();
            mainWindow.FindFirstDescendant(cf.ByAutomationId("InPhone")).AsTextBox().Enter("9876543210");
            mainWindow.FindFirstDescendant(cf.ByAutomationId("InEmail")).AsTextBox().Enter("jhabcdefhjk@gmail.com");
            mainWindow.FindFirstDescendant(cf.ByAutomationId("InPass")).AsTextBox().Enter("12345");
            mainWindow.FindFirstDescendant(cf.ByAutomationId("InCard")).AsTextBox().Enter("456378963215");
            mainWindow.FindFirstDescendant(cf.ByAutomationId("VipCheck")).AsCheckBox().Click();
            mainWindow.FindFirstDescendant(cf.ByName("Ok")).AsButton().Click();
            var congratulationsWindow = mainWindow.FindFirstDescendant(cf.ByName("Congratulations")).AsWindow();
            Assert.IsNotNull(congratulationsWindow);
            congratulationsWindow.FindFirstDescendant(cf.ByName("OK")).AsButton().Click();
            mainWindow.FindFirstDescendant(cf.ByName("Exit")).AsButton().Click();
            var exitWindow = mainWindow.FindFirstDescendant(cf.ByName("Exit")).AsWindow();
            exitWindow.FindFirstDescendant(cf.ByName("Yes")).AsButton().Click();
        }

        [TestMethod]
        public void TestFindMEthods()
        {
            var application = FlaUI.Core.Application.Launch(@"C:\Data\Visual Studio Workspace\FlaUiPractice\FlaUIPractice\BankSystem\bin\Release\BankSystem.exe");
            var automation = new UIA3Automation();
            var mainWindow = application.GetMainWindow(automation);
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());

            var elements = mainWindow.FindAll(FlaUI.Core.Definitions.TreeScope.Children,
                new PropertyCondition(automation.PropertyLibrary.Element.ControlType, FlaUI.Core.Definitions.ControlType.Edit));
            foreach (var item in elements)
            {
                item.DrawHighlight();
                Thread.Sleep(500);
            }
            //mainWindow.FindFirstDescendant(cf.ByControlType(FlaUI.Core.Definitions.ControlType.Edit)).DrawHighlight();
            //Thread.Sleep(500);
        }

        [TestMethod]
        public void TestConditionFactoryWithMultipleConditions()
        {
            var application = FlaUI.Core.Application.Launch(@"C:\Data\Visual Studio Workspace\FlaUiPractice\FlaUIPractice\BankSystem\bin\Release\BankSystem.exe");
            var automation = new UIA3Automation();
            var mainWindow = application.GetMainWindow(automation);
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());

            mainWindow.FindFirstDescendant(cf.ByName("Registration")).AsButton().Click();
            var elements = mainWindow.FindAllDescendants(cf.ByName("First Name :").And(cf.ByControlType(FlaUI.Core.Definitions.ControlType.Edit)));
            foreach (var item in elements)
            {
                item.DrawHighlight();
                Thread.Sleep(500);
            }
        }

        [TestMethod]
        public void TestMenuControls()
        {
            var application = FlaUI.Core.Application.Launch(@"C:\Data\Visual Studio Workspace\FlaUiPractice\FlaUIPractice\FlaUiTests\Resources\WinFormsApplication.exe");
            var automation = new UIA3Automation();
            var mainWindow = application.GetMainWindow(automation);
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            //var menu = mainWindow.FindFirstDescendant(cf.Menu()).AsMenu();
            //menu.DrawHighlight();

            //menu.Items["File"].Invoke();
            mainWindow.FindFirstDescendant(cf.ByName("ContextMenu")).AsButton().RightClick();
            var contextMenu = mainWindow.ContextMenu;
            contextMenu.DrawHighlight();
            contextMenu.Items[0].DrawHighlight();
        }

        [TestMethod]
        public void TestMouseActions()
        {
            Point point = new Point(2298, 82);
            Mouse.MoveTo(1500, 100);
            Mouse.MoveBy(100, 100);
            Mouse.LeftClick();
            Mouse.Click(MouseButton.Left, point);
        }

        [TestMethod]
        public void TestkeyboardActions()
        {
            var application = FlaUI.Core.Application.Launch(@"notepad.exe");
            var automation = new UIA3Automation();
            var mainWindow = application.GetMainWindow(automation);
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            mainWindow.FindFirstDescendant(cf.ByControlType(FlaUI.Core.Definitions.ControlType.Document)).Focus();

            Keyboard.Type('A');
            Keyboard.Type("Hello");
            Keyboard.Type(VirtualKeyShort.KEY_B, VirtualKeyShort.KEY_C);

            Keyboard.Press(VirtualKeyShort.BACK);

            Keyboard.TypeSimultaneously(VirtualKeyShort.CONTROL, VirtualKeyShort.KEY_A);

            using (Keyboard.Pressing(VirtualKeyShort.SHIFT))
            {
                Keyboard.Type("world");
            }
        }

        [TestMethod]
        public void TestCaptureMethod()
        {
            //Full screen
            var fullscreenImg = Capture.Screen();
            fullscreenImg.ToFile(@"C:\Data\Visual Studio Workspace\Screenshots\Full Screen.png");
            
            //only one automation element
            var application = FlaUI.Core.Application.Launch(@"C:\Data\Visual Studio Workspace\FlaUiPractice\FlaUIPractice\BankSystem\bin\Release\BankSystem.exe");
            var automation = new UIA3Automation();
            var mainWindow = application.GetMainWindow(automation);
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            var loginBtn = mainWindow.FindFirstDescendant(cf.ByName("Log In"));
            var loginImg = Capture.Element(loginBtn);
            loginImg.ToFile(@"C:\Data\Visual Studio Workspace\Screenshots\Login Button.png");

            //user defined rectangle area 
            var rectangleImg = Capture.Rectangle(new Rectangle(500, 500, 100, 150));
            rectangleImg.ToFile(@"C:\Data\Visual Studio Workspace\Screenshots\Rectangle Img.png");
        }

        [TestMethod]
        public void TestPatterns()
        {

        }
    }
}