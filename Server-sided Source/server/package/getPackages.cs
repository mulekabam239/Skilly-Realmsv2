#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

#endregion

namespace server.package
{
    internal class getPackages : RequestHandler
    {
        internal static Dictionary<string, Package> CurrentPackages { get; set; }

        protected override void HandleRequest()
        {
            string s = Serialize();

            using (StreamWriter wtr = new StreamWriter(Context.Response.OutputStream))
                wtr.Write(s);
        }

        internal static string Serialize()
        {
            XmlDocument doc = new XmlDocument();
            XmlNode packageResponse = doc.CreateElement("PackageResponse");
            doc.AppendChild(packageResponse);
            

            
            StringWriter wtr = new StringWriter();
            doc.Save(wtr);
            return wtr.ToString();
        }
    }

    public class Package
    {
        
        
           
                    };
                }
            
        
    
