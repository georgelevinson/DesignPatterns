using System;
using System.Text;
using System.Collections.Generic;

namespace Builder_Exercise
{
    public class CodeBuilder
    {
        public string Name { get; }
        public List<Field> Fields { get; set; }

        public CodeBuilder(string className)
        {
            Name = className;
            Fields = new List<Field>();
        }
        public class Field
        {
            private string name;
            private string type;
            private int indent = 2;
            public Field(string name, string type)
            {
                this.name = name;
                this.type = type;
            }

            public override string ToString()
            {
                var sb = new StringBuilder();

                sb.Append(new string(' ', indent) + $"public {type} {name};");

                return sb.ToString();
            }
        }
        public CodeBuilder AddField(string name, string type)
        {
            Fields.Add(new Field(name, type));
            return this;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"public class {Name}");
            sb.AppendLine("{");
            foreach (var f in Fields)
            {
                sb.AppendLine(f.ToString());
            }
            sb.AppendLine("}");
            return sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var cb = new CodeBuilder("Person")
                .AddField("Name", "string")
                .AddField("Age", "int")
                .AddField("Employment", "bool");
            Console.WriteLine(cb);
        }
    }
}
