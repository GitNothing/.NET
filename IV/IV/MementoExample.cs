using System;
using System.Collections.Generic;

namespace IV
{
    class MementoExample
    {
        //represents the user aka caretaker
        public MementoExample()
        {
            var states = new List<Memento>();
            var app = new Originator();
            states.Add(app.setText("Revision 1"));
            states.Add(app.setText("Revision 2"));
            states.Add(app.setText("Revision 3"));
            states.Add(app.setText("Revision 4"));

            Console.WriteLine("Current: " + app.getText());

            app.setMemento(states[1]); //similar to undo call

            Console.WriteLine("Undo and is now: " + app.getText());
        }

        //represents the application
        class Originator
        {
            private string _text;
            public Memento setText(string input)
            {
                _text = input;
                return new Memento(input);
            }
            public string getText()
            {
                return _text;
            }
            public void setMemento(Memento previousText)
            {
                _text = previousText.getText();
            }
        }

        //represents the data
        class Memento
        {
            private string _text; //state
            public Memento(string text)
            {
                _text = text;
            }
            public string getText()
            {
                return _text;
            }
        }
    }
}
