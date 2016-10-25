using Icas.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Icas.Test
{
    [TestClass]
    public class ProcessExtensionTest
    {
        [TestMethod]
        public void RunFirstPy()
        {
            ProcessExtension.Run("python", "C:\\JICWork\\first.py");
            Debug.Print("hi");
        }
    }
}
