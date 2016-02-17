using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XMLMarkupLibrary;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void addAttributeWithNoOpenTagsTest()
        {
            //arrange
            XMLMarkupBuilder test = new XMLMarkupBuilder();
           // test.openTag("attribute");
            string attrName = "test";
            string attrValue = "23";
            
                test.addAttribute(attrName, attrValue);

            //assert
                  Assert.Fail();
        }

        [TestMethod]
        public void TestMethod1()
        {
       
        }
    }
}
