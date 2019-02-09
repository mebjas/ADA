namespace AlgorithmsNetCoreTest
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Algorithms;

    [TestClass]
    public class TrieTest
    {
        [TestMethod, TestCategory("UnitTest"), TestCategory("Tree")]
        public void TestAll()
        {
            Trie t = new Trie();
            List<string> keysToInsert = new List<string>() { "microsoft", "google", "micro", "face", "facebook" };
            List<string> keysThatDoestExist = new List<string>() { "amazon", "apple", "facebo", "microsofts" };
            keysToInsert.ForEach(key => t.Insert(key));
            keysToInsert.ForEach(key =>
            {
                Assert.IsTrue(t.Exists(key), string.Format("[failure] Expected key: {0} not found", key));
            });

            keysThatDoestExist.ForEach(key =>
            {
                Assert.IsFalse(t.Exists(key), string.Format("[failure] Not Expected key: {0} found", key));
            });
        }
    }
}
