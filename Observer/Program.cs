using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {

        public interface Observer
        {
            void Subscribe(string message, string chanellName);
        }

        public interface Observable
        {
            void addObserver(Observer obs);
            void removeObserver(Observer obs);
            void notyfyObservers();

        }

        public class YoutubeChanell : Observable
        {
            private string Name;
            private List<string> Messages = new List<string>();
            private List<Observer> Subscribers = new List<Observer>();

            public YoutubeChanell(string name)
            {
                Name = name;
            }

            public void addVideo(string videoName)
            {
                Messages.Add(videoName);
                notyfyObservers();
            }
            public void addObserver(Observer obs)
            {
                Subscribers.Add(obs);
            }

            public void notyfyObservers()
            {
                foreach (Observer observer in Subscribers)
                {
                    observer.Subscribe(Messages[Messages.Count - 1], Name);
                }
            }

            public void removeObserver(Observer obs)
            {
                Subscribers.Remove(obs);
            }
        }


        public class Subscriber : Observer
        {
            private string UserName;

            public Subscriber(string name)
            {
                UserName = name;
            }

            public void Subscribe(string message, string chanellName)
            {
                Console.WriteLine("User Name "+UserName+ " Video: " +message+ " Chanell "+chanellName);
            }
        }

        static void Main(string[] args)
        {
            YoutubeChanell channel = new YoutubeChanell("Code");
            channel.addVideo("js");
            channel.addVideo("c#");
            Subscriber sub1 = new Subscriber("Sam");
            Subscriber sub2 = new Subscriber("Pitt");
            channel.addObserver(sub1);
            channel.addObserver(sub2);
            channel.addVideo("c++");
            channel.addVideo("php");

        }
    }
}
