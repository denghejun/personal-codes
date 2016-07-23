using System;
using System.Collections.Generic;
using System.Data.Entity.Design.PluralizationServices;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newegg.OZZO.WMS.Infrastructure.Common;

namespace MethodAggregate.UnitTest
{
    [TestClass]
    public class Newegg_FrameworkLogger_Test
    {
        [TestMethod]
        public void Test_Write_LogEntry()
        {

        }

        [TestMethod]
        public void Test_Write_LogCategory()
        {
            this.InsertModel(new Model() { ID = new Random().Next().ToString(), Name = "dhj" });
        }

        [TestMethod]
        public void Test_Read_Log()
        {
        }

        private List<Model> GetModels(string fileFullPath)
        {
            if (!File.Exists(fileFullPath))
            {
                return new List<Model>();
            }

            List<Model> models = null;
            var fileName = string.Format("{0}.txt", DateTime.Now.ToString("yyyy-MM-dd"));
            using (var stream = new FileStream(fileFullPath, FileMode.Open))
            {
                if (stream.CanSeek)
                {
                    stream.Seek(0, SeekOrigin.Begin);
                }

                using (var reader = new StreamReader(stream))
                {
                    models = ServiceStack.Text.JsonSerializer.DeserializeFromReader<List<Model>>(reader);
                    var objs = ServiceStack.Text.JsonSerializer.DeserializeFromReader<List<dynamic>>(reader);
                }
            }

            return models;
        }

        private void InsertModel(Model model)
        {
            var directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RunnerLocalCache");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var fileName = string.Format("{0}.txt", DateTime.Now.ToString("yyyy-MM-dd"));
            var existsModels = this.GetModels(Path.Combine(directory, fileName));
            existsModels.Add(model);
            byte[] textByte = System.Text.Encoding.UTF8.GetBytes(ServiceStack.Text.JsonSerializer.SerializeToString(existsModels));
            using (FileStream logStream = new FileStream(Path.Combine(directory, fileName), FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                logStream.Write(textByte, 0, textByte.Length);
                logStream.Close();
            }
        }

        private static void InsertModelS(Model model)
        {
            var directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RunnerLocalCache");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var fileName = string.Format("{0}.txt", DateTime.Now.ToString("yyyy-MM-dd"));
            //var existsModels = this.GetModels(Path.Combine(directory, fileName));
            //existsModels.Add(model);
            //byte[] textByte = System.Text.Encoding.UTF8.GetBytes(ServiceStack.Text.JsonSerializer.SerializeToString(existsModels));
            //using (FileStream logStream = new FileStream(Path.Combine(directory, fileName), FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            //{
            //    logStream.Write(textByte, 0, textByte.Length);
            //    logStream.Close();
            //}
        }

        [TestMethod]
        public void Method_Create()
        {
            //var ps = PluralizationService.CreateService(new System.Globalization.CultureInfo("en-US")).Pluralize("person");
            var func = new Func<int, int, Model>(this.Add);
            Delegate te = func;
            var strt = te.Method.ReflectedType.AssemblyQualifiedName;
            var str = Encoding.Default.GetString(te.Method.GetMethodBody().GetILAsByteArray());
            var classType = Type.GetType(func.Method.DeclaringType.ToString() + "," + func.Method.Module.Assembly.GetName().Name);
            var method = classType.GetMethod(func.Method.Name, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);

            if (method != null)
            {
                var count = method.Invoke(null, new object[] { 1, 3 });
            }
        }

        private Model Add(int a, int b)
        {
            return new Model() { ID = (a + b).ToString() };
        }
    }
}
