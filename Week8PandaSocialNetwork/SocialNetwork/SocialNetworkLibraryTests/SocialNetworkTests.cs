using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetworkLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkLibrary.Tests
{
    [TestClass()]
    public class SocialNetworkTests
    {

        [TestMethod()]
        public void ConnectionLevelBetweenTwoPandasInTheNetworkTest()
        {
            // FirstStep - SetUp for the test
            var network = new SocialNetwork();
            var panda1 = new Panda("Tosho", "tosho@.com", Panda.GenderType.Male);
            var panda2 = new Panda("Gosho", "gosho@.com", Panda.GenderType.Male);
            var panda3 = new Panda("Bob", "bob@.com", Panda.GenderType.Male);
            var panda4 = new Panda("Tom", "tom@.com", Panda.GenderType.Male);
            var panda5 = new Panda("Joe", "joe@.com", Panda.GenderType.Male);
            var panda6 = new Panda("Peter", "peter@.com", Panda.GenderType.Male);
            var panda7 = new Panda("Stewie", "swewie@.com", Panda.GenderType.Male);

            network.AddPanda(panda1);
            network.AddPanda(panda2);
            network.AddPanda(panda3);
            network.AddPanda(panda4);
            network.AddPanda(panda5);
            network.AddPanda(panda6);
            network.AddPanda(panda7);
          

            network.MakeFriends(panda1, panda2);
            network.MakeFriends(panda1, panda3);
            network.MakeFriends(panda2, panda4);
            network.MakeFriends(panda2, panda5);
            network.MakeFriends(panda5, panda6);
            network.MakeFriends(panda3, panda7);
            //...


            //SecondStep - ResultToCheck if your method is working (you should calculate the res value before the test)
            // In order know what the result would be.
            int res = network.ConnectionLevel(panda1, panda6);


            //ThirdStep - TestResult - if the outcome is equal to what you've expected => your method works.
            Assert.IsTrue(res == 3);
        }

        [TestMethod()]
        public void AreTwoPandasInTheNetworkConnectedTest()
        {

            // FirstStep
            var network = new SocialNetwork();
            var panda1 = new Panda("Tosho", "tosho@.com", Panda.GenderType.Male);
            var panda2 = new Panda("Gosho", "gosho@.com", Panda.GenderType.Male);
            var panda3 = new Panda("Bob", "bob@.com", Panda.GenderType.Male);
            var panda4 = new Panda("Tom", "tom@.com", Panda.GenderType.Male);
            var panda5 = new Panda("Joe", "joe@.com", Panda.GenderType.Male);
            var panda6 = new Panda("Peter", "peter@.com", Panda.GenderType.Male);
            var panda7 = new Panda("Stewie", "swewie@.com", Panda.GenderType.Male);
            var panda8 = new Panda("t", "t@.com", Panda.GenderType.Female);

            network.AddPanda(panda1);
            network.AddPanda(panda2);
            network.AddPanda(panda3);
            network.AddPanda(panda4);
            network.AddPanda(panda5);
            network.AddPanda(panda6);
            network.AddPanda(panda7);


            network.MakeFriends(panda1, panda2);
            network.MakeFriends(panda1, panda3);
            network.MakeFriends(panda2, panda4);
            network.MakeFriends(panda2, panda5);
            network.MakeFriends(panda5, panda6);
            //network.MakeFriends(panda3, panda7);

            // SecondStep
            bool result = network.AreConnected(panda1, panda6);

            //ThirdStep
            Assert.IsTrue(result == true);
        }
            [TestMethod()]
        public void HowManyGivenGenderTypesAreInASpecificLevelDepthInOurNetworkTest()
        {

            //FirstStep
            var network = new SocialNetwork();
            var panda1 = new Panda("Tosho", "tosho@.com", Panda.GenderType.Male);
            var panda2 = new Panda("Gosho", "gosho@.com", Panda.GenderType.Female);
            var panda3 = new Panda("Bob", "bob@.com", Panda.GenderType.Male);
            var panda4 = new Panda("Tom", "tom@.com", Panda.GenderType.Female);
            var panda5 = new Panda("Joe", "joe@.com", Panda.GenderType.Male);
            var panda6 = new Panda("Peter", "peter@.com", Panda.GenderType.Female);
            var panda7 = new Panda("Stewie", "swewie@.com", Panda.GenderType.Male);
            var panda8 = new Panda("t", "t@.com", Panda.GenderType.Female);

            network.AddPanda(panda1);
            network.AddPanda(panda2);
            network.AddPanda(panda3);
            network.AddPanda(panda4);
            network.AddPanda(panda5);
            network.AddPanda(panda6);
            network.AddPanda(panda7);
            network.AddPanda(panda8);

            network.MakeFriends(panda1, panda2);
            network.MakeFriends(panda1, panda3);
            network.MakeFriends(panda2, panda4);
            network.MakeFriends(panda2, panda5);
            network.MakeFriends(panda5, panda6);
            network.MakeFriends(panda3, panda7);
            network.MakeFriends(panda3, panda8);

            //SecondStep
            int result = network.HowManyGenderInNetwork(3, panda1, Panda.GenderType.Female);

            //ThirdStep
            Assert.IsTrue(result == 4);
        
        }



        }
    }
