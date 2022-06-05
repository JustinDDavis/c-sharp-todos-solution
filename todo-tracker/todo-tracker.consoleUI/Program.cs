using Ninject;
using System.Reflection;
using todo_tracker.consoleUI.ProgramManager;

var kernel = new StandardKernel();
kernel.Load(Assembly.GetExecutingAssembly());

IProgramManager m_ProgramManager = kernel.Get<IProgramManager>();
m_ProgramManager.Run();
