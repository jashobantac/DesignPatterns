using System;
using System.Collections.Generic;

namespace Structural.AdapterDesignPattern
{
    public interface ITarget
    {
        List<string> GetNames();
    }

    public class Adapter : Adaptee, ITarget
    {
        public List<string> GetNames()
        {
            Adaptee adaptee = new Adaptee();
            string nameString = GetNameString();
            if (string.IsNullOrEmpty(nameString))
            {
                return new List<string>();
            }

            string[] names = nameString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return new List<string>(names);
        }
    }
}
