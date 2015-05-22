using System;
using System.Reflection;

using System.Linq;

namespace e_Cars.nunithelper
{
    /// <summary>
    /// Detect if we are running as part of a nUnit unit test.
    /// This is DIRTY and should only be used if absolutely necessary 
    /// as its usually a sign of bad design.
    /// </summary>    
    public static class UnitTestDetector
    {

        private static bool _runningFromNUnit = false;

        static UnitTestDetector()
        {

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly assem in AppDomain.CurrentDomain.GetAssemblies())
            {
                // Can't do something like this as it will load the nUnit assembly
                // if (assem == typeof(NUnit.Framework.Assert))

                if (assem.FullName.ToLowerInvariant().StartsWith("unittest"))
                {
                    _runningFromNUnit = true;
                    break;
                }
            }
        }

        public static bool IsRunningFromNunit
        {
            get { return _runningFromNUnit; }
        }

       public static readonly bool IsRunningFromNUnit2 =
       AppDomain.CurrentDomain.GetAssemblies().Any(
           a => a.FullName.ToLowerInvariant().StartsWith("nunit.framework"));

    }
}