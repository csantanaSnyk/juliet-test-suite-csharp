/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE83_XSS_Attribute__Web_NetClient_17.cs
Label Definition File: CWE83_XSS_Attribute__Web.label.xml
Template File: sources-sink-17.tmpl.cs
*/
/*
* @description
* CWE: 83 Cross Site Scripting (XSS) in attributes; Examples(replace QUOTE with an actual double quote): ?img_loc=http://www.google.comQUOTE%20onerror=QUOTEalert(1) and ?img_loc=http://www.google.comQUOTE%20onerror=QUOTEjavascript:alert(1)
* BadSource: NetClient Read data from a web server with WebClient
* GoodSource: A hardcoded string
* BadSink: Write XSS in img src attribute
* Flow Variant: 17 Control flow: for loops
*
* */

using TestCaseSupport;
using System;

using System.Web;

using System.IO;
using System.Net;

namespace testcases.CWE83_XSS_Attribute
{

class CWE83_XSS_Attribute__Web_NetClient_17 : AbstractTestCaseWeb
{
#if (!OMITBAD)
    /* uses badsource and badsink */
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        string data;
        data = ""; /* Initialize data */
        /* read input from WebClient */
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    using (StreamReader sr = new StreamReader(client.OpenRead("http://www.example.org/")))
                    {
                        /* POTENTIAL FLAW: Read data from a web server with WebClient */
                        /* This will be reading the first "line" of the response body,
                        * which could be very long if there are no newlines in the HTML */
                        data = sr.ReadLine();
                    }
                }
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Error with stream reading");
            }
        }
        for (int i = 0; i < 1; i++)
        {
            if (data != null)
            {
                /* POTENTIAL FLAW: Input is not verified/sanitized before use in an image tag */
                resp.Write("<br>Bad() - <img src=\"" + data +"\">");
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink by reversing the block outside the
     * for statement with the one in the for statement */
    private void GoodG2B(HttpRequest req, HttpResponse resp)
    {
        string data;
        /* FIX: Use a hardcoded string */
        data = "foo";
        for (int i = 0; i < 1; i++)
        {
            if (data != null)
            {
                /* POTENTIAL FLAW: Input is not verified/sanitized before use in an image tag */
                resp.Write("<br>Bad() - <img src=\"" + data +"\">");
            }
        }
    }

    public override void Good(HttpRequest req, HttpResponse resp)
    {
        GoodG2B(req, resp);
    }
#endif //omitgood
}
}
