/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE81_XSS_Error_Message__Web_Get_Cookies_Web_81_base.cs
Label Definition File: CWE81_XSS_Error_Message__Web.label.xml
Template File: sources-sink-81_base.tmpl.cs
*/
/*
 * @description
 * CWE: 81 Cross Site Scripting (XSS) in Error Message
 * BadSource: Get_Cookies_Web Read data from the first cookie using Cookies
 * GoodSource: A hardcoded string
 * Sinks: ErrorStatusCode
 *    BadSink : XSS in StatusCode
 * Flow Variant: 81 Data flow: data passed in a parameter to an abstract method
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE81_XSS_Error_Message
{
abstract class CWE81_XSS_Error_Message__Web_Get_Cookies_Web_81_base
{
    public abstract void Action(string data , HttpRequest req, HttpResponse resp);
}
}
