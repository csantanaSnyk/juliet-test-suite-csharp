/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE190_Integer_Overflow__Byte_console_readLine_square_10.cs
Label Definition File: CWE190_Integer_Overflow.label.xml
Template File: sources-sinks-10.tmpl.cs
*/
/*
* @description
* CWE: 190 Integer Overflow
* BadSource: console_readLine Read data from the console using readLine
* GoodSource: A hardcoded non-zero, non-min, non-max, even number
* Sinks: square
*    GoodSink: Ensure there will not be an overflow before squaring data
*    BadSink : Square data, which can lead to overflow
* Flow Variant: 10 Control flow: if(IO.staticTrue) and if(IO.staticFalse)
*
* */

using TestCaseSupport;
using System;

using System.Web;

using System.IO;

namespace testcases.CWE190_Integer_Overflow
{
class CWE190_Integer_Overflow__Byte_console_readLine_square_10 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        byte data;
        if (IO.staticTrue)
        {
            /* init data */
            data = 0;
            /* POTENTIAL FLAW: Read data from console with ReadLine*/
            try
            {
                string stringNumber = Console.ReadLine();
                if (stringNumber != null)
                {
                    data = byte.Parse(stringNumber.Trim());
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
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = 0;
        }
        if (IO.staticTrue)
        {
            /* POTENTIAL FLAW: if (data*data) > byte.MaxValue, this will overflow */
            byte result = (byte)(data * data);
            IO.WriteLine("result: " + result);
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B1() - use goodsource and badsink by changing first IO.staticTrue to IO.staticFalse */
    private void GoodG2B1()
    {
        byte data;
        if (IO.staticFalse)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = 0;
        }
        else
        {
            /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
            data = 2;
        }
        if (IO.staticTrue)
        {
            /* POTENTIAL FLAW: if (data*data) > byte.MaxValue, this will overflow */
            byte result = (byte)(data * data);
            IO.WriteLine("result: " + result);
        }
    }

    /* GoodG2B2() - use goodsource and badsink by reversing statements in first if */
    private void GoodG2B2()
    {
        byte data;
        if (IO.staticTrue)
        {
            /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
            data = 2;
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = 0;
        }
        if (IO.staticTrue)
        {
            /* POTENTIAL FLAW: if (data*data) > byte.MaxValue, this will overflow */
            byte result = (byte)(data * data);
            IO.WriteLine("result: " + result);
        }
    }

    /* goodB2G1() - use badsource and goodsink by changing second IO.staticTrue to IO.staticFalse */
    private void GoodB2G1()
    {
        byte data;
        if (IO.staticTrue)
        {
            /* init data */
            data = 0;
            /* POTENTIAL FLAW: Read data from console with ReadLine*/
            try
            {
                string stringNumber = Console.ReadLine();
                if (stringNumber != null)
                {
                    data = byte.Parse(stringNumber.Trim());
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
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = 0;
        }
        if (IO.staticFalse)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            /* FIX: Add a check to prevent an overflow from occurring */
            if (Math.Abs((long)data) <= (long)Math.Sqrt(byte.MaxValue))
            {
                byte result = (byte)(data * data);
                IO.WriteLine("result: " + result);
            }
            else
            {
                IO.WriteLine("data value is too large to perform squaring.");
            }
        }
    }

    /* goodB2G2() - use badsource and goodsink by reversing statements in second if  */
    private void GoodB2G2()
    {
        byte data;
        if (IO.staticTrue)
        {
            /* init data */
            data = 0;
            /* POTENTIAL FLAW: Read data from console with ReadLine*/
            try
            {
                string stringNumber = Console.ReadLine();
                if (stringNumber != null)
                {
                    data = byte.Parse(stringNumber.Trim());
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
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = 0;
        }
        if (IO.staticTrue)
        {
            /* FIX: Add a check to prevent an overflow from occurring */
            if (Math.Abs((long)data) <= (long)Math.Sqrt(byte.MaxValue))
            {
                byte result = (byte)(data * data);
                IO.WriteLine("result: " + result);
            }
            else
            {
                IO.WriteLine("data value is too large to perform squaring.");
            }
        }
    }

    public override void Good()
    {
        GoodG2B1();
        GoodG2B2();
        GoodB2G1();
        GoodB2G2();
    }
#endif //omitgood
}
}
