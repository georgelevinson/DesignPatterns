using Autofac;
using Autofac.Features.Metadata;
using MoreLinq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Adapter
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            //==============================================

            //VectorToRaster.Draw();
            //VectorToRaster.Draw();

            //var v = new Vector2i(1, 1);
            //var vv = new Vector2i(3,2);

            //var result = (v + vv);

            //var u = Vector3f.Create(3.4f, 2.2f, 1);

            //Console.WriteLine(u);
            //Console.WriteLine(result);

            //==============================================

            var b = new ContainerBuilder();
            b.RegisterType<SaveCommand>().As<ICommand>()
                .WithMetadata("Name", "Save");
            b.RegisterType<OpenCommand>().As<ICommand>()
                .WithMetadata("Name", "Open");
            //b.RegisterType<Button>();
            //b.RegisterAdapter<ICommand, Button>(cmd => new Button(cmd));
            b.RegisterAdapter<Meta<ICommand>, Button>(cmd => new Button(cmd.Value, (string)cmd.Metadata["Name"]));
            b.RegisterType<Editor>();

            using(var c = b.Build())
            {
                var editor = c.Resolve<Editor>();
                //editor.ClickAll();

                foreach (var btn in editor.Buttons)
                    btn.PrintMe();
            }

            //==============================================
        }
    }
}
