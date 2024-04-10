using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WpfApp8
{
    public class CounterModule(CounterViewModel viewModel) : IModule
    {
        private readonly CounterViewModel _viewModel = viewModel;

        public void OnInitialized(IContainerProvider containerProvider)
        {
            LoadState();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Регистрация типов, если это необходимо
        }

        public void SaveState()
        {
            var json = JsonSerializer.Serialize(_viewModel.Counter);
            File.WriteAllText("counter.json", json);
        }

        public void LoadState()
        {
            if (File.Exists("counter.json"))
            {
                var json = File.ReadAllText("counter.json");
                _viewModel.Counter = JsonSerializer.Deserialize<int>(json);
            }
        }
    }
}
