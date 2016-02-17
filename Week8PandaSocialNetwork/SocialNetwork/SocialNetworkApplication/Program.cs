using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworkLibrary;

namespace SocialNetworkApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Panda panda1 = new Panda(name: "Peter", email: "peter@hackbg.com", gender: Panda.GenderType.Male);
            Panda panda2 = new Panda(name: "Maria", email: "maria@hackbg.com", gender: Panda.GenderType.Female);
            Panda panda3 = new Panda(name: "Jim", email: "jim@hackbg.com", gender: Panda.GenderType.Male);
            Panda panda4 = new Panda(name: "Jennifer", email: "jennifer@yahoo.com", gender: Panda.GenderType.Female);
            Panda panda5 = new Panda(name: "Joe", email: "joe@google.com", gender: Panda.GenderType.Male);
            Panda panda6 = new Panda(name: "Tim", email: "Tim@google.com", gender: Panda.GenderType.Male);
            Panda panda7 = new Panda(name: "Bob", email: "bob@hackbg.com", gender: Panda.GenderType.Male);
            Panda panda8 = new Panda(name: "Victoria", email: "victoria@google.com", gender: Panda.GenderType.Female);
            Panda panda9 = new Panda(name: "Julie", email: "julie@hackbg.com", gender: Panda.GenderType.Female);
            Panda panda10 = new Panda(name: "Jerry", email: "jerryhackbg.com", gender: Panda.GenderType.Male);

            SocialNetwork network = new SocialNetwork();

            network.AddPanda(panda1);
            network.AddPanda(panda2);
            network.AddPanda(panda3);
            network.AddPanda(panda4);
            network.AddPanda(panda5);
            network.AddPanda(panda6);
            network.AddPanda(panda7);
            network.AddPanda(panda8);
            network.AddPanda(panda9);

            network.MakeFriends(panda1, panda2);
            network.MakeFriends(panda1, panda3);
            network.MakeFriends(panda2, panda4);
            network.MakeFriends(panda2, panda5);
            network.MakeFriends(panda3, panda6);
            network.MakeFriends(panda3, panda7);
            network.MakeFriends(panda4, panda8);
            network.MakeFriends(panda4, panda9);

            Console.WriteLine(network.HowManyGenderInNetwork(3,panda1,Panda.GenderType.Female));
            Console.WriteLine(network.ConnectionLevel(panda1,panda9));
            Console.WriteLine(network.AreFriends(panda1,panda8));
            Console.WriteLine(network.AreConnected(panda2, panda10));
        //    panda1.IsValidEmail();
            Console.Read();
        }
    }
}
