using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkLibrary
{
    interface ISocialNetwork
    {

        void AddPanda(Panda panda);
        bool HasPanda(Panda panda);
        void MakeFriends(Panda panda1, Panda panda2);
        bool AreFriends(Panda panda1, Panda panda2);
        List<string> FriendsOf(Panda panda);
        int ConnectionLevel(Panda panda1, Panda panda2);
        bool AreConnected(Panda panda1, Panda panda2);
        int HowManyGenderInNetwork(int level, Panda panda, Panda.GenderType Gender);

    }
}
