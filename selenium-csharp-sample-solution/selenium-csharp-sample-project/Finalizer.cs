using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
