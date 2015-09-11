using System;
using System.Xml;
using HtmlAgilityPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebFramework.Web;

namespace bavc.ru.Tests
{
    [TestClass]
    public class UnitTestPage
    {
        [TestMethod]
        public void TestWebPage()
        {
            var page = new WebPage<MyPage>("http://ya.ru", "<html><html>")
            {
                FuncParse = () => new MyPage {Id = 1, Title = "Test page"}
            };
            Assert.AreEqual(new MyPage {Id = 1, Title = "Test page"}, page.Model);
        }

        [TestMethod]
        public void TestWebPageBlock()
        {
            var page=new WebContent();
            var result = page.GetParseBlock<MyPage>(@"<div><p id=1><span class=title>Test</span></p></div>", x =>
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(x);
                var nodes = doc.DocumentNode.SelectNodes(@"//div");
                var resultClass=new MyPage();
                foreach (var node in nodes)
                {
                    var id = node.SelectSingleNode(@"p").Attributes["id"].Value;
                    var title = node.SelectSingleNode(@"//span").InnerText;
                    resultClass.Id = Int32.Parse(id);
                    resultClass.Title = title;
                }
                return resultClass;
            });
            var originResult = new MyPage {Id = 1, Title = "Test"};
            Assert.AreEqual(originResult, result);
        }

        [TestMethod]
        public void TestWebPageMain()
        {
            var page = new WebPage<MyPage>();
            page.FuncParse = () => { return new MyPage(); };
            var pageModel = page.Model;
        }
    }

    public class MyPage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public override bool Equals(object obj)
        {
            MyPage myObj = (MyPage) obj;
            if (this.Id == myObj.Id && this.Title == myObj.Title)
                return true;
            return false;
        }
    }
}
