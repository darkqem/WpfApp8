using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WpfApp8
{
    public class CounterViewModel : BindableBase
    {
        private int _counter;
        private const string FileName = "counter.json";

        public int Counter
        {
            get { return _counter; }
            set { SetProperty(ref _counter, value); }
        }

        public DelegateCommand IncrementCounterCommand { get; private set; }
        public DelegateCommand ResetCounterCommand { get; private set; }

        public CounterViewModel()
        {
            IncrementCounterCommand = new DelegateCommand(IncrementCounter);
            ResetCounterCommand = new DelegateCommand(ResetCounter);
            var counterModule = new CounterModule(this);
            counterModule.LoadState();
        }
        private void ResetCounter()
        {
            Counter = 0;
            var counterModule = new CounterModule(this);
            counterModule.SaveState();
        }
        private void IncrementCounter()
        {
            Counter++;
            var counterModule = new CounterModule(this);
            counterModule.SaveState();
        }
        
    }
}
