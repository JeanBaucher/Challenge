using log4net;
using System;
using System.Web.Services;
using WebServiceLibrary;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    private static readonly ILog log = LogManager.GetLogger(typeof(Service));

    public Service()
    {
        log4net.Config.XmlConfigurator.Configure();
        //Uncomment the following line if using designed components 
        //InitializeComponent();        
    }

    [WebMethod]
    public string Fibonacci(int n)
    {
        log.Debug(String.Format("Request Fibonnacci({0})", n));

        string result = Util.Fibonacci(n);

        log.Debug(String.Format("Response Fibonnacci = {0}", result));

        return result;
    }

    [WebMethod]
    public string XmlToJson(string xml)
    {
        log.Debug(String.Format("Request XmlToJson({0})", xml));

        //cf http://www.newtonsoft.com/json/help/html/ConvertingJSONandXML.htm
        string jsonText = String.Empty;

        try
        {
            jsonText = Util.XmlToJson(xml);
        }
        catch (Exception e)
        {
            log.Error("XmlToJson error : ", e);
        }

        log.Debug(String.Format("Response XmlToJson = {0}", jsonText));

        return jsonText;
    }
}