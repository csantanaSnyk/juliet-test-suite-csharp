/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE191_Integer_Underflow__UInt32_console_ReadLine_multiply_45.cs
Label Definition File: CWE191_Integer_Underflow.label.xml
Template File: sources-sinks-45.tmpl.cs
*/
/*
 * @description
 * CWE: 191 Integer Underflow
 * BadSource: console_ReadLine Read data from the console using ReadLine
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: multiply
 *    GoodSink: Ensure there will not be an underflow before multiplying data by 2
 *    BadSink : If data is negative, multiply by 2, which can cause an underflow
 * Flow Variant: 45 Data flow: data passed as a private class member variable from one function to another in the same class
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

using System.IO;

namespace testcases.CWE191_Integer_Underflow
{
class CWE191_Integer_Underflow__UInt32_console_ReadLine_multiply_45 : AbstractTestCase
{

    private uint dataBad;
    private uint dataGoodG2B;
    private uint dataGoodB2G;
#if (!OMITBAD)
    private void BadSink()
    {
        uint data = dataBad;
        if(data < 0) /* ensure we won't have an overflow */
        {
            /* POTENTIAL FLAW: if (data * 2) < uint.MinValue, this will underflow */
            uint result = (uint)(data * 2);
            IO.WriteLine("result: " + result);
        }
    }

    public override void Bad()
    {
        uint data;
        /* init data */
        data = 0;
        /* POTENTIAL FLAW: Read data from console with ReadLine*/
        try
        {
            string stringNumber = Console.ReadLine();
            if (stringNumber != null)
            {
                data = uint.Parse(stringNumber.Trim());
            }
        }
        catch (IOException exceptIO)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream reading", exceptIO);
        }
        catch (FormatException exceptNumberFormat)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, "Error with number parsing", exceptNumberFormat);
        }
        dataBad = data;
        BadSink();
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B();
        GoodB2G();
    }

    private void GoodG2BSink()
    {
        uint data = dataGoodG2B;
        if(data < 0) /* ensure we won't have an overflow */
        {
            /* POTENTIAL FLAW: if (data * 2) < uint.MinValue, this will underflow */
            uint result = (uint)(data * 2);
            IO.WriteLine("result: " + result);
        }
    }

    /* goodG2B() - use goodsource and badsink */
    private void GoodG2B()
    {
        uint data;
        /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
        data = 2;
        dataGoodG2B = data;
        GoodG2BSink();
    }

    private void GoodB2GSink()
    {
        uint data = dataGoodB2G;
        if(data < 0) /* ensure we won't have an overflow */
        {
            /* FIX: Add a check to prevent an underflow from occurring */
            if (data > (uint.MinValue/2))
            {
                uint result = (uint)(data * 2);
                IO.WriteLine("result: " + result);
            }
            else
            {
                IO.WriteLine("data value is too small to perform multiplication.");
            }
        }
    }

    /* goodB2G() - use badsource and goodsink */
    private void GoodB2G()
    {
        uint data;
        /* init data */
        data = 0;
        /* POTENTIAL FLAW: Read data from console with ReadLine*/
        try
        {
            string stringNumber = Console.ReadLine();
            if (stringNumber != null)
            {
                data = uint.Parse(stringNumber.Trim());
            }
        }
        catch (IOException exceptIO)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream reading", exceptIO);
        }
        catch (FormatException exceptNumberFormat)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, "Error with number parsing", exceptNumberFormat);
        }
        dataGoodB2G = data;
        GoodB2GSink();
    }
#endif //omitgood
}
}
