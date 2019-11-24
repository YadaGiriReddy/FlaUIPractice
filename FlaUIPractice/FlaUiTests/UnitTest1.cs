using System;
using System.Threading;
using FlaUI.UIA3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlaUiTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var app = FlaUI.Core.Application.Launch(@"C:\Data\Visual Studio Workspace\FlaUiPractice\FlaUIPractice\BankSystem\bin\Release\BankSystem.exe");
            using (var automation = new UIA3Automation())
            {
                Thread.Sleep(3000);
                var mainWindow = app.GetMainWindow(automation);
                Console.WriteLine(mainWindow.Name);
                mainWindow.FindFirstDescendant(cf => cf.ByName("Registration")).AsButton().Click();
                var regWindow = mainWindow.FindFirstChild(cf => cf.ByName("Registration")).AsWindow();
                regWindow.FindFirstDescendant(cf => cf.ByAutomationId("InFName")).AsTextBox().Enter("Yadagiri");
                regWindow.FindFirstDescendant(cf => cf.ByAutomationId("InAge")).AsComboBox().Select("25").Click();

            }
        }
    }
}