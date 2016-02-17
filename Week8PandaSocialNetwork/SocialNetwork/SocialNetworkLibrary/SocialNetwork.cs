using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkLibrary
{
    [Serializable]
    public class SocialNetwork : ISocialNetwork
    {
        private Dictionary<Panda, List<Panda>> ListOfPandasInTheNetwork = new Dictionary<Panda, List<Panda>>();

        //public enum GenderType
        //{
        //    Male,
        //    Female
        //}


        public void AddPanda(Panda panda)
        {
            if (!ListOfPandasInTheNetwork.ContainsKey(panda))
            {
                ListOfPandasInTheNetwork.Add(panda, new List<Panda>());
            }
            else
            {
                throw new PandaAlreadyThereException("The user " + panda.pandaName + "is already register in our socialnetwork");
            }
        }

        public bool HasPanda(Panda panda)
        {
            if (ListOfPandasInTheNetwork.ContainsKey(panda))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void MakeFriends(Panda panda1, Panda panda2)
        {
            if (ListOfPandasInTheNetwork.ContainsKey(panda1) && ListOfPandasInTheNetwork.ContainsKey(panda2) == false)
            {
                AddPanda(panda2);
            }
            else if (ListOfPandasInTheNetwork.ContainsKey(panda1) == false && ListOfPandasInTheNetwork.ContainsKey(panda2))
            {
                AddPanda(panda1);
            }
            else if (ListOfPandasInTheNetwork.ContainsKey(panda1) == false && ListOfPandasInTheNetwork.ContainsKey(panda2) == false)
            {
                AddPanda(panda1);
                AddPanda(panda2);
            }

            if (ListOfPandasInTheNetwork[panda1].Contains(panda2) == false)
            {
                ListOfPandasInTheNetwork[panda1].Add(panda2);
            }
            else
            {
                throw new PandasAlreadyFriendsException("The two users are already friends!");
            }

            if (ListOfPandasInTheNetwork[panda2].Contains(panda1) == false)
            {
                ListOfPandasInTheNetwork[panda2].Add(panda1);
            }
            else
            {
                throw new PandasAlreadyFriendsException("The two users are already friends!");
            }
        }

        public bool AreFriends(Panda panda1, Panda panda2)
        {
            if (ListOfPandasInTheNetwork[panda1].Contains(panda2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<string> FriendsOf(Panda panda)
        {
            List<string> friendsHolder = new List<string>();

            if (ListOfPandasInTheNetwork.ContainsKey(panda))
            {
                foreach (var item in ListOfPandasInTheNetwork[panda])
                {
                    friendsHolder.Add(item.ToString());
                }
                return friendsHolder;
            }
            else
            {
                return null;
            }
        }

        public int ConnectionLevel(Panda panda1, Panda panda2)
        {
            if (!HasPanda(panda1) || !HasPanda(panda2))
            {
                return -1;
            }


            var visited = new List<Panda>();
            var queue = new Queue<ConnectionLevelNode>();


            queue.Enqueue(new ConnectionLevelNode()
            {
                Node = panda1,
                Level = 0
            });

            while (queue.Count > 0)
            {
                var pandaContainer = queue.Dequeue();
                visited.Add(pandaContainer.Node);

                if (ListOfPandasInTheNetwork[pandaContainer.Node].Contains(panda2))
                {
                    return pandaContainer.Level + 1;
                }

                foreach (var neighbour in ListOfPandasInTheNetwork[pandaContainer.Node])
                {
                    if (!visited.Contains(neighbour))
                    {

                        queue.Enqueue(new ConnectionLevelNode()
                        {
                            Node = neighbour,
                            Level = pandaContainer.Level + 1
                        });
                    }
                }
            }

            return -1;
        }


        public bool AreConnected(Panda panda1,Panda panda2)
        {
            var visited = new List<Panda>();
            var queue = new Queue<Panda>();

            queue.Enqueue(panda1);
            while (queue.Count > 0)
            {
                var pandaContainer = queue.Dequeue();
                visited.Add(pandaContainer);

                if (ListOfPandasInTheNetwork[pandaContainer].Contains(panda2))
                {
                    return true;
                }
                foreach (var neighbour in ListOfPandasInTheNetwork[pandaContainer])
                {
                    if (!visited.Contains(neighbour))
                    {
                        queue.Enqueue(neighbour);
                    }
                }
            }
            return false;                         
        }

        public int HowManyGenderInNetwork(int level, Panda panda, Panda.GenderType genderType)
        {
            var visited = new List<Panda>();
            var queue = new Queue<ConnectionLevelNode>();
            int genderResult = 0;

            queue.Enqueue(new ConnectionLevelNode()
            {
                Node = panda,
                Level = 0
            });

            while (queue.Count > 0)
            {
                var pandaContainer = queue.Dequeue();
                visited.Add(pandaContainer.Node);

                if (pandaContainer.Level <= level)
                {
                    if (pandaContainer.Node.pandaGender == genderType)
                    {
                        genderResult = genderResult + 1;
                    }
                }
                else
                {
                    break;
                }
                foreach (var neighbour in ListOfPandasInTheNetwork[pandaContainer.Node])
                {
                    if (!visited.Contains(neighbour))
                    {
                        queue.Enqueue(new ConnectionLevelNode()
                        {
                            Node = neighbour,
                            Level = pandaContainer.Level + 1
                        });
                    }
                }
            }
            return genderResult;

        }


        private class ConnectionLevelNode
        {
            public Panda Node { get; set; }
            public int Level { get; set; }
        }


    }
}
