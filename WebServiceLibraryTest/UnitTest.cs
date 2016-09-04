using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebServiceLibrary;

namespace WebServiceLibraryUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFibonacci1()
        {
            Assert.AreEqual("-1", Util.Fibonacci(-100));
            Assert.AreEqual("-1", Util.Fibonacci(1000));
            Assert.AreEqual("-1", Util.Fibonacci(0));
            Assert.AreEqual("-1", Util.Fibonacci(101));
            Assert.AreEqual("1", Util.Fibonacci(1));
            Assert.AreEqual("1", Util.Fibonacci(2));
            Assert.AreEqual("2", Util.Fibonacci(3));
            Assert.AreEqual("3", Util.Fibonacci(4));
            Assert.AreEqual("218922995834555169026", Util.Fibonacci(99));
            Assert.AreEqual("354224848179261915075", Util.Fibonacci(100));
        }

        [TestMethod]
        public void TestXmlToJson()
        {
            Assert.AreEqual("{\r\n  \"foo\": \"bar\"\r\n}", Util.XmlToJson(@"<foo>bar</foo>"));
            Assert.AreEqual(@"Bad Xml format", Util.XmlToJson(@"<foo>hello</bar>"));
            string actual = Util.XmlToJson(@"<TRANS><HPAY><ID>103</ID><STATUS>3</STATUS><EXTRA><IS3DS>0</IS3DS><AUTH>031183</AUTH></EXTRA><INT_MSG/><MLABEL>501767XXXXXX6700</MLABEL><MTOKEN>project01</MTOKEN></HPAY></TRANS>");
            string expected = "{\r\n  \"TRANS\": {\r\n    \"HPAY\": {\r\n      \"ID\": \"103\",\r\n      \"STATUS\": \"3\",\r\n      \"EXTRA\": {\r\n        \"IS3DS\": \"0\",\r\n        \"AUTH\": \"031183\"\r\n      },\r\n      \"MLABEL\": \"501767XXXXXX6700\",\r\n      \"MTOKEN\": \"project01\"\r\n    }\r\n  }\r\n}";
            Assert.AreEqual(expected, actual);
        }
    }
}
