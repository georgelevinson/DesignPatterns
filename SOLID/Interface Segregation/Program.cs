using System;

namespace SOLID_I
{
    public class Document
    {

    }
    public interface IPrinter
    {
        void Print(Document doc);
    }

    public interface IScanner
    {
        void Scan(Document doc);
    }
    public interface IFax
    {
        void Fax(Document doc);
    }
    public interface IMultifunctionDevice : IScanner, IPrinter, IFax
    {

    }
    public class Photocopier : IPrinter, IScanner
    {
        public void Print(Document doc)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document doc)
        {
            throw new NotImplementedException();
        }
    }
    public class MultifunctionMachine : IMultifunctionDevice
    {
        public void Fax(Document doc)
        {
            throw new NotImplementedException();
        }

        public void Print(Document doc)
        {
            throw new NotImplementedException();
        }

        public void Scan(Document doc)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}