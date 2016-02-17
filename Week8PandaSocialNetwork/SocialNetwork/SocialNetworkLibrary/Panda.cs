using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkLibrary
{
    public class Panda
    {
        public enum GenderType
        {
            Male,
            Female
        }
        private string PandaName;
        private string PandaEmail;
        private GenderType PandaGender;


        public string pandaName { get { return PandaName; } set { PandaName = value; } }
        public string pandaEmail { get { return PandaEmail; } set { PandaEmail = value; } }
        public GenderType pandaGender { get { return PandaGender; } set { PandaGender = value; } }

        public Panda(string name, string email, GenderType gender)
        {
            PandaName = name;
            PandaEmail = email;
            PandaGender = gender;
        }

        public bool IsMale(Panda panda)
        {
            if (panda.pandaGender.Equals("Male"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFemale(Panda panda)
        {
            if (panda.IsMale(panda))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsValidEmail()
        {
            if ((pandaEmail.Contains("@")) && (pandaEmail.Contains(".com")))
            {
                return true;
            }
            else
            {
                throw new InvalidEmailException("Please enter a valid email address.");
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0}  Email: {1} Gender: {2}", pandaName, pandaEmail, pandaGender);
        }
    }
}
