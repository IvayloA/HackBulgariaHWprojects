using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLMarkupLibrary;

namespace XMLMarkupBulderApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            XMLMarkupBuilder builder = new XMLMarkupBuilder();

            builder.openTag("Tag");
            builder.addAttribute("ID", "25");
            builder.openTag("Tag2");
            builder.addText("Random text was added");
            builder.closeTag();
            builder.openTag("Tag3");
            builder.addAttribute("Name", "Bob");
            builder.finish();

            Console.WriteLine(builder.getResult());
            Console.Read();
        }
    }
}
