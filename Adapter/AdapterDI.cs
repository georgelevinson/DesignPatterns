using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter
{
    public interface ICommand
    {
        void Execute();
    }
    class SaveCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Saving a file");
        }
    }
    class OpenCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Opening a file");
        }
    }
    public class Button
    {
        private ICommand _command;
        private string _name;
        public Button(ICommand command, string name)
        {
            if (command == null)
                throw new ArgumentNullException();

            _command = command;
            _name = name;
        }
        public void Click()
        {
            _command.Execute();
        }
        public void PrintMe()
        {
            Console.WriteLine($"I'm a button called {_name}");
        }
    }
    public class Editor
    {
        private IEnumerable<Button> _buttons;
        public IEnumerable<Button> Buttons => _buttons;

        public Editor(IEnumerable<Button> buttons)
        {
            if (buttons == null)
                throw new ArgumentNullException();

            _buttons = buttons;
        }
        public void ClickAll()
        {
            foreach (var btn in _buttons)
                btn.Click();
        }
    }
}
