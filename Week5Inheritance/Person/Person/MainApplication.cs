using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    class MainApplication
    {
        static void Main()
        {
            List<Person> People = new List<Person>();

            Adult Mike = new Adult("Mike", "Male");
            Adult Rebbeca = new Adult("Rebbeca", "Female");
            Children Fin = new Children("Fin", "Male");
            Children Annie = new Children("Annie", "Female");


            People.Add(Mike);
            People.Add(Rebbeca);
            People.Add(Fin);
            People.Add(Annie);

            Mike.HaveKids(new Children("Tommy", "Male"));
            Mike.HaveKids(new Children("Will", "Male"));
            Rebbeca.HaveKids(new Children("Lisa", "Female"));


            Fin.GetToys(new Toy("blue", 20));
            Fin.GetToys(new Toy("red", 15));
            Annie.GetToys(new Toy("pink", 20));

            Mike.IsBoring = false;
            Rebbeca.IsBoring = true;

            foreach (var person in People)
            {
                if (person is Children)
                {
                    Children child = (Children)person;
                    Console.WriteLine(child.ToString());
                    child.Play();
                }
                else if (person is Adult)
                {
                    Adult adult = (Adult)person;
                    Console.WriteLine(adult.ToString());
                    adult.Work();
                } else
                {
                    throw new ArgumentException("The person doesn't exist in our servers.");
                }

            }
            Console.Read();

        }
    }
}
