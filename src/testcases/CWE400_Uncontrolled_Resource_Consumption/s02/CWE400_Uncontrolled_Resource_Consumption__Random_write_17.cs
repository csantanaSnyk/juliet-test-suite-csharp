/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE400_Uncontrolled_Resource_Consumption__Random_write_17.cs
Label Definition File: CWE400_Uncontrolled_Resource_Consumption.label.xml
Template File: sources-sinks-17.tmpl.cs
*/
/*
* @description
* CWE: 400 Uncontrolled Resource Consumption
* BadSource: Random Set count to a random value
* GoodSource: A hardcoded non-zero, non-min, non-max, even number
* Sinks: write
*    GoodSink: Write to a file count number of times, but first validate count
*    BadSink : Write to a file count number of times
* Flow Variant: 17 Control flow: for loops
*
* */

using TestCaseSupport;
using System;

using System.IO;

using System.Web;

namespace testcases.CWE400_Uncontrolled_Resource_Consumption
{
class CWE400_Uncontrolled_Resource_Consumption__Random_write_17 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        int count;
        /* We need to have one source outside of a for loop in order
         * to prevent the compiler from generating an error because
         * count is uninitialized
         */
        /* POTENTIAL FLAW: Set count to a random value */
        count = (new Random()).Next();
        for (int j = 0; j < 1; j++)
        {
            int i;
            using (StreamWriter file = new StreamWriter(@"badSink.txt"))
            {
                /* POTENTIAL FLAW: Do not validate count before using it as the for loop variant to write to a file */
                for (i = 0; i < count; i++)
                {
                    try
                    {
                        file.Write("Hello");
                    }
                    catch (IOException exceptIO)
                    {
                        IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream writing", exceptIO);
                    }
                }
                /* Close stream reading objects */
                try
                {
                    if (file != null)
                    {
                        file.Close();
                    }
                }
                catch (IOException exceptIO)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, "Error closing Stream Writer", exceptIO);
                }
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    private void GoodG2B()
    {
        int count;
        /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
        count = 2;
        for (int j = 0; j < 1; j++)
        {
            int i;
            using (StreamWriter file = new StreamWriter(@"badSink.txt"))
            {
                /* POTENTIAL FLAW: Do not validate count before using it as the for loop variant to write to a file */
                for (i = 0; i < count; i++)
                {
                    try
                    {
                        file.Write("Hello");
                    }
                    catch (IOException exceptIO)
                    {
                        IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream writing", exceptIO);
                    }
                }
                /* Close stream reading objects */
                try
                {
                    if (file != null)
                    {
                        file.Close();
                    }
                }
                catch (IOException exceptIO)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, "Error closing Stream Writer", exceptIO);
                }
            }
        }
    }

    /* goodB2G() - use badsource and goodsink*/
    private void GoodB2G()
    {
        int count;
        /* POTENTIAL FLAW: Set count to a random value */
        count = (new Random()).Next();
        for (int k = 0; k < 1; k++)
        {
            /* FIX: Validate count before using it as the for loop variant to write to a file */
            if (count > 0 && count <= 20)
            {
                int i;
                using (StreamWriter file = new StreamWriter(@"badSink.txt"))
                {
                    /* POTENTIAL FLAW: Do not validate count before using it as the for loop variant to write to a file */
                    for (i = 0; i < count; i++)
                    {
                        try
                        {
                            file.Write("Hello");
                        }
                        catch (IOException exceptIO)
                        {
                            IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream writing", exceptIO);
                        }
                    }
                    /* Close stream reading objects */
                    try
                    {
                        if (file != null)
                        {
                            file.Close();
                        }
                    }
                    catch (IOException exceptIO)
                    {
                        IO.Logger.Log(NLog.LogLevel.Warn, "Error closing Stream Writer", exceptIO);
                    }
                }
            }
        }
    }

    public override void Good()
    {
        GoodG2B();
        GoodB2G();
    }
#endif //omitgood
}
}