/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE398_Code_Quality__empty_block_05.cs
Label Definition File: CWE398_Code_Quality.label.xml
Template File: point-flaw-05.tmpl.cs
*/
/*
* @description
* CWE: 398 One of the 7 Pernicious Kingdoms - Code Quality
* Sinks: empty_block
*    GoodSink: Include some code inside a block
*    BadSink : An empty code block has no effect
* Flow Variant: 05 Control flow: if(privateTrue) and if(privateFalse)
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE398_Code_Quality
{
class CWE398_Code_Quality__empty_block_05 : AbstractTestCase
{
    /* The two variables below are not defined as "readonly", but are never
     * assigned any other value, so a tool should be able to identify that
     * reads of these will always return their initialized values.
     */
    private bool privateTrue = true;
    private bool privateFalse = false;
#if (!OMITBAD)
    public override void Bad()
    {
        if (privateTrue)
        {
            /* FLAW: The empty block on the next line has no effect */
            {
            }
            IO.WriteLine("Hello from Bad()");
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes privateTrue to privateFalse */
    private void Good1()
    {
        if (privateFalse)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            /* FIX: Include some code inside the block */
            {
                String sentence = "Inside the block"; /* Define a variable to justify having a block for scoping */
                IO.WriteLine(sentence);
            }
            IO.WriteLine("Hello from Good()");
        }
    }

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (privateTrue)
        {
            /* FIX: Include some code inside the block */
            {
                String sentence = "Inside the block"; /* Define a variable to justify having a block for scoping */
                IO.WriteLine(sentence);
            }
            IO.WriteLine("Hello from Good()");
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
