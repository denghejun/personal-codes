using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MethodAggregate.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MethodAggregate.UnitTest
{
    [TestClass]
    public class CacheHelper_Test
    {
        [TestMethod]
        public void Test_Get_All_Cache_Files()
        {
            var files = RunnerCacheManager.AllCacheFiles;
            Assert.AreEqual(1, files.Count);
        }

        [TestMethod]
        public void Test_Process_CacheFiles()
        {
            Runner.StartProcessCacheRunners(0, 0);
            Thread.Sleep(TimeSpan.MaxValue);
        }
    }
}
