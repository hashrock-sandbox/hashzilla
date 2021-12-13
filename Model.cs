using Reactive.Bindings;
using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Windows;

namespace hash_browser
{
      public class Model
    {
        public ReactiveProperty<string> Message { get; private set; }
        public ReactiveCommand ShowMessage { get; private set; }

        public ReactiveCollection<string> Items { get; private set; }

        public Model()
        {
            Message = new ReactiveProperty<string>("Hello");
            ShowMessage = Message.Select(i => i.Length > 0).ToReactiveCommand();

            ShowMessage.Subscribe(() =>
            {
                Console.WriteLine("Hello");
                MessageBoxResult result = MessageBox.Show(Message.Value, "Sample App", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            });

            Items = new ReactiveCollection<string>()
            {
                "https://twitter.com/",
                "https://github.com/",
            };

        }
    }
}