/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE481_Assigning_Instead_of_Comparing__basic_14.cs
Label Definition File: CWE481_Assigning_Instead_of_Comparing__basic.label.xml
Template File: point-flaw-14.tmpl.cs
*/
/*
* @description
* CWE: 481 Assigning Instead of Comparing
* Sinks:
*    GoodSink: Comparing
*    BadSink : Assigning instead of comparing
* Flow Variant: 14 Control flow: if(IO.staticFive==5) and if(IO.staticFive!=5)
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE481_Assigning_Instead_of_Comparing
{
class CWE481_Assigning_Instead_of_Comparing__basic_14 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.staticFive == 5)
        {
            int zeroOrOne = (new Random()).Next(2);
            bool isZero = (zeroOrOne == 0);
            if (isZero = true) /* FLAW: should be == and INCIDENTIAL CWE 571 Expression Is Always True */
            {
                IO.WriteLine("zeroOrOne is 0");
            }
            IO.WriteLine("isZero is: " + isZero);
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes IO.staticFive==5 to IO.staticFive!=5 */
    private void Good1()
    {
        if (IO.staticFive != 5)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            int zeroOrOne = (new Random()).Next(2); /* i will be 0 or 1 */
            bool isZero = (zeroOrOne == 0);
            if (isZero == true) /* FIX: using == instead of = */
            {
                IO.WriteLine("zeroOrOne is 0");
            }
            IO.WriteLine("isZero is: " + isZero);
        }
    }

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (IO.staticFive == 5)
        {
            int zeroOrOne = (new Random()).Next(2); /* i will be 0 or 1 */
            bool isZero = (zeroOrOne == 0);
            if (isZero == true) /* FIX: using == instead of = */
            {
                IO.WriteLine("zeroOrOne is 0");
            }
            IO.WriteLine("isZero is: " + isZero);
        }
    }

    public override void Good()
    {
        Good1();
        Good2();
    }
#endif //omitgood
}
}
