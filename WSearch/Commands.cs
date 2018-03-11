using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WSearch.Parsing;
using WSearch.ViewModel;

namespace WSearch
{
    class Command : ICommand
    {
        private Action<object> execute;
        private Func<object,bool> canExecute;

        public Command(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }

    class Commands
    {
        static Commands()
        {
            StartParsing = new Command((o) =>
            {
                var worker = ServiceLocator.Current.GetInstance<Worker>(); //<List<string>  //worker.newData += Worker_newData;
                worker.Run();

            });
        }

        //private static void Worker_newData(object arg1, List<string> page)
        //{
        //    foreach (var p in page)
               
        //}

        public static Command StartParsing { get; set; }
    }
}
