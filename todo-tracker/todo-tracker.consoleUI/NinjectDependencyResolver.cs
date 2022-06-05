using System;
using Ninject.Modules;

using todo_tracker.consoleUI.ConsoleManager;
using todo_tracker.consoleUI.ProgramManager;

namespace todo_tracker.consoleUI
{
    public class NinjectDependencyResolver : NinjectModule
    {
        public override void Load()
        {
            Bind<IConsoleManager>().To<ConsoleManager.ConsoleManager>();
            Bind<IProgramManager>().To<ProgramManager.ProgramManager>();
        }
    }
}

