
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamasoft.JsonClassGenerator;
using Xamasoft.JsonClassGenerator.CodeWriters;

namespace TESTS_JSON_TO_CSHARP
{
    [TestClass]
    public class Test_3_ReplaceSpecialCharacters
    {
        [TestMethod]
        public void Run()
        {
            string path = Directory.GetCurrentDirectory().Replace("bin\\Debug", "") + @"Test_3_ReplaceSpecialCharacters_INPUT.txt";
            string resultPath = Directory.GetCurrentDirectory().Replace("bin\\Debug", "") + @"Test_3_ReplaceSpecialCharacters_OUTPUT.txt";
            string input = File.ReadAllText(path);

            CSharpCodeWriter csharpCodeWriter = new CSharpCodeWriter();
            JsonClassGenerator jsonClassGenerator = new JsonClassGenerator
            {
                CodeWriter = csharpCodeWriter,
                UseJsonAttributes = true
            };

            string errorMessage;
            string returnVal = jsonClassGenerator.GenerateClasses(input, out errorMessage).ToString();
            string resultsCompare = File.ReadAllText(resultPath);
            Assert.AreEqual(resultsCompare.Replace(Environment.NewLine, "").Replace(" ", "").Replace("\t", ""), 
                            returnVal.Replace(Environment.NewLine, "").Replace(" ", "").Replace("\t", ""));
        }
    }
}
