/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE36_Absolute_Path_Traversal__Params_Get_Web_81_base.cs
Label Definition File: CWE36_Absolute_Path_Traversal.label.xml
Template File: sources-sink-81_base.tmpl.cs
*/
/*
 * @description
 * CWE: 36 Absolute Path Traversal
 * BadSource: Params_Get_Web Read data from a querystring using Params.Get()
 * GoodSource: A hardcoded string
 * Sinks: readFile
 *    BadSink : read line from file from disk
 * Flow Variant: 81 Data flow: data passed in a parameter to an abstract method
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE36_Absolute_Path_Traversal
{
abstract class CWE36_Absolute_Path_Traversal__Params_Get_Web_81_base
{
    public abstract void Action(string data , HttpRequest req, HttpResponse resp);
}
}
