using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{

    internal class Program
    {

        abstract class Widget
        {
            public abstract void draw();
        }

         class TextField : Widget
        {
            private int width;
            private int height;

            public TextField(int w, int h)
            {
                width = w;
                height = h;
            }
            public override void draw()
            {
                Console.WriteLine("Drawing text field..");
             }
        }
        abstract class Decorator : Widget
        {
            private Widget wid;

             public Decorator(Widget w) {
                wid = w;
            
            }
            public override void draw()
            {
                wid.draw();
            }
        }

        class BorderDecorator : Decorator
        {
            public BorderDecorator(Widget w) : base(w) { }
            

             public override void draw()
            {
                base.draw();
                Console.WriteLine("I am a border decorator holding a text field...");
                
            }
            
        }

        class ScrollDecorator : Decorator
        {
            public ScrollDecorator(Widget w) : base(w){ }
            public override void draw()
            {
                base.draw();
                Console.WriteLine("I am a scroll decorator, holding a border decorator...");
                
            }
        }

        class newBorder : Decorator
        {
            public newBorder(Widget w) : base(w) { }
            public override void draw()
            {
                base.draw();
                Console.WriteLine("I am a scroll decorator, holding a text field...");

            }
        }

        static void Main(string[] args)
        {
            TextField textField = new TextField(50, 50);


            BorderDecorator borderDecorator = new BorderDecorator(textField);

            ScrollDecorator scrollDecorator = new ScrollDecorator(borderDecorator);

            newBorder newBorder = new newBorder(textField);
            scrollDecorator.draw();

        }
    }
}
