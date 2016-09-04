using Newtonsoft.Json;
using System;
using System.Numerics;
using System.Xml;


namespace WebServiceLibrary
{
    public static class Util
    {
        /// <summary>
        /// Renvoie le n ième terme de la suite de Fibonnacci pour n entre 1 et 100 inclus
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string Fibonacci(int n)
        {
            BigInteger result = -1;

            if (1 <= n && n <= 100)
            {
                BigInteger n1 = 0;
                BigInteger n2 = 1;
                BigInteger n3 = 1;

                for (long i = 1; i < n; i++)
                {
                    n3 = n1 + n2;
                    n1 = n2;
                    n2 = n3;
                }

                result = n3;
            }
            else
            {
                result = -1;
            }

            return result.ToString();
        }

        /// <summary>
        /// Convertit une chaine XML en JSON, sans le noeud <INT_MSG/> conforméméent au dernier exemple
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static string XmlToJson(string xml)
        {
            string jsonText = String.Empty;

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                var nodeMSG = doc.SelectSingleNode(@"//INT_MSG");
                if (nodeMSG != null)
                {
                    nodeMSG.ParentNode.RemoveChild(nodeMSG);
                }

                jsonText = JsonConvert.SerializeXmlNode(doc,
                                Newtonsoft.Json.Formatting.Indented
                                );
            }
            catch (XmlException)
            {
                jsonText = "Bad Xml format";
            }

            return jsonText;
        }
    }
}
