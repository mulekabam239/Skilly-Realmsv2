#region

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

#endregion

namespace server.app
{
    internal class getLanguageStrings : RequestHandler
    {
        public static readonly Dictionary<string, string> languages = new Dictionary<string, string>
        {
            {"en", File.ReadAllText("app/Languages/en.txt")},
        };

        protected override void HandleRequest()
        {
            string lang;
            byte[] buf;
            if (Query.AllKeys.Length > 0)
                if (!languages.TryGetValue(Query["languageType"], out lang))
                    buf = Encoding.ASCII.GetBytes("<Error>Invalid langauge type.</Error>");
                else buf = Encoding.ASCII.GetBytes(lang);
            else
                buf = Encoding.ASCII.GetBytes("<Error>Invalid langauge type.</Error>");
            Context.Response.OutputStream.Write(buf, 0, buf.Length);
        }
    }
}