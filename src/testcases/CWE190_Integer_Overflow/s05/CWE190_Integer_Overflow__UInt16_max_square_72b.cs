/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE190_Integer_Overflow__UInt16_max_square_72b.cs
Label Definition File: CWE190_Integer_Overflow.label.xml
Template File: sources-sinks-72b.tmpl.cs
*/
/*
 * @description
 * CWE: 190 Integer Overflow
 * BadSource: max Set data to the max value for ushort
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: square
 *    GoodSink: Ensure there will not be an overflow before squaring data
 *    BadSink : Square data, which can lead to overflow
 * Flow Variant: 72 Data flow: data passed in a Hashtable from one method to another in different source files in the same package
 *
 * */

using TestCaseSupport;
using System;
using System.Collections;

using System.Web;

namespace testcases.CWE190_Integer_Overflow
{
class CWE190_Integer_Overflow__UInt16_max_square_72b
{
#if (!OMITBAD)
    public static void BadSink(Hashtable dataHashtable )
    {
        ushort data = (ushort) dataHashtable[2];
        /* POTENTIAL FLAW: if (data*data) > ushort.MaxValue, this will overflow */
        ushort result = (ushort)(data * data);
        IO.WriteLine("result: " + result);
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use GoodSource and BadSink */
    public static void GoodG2BSink(Hashtable dataHashtable )
    {
        ushort data = (ushort) dataHashtable[2];
        /* POTENTIAL FLAW: if (data*data) > ushort.MaxValue, this will overflow */
        ushort result = (ushort)(data * data);
        IO.WriteLine("result: " + result);
    }

    /* goodB2G() - use BadSource and GoodSink */
    public static void GoodB2GSink(Hashtable dataHashtable )
    {
        ushort data = (ushort) dataHashtable[2];
        /* FIX: Add a check to prevent an overflow from occurring */
        if (Math.Abs((long)data) <= (long)Math.Sqrt(ushort.MaxValue))
        {
            ushort result = (ushort)(data * data);
            IO.WriteLine("result: " + result);
        }
        else
        {
            IO.WriteLine("data value is too large to perform squaring.");
        }
    }
#endif
}
}
