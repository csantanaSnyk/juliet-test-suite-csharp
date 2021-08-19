/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE197_Numeric_Truncation_Error__double_Environment_to_long_54c.cs
Label Definition File: CWE197_Numeric_Truncation_Error__double.label.xml
Template File: sources-sink-54c.tmpl.cs
*/
/*
 * @description
 * CWE: 197 Numeric Truncation Error
 * BadSource: Environment Read data from an environment variable
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: to_long
 *    BadSink : Convert data to a long
 * Flow Variant: 54 Data flow: data passed as an argument from one method through three others to a fifth; all five functions are in different classes in the same package
 *
 * */

using TestCaseSupport;
using System;

namespace testcases.CWE197_Numeric_Truncation_Error
{
class CWE197_Numeric_Truncation_Error__double_Environment_to_long_54c
{
#if (!OMITBAD)
    public static void BadSink(double data )
    {
        CWE197_Numeric_Truncation_Error__double_Environment_to_long_54d.BadSink(data );
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(double data )
    {
        CWE197_Numeric_Truncation_Error__double_Environment_to_long_54d.GoodG2BSink(data );
    }
#endif
}
}
