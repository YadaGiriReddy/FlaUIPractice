using System;
using System.Threading;
using FlaUI.Core.Conditions;
using FlaUI.Core.Input;
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
    }
}