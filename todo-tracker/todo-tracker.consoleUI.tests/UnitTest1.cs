using System;
using System.Collections.Generic;
using NUnit.Framework;
using todo_tracker.consoleUI.ConsoleManager;

namespace todo_tracker.consoleUI.tests;

public class ProgramManagerTests
{
    private ConsoleManagerStub m_ConsoleManager = null;
    private ProgramManager.ProgramManager m_ProgramManager = null;

    [SetUp]
    public void Setup()
    {
        m_ConsoleManager = new ConsoleManagerStub();
        m_ProgramManager = new ProgramManager.ProgramManager(m_ConsoleManager);
    }

    [TearDown]
    public void TearDown()
    {
        m_ProgramManager = null;
        m_ConsoleManager = null;
    }

    [TestCase("Ahmen")]
    public void RunWithInputas1andName(string name)
    {
        m_ConsoleManager.UserInputs.Enqueue("1");
        m_ConsoleManager.UserInputs.Enqueue(name);
        m_ConsoleManager.UserInputs.Enqueue(new ConsoleKeyInfo());

        var expectedOutput = new List<string>
            {
            "Welcome to my console app\r\n",
            "Welcome to my console app\r\n[1] Say Hello?\r\n",
            "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n",
            "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\n",
            "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: ",
            "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 1\r\n",
            "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 1\r\nPlease enter your name: ",
            "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 1\r\nPlease enter your name: " + name + "\r\n",
            "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 1\r\nPlease enter your name: " + name + "\r\nHello " + name +"\r\n",
            "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 1\r\nPlease enter your name: " + name + "\r\nHello " + name +"\r\n\r\n",
            "Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 1\r\nPlease enter your name: " + name + "\r\nHello " + name +"\r\n\r\nPress any key to exit... "
            };

        m_ConsoleManager.OutputsUpdated +=
            outputEntryNumber =>
            {
                Assert.AreEqual(
                    expectedOutput[outputEntryNumber - 1],
                    m_ConsoleManager.ToString()
                    );
            };

        m_ProgramManager.Run();

    }
}
