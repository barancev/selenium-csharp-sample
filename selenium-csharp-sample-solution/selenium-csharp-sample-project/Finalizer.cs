using System;
using NUnit.Framework;

namespace php4dvdtests
{
    [SetUpFixture]
    public class Finalizer
    {
        [TearDown]
	    public void RunInTheEndOfAll()
	    {
            WebDriverFactory.DismissAll();
        }
    }
}
