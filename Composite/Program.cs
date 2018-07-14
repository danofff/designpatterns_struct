using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        public interface Developer
        {
            void WriteCode();
        }

        public class CPPDeveloper : Developer
        {
            public void WriteCode()
            {
                Console.WriteLine("c++ developer");
            }
        }

        public class JavaDeveloper : Developer
        {
            public void WriteCode()
            {
                Console.WriteLine("java developer");
            }
        }

        public class TeamComposite : Developer
        {
            private string Name;
            public TeamComposite(string name)
            {
                Name = name;
            }

            private List<Developer> Developers = new List<Developer>();
            public void AddDeveloper(Developer dev)
            {
                Developers.Add(dev);
            }

            public void RemoveDeveloper(Developer dev)
            {
                Developers.Remove(dev);
            }

            public void WriteCode()
            {
                Console.WriteLine("Team: " + Name + " writes  project") ;
                foreach (var item in Developers)
                {
                    item.WriteCode();
                }
            }
        }


        static void Main(string[] args)
        {
        }
    }
}
