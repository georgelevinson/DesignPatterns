using System;
using System.Text;
using System.Collections.Generic;

namespace Without
{
    class Program
    {
        public class HtmlElement
        {
            public string Name, Text;
            public List<HtmlElement> Elements = new List<HtmlElement>();
            private const int indentSize = 2;
            
            public HtmlElement()
            {

            }
            public HtmlElement(string name, string text)
            {
                Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
                Text = text ?? throw new ArgumentNullException(paramName: nameof(text));
            }
            private string ToStringImpl(int indent)
            {
                var sb = new StringBuilder();
                var i = new string(' ', indentSize * indent);

                sb.AppendLine($"{i}<{Name}>");

                if (!string.IsNullOrWhiteSpace(Text))
                {
                    sb.Append(new string(' ', indentSize * (indent + 1)));
                    sb.AppendLine(Text);
                }

                foreach (var e in Elements)
                {
                    sb.Append(e.ToStringImpl(indent + 1));
                }
                sb.AppendLine($"{i}</{Name}>");

                return sb.ToString();
            }
            public override string ToString()
            {
                return ToStringImpl(0);
            }

        }
        public class HtmlBuilder
        {
            private readonly string _rootName;
            HtmlElement root = new HtmlElement();
            public HtmlBuilder(string rootName)
            {
                _rootName = rootName;
                root.Name = rootName;
            }
            public HtmlBuilder AddChild(string ChildName, string childText)
            {
                var e = new HtmlElement(ChildName, childText);
                root.Elements.Add(e);
                return this;
            }
            public override string ToString()
            {
                return root.ToString(); 
            }
            public void Clear()
            {
                root = new HtmlElement { Name = _rootName };
            }
        }
        static void Main(string[] args)
        {

            //LEGACY CODE FOR CREATING HTML WITHOUT BUILDER
            var hello = "hello";
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");
            Console.WriteLine(sb);
            sb.Clear();

            var words = new[] { "hello", "world" };
            sb.Append("<ul>");
            foreach (var word in words)
            {
                sb.AppendFormat($"<li>{word}</li>");
            }
            sb.Append("</ul>");

            Console.WriteLine(sb);

            //PROPER CODE FOR CREATING HTML USING BUILDER AND HTMLELEMENT CLASSES

            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "hello").AddChild("li", "world"); ;
            Console.WriteLine(builder);

        }
    }
}
