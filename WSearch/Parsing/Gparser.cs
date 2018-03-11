using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;
using CommonServiceLocator;
using WSearch.ViewModel;

namespace WSearch.Parsing
{
    class Gparser : IParser //<List<string>>
    {
        public void Parse(IHtmlDocument document)
        {
            var list = ServiceLocator.Current.GetInstance<MainViewModel>().Urls; //new List<string>();
            list.Clear();

            var items = document.QuerySelectorAll("div").Where(item => item.ClassName!=null && item.ClassName.Contains("other-sites__snippet"));

            foreach (var item in items)
            {
                var l1 = item.QuerySelectorAll("a").Where(it => it.ClassName != null && it.ClassName.Contains("other-sites__title-link")).SingleOrDefault();
                var l2 = item.QuerySelectorAll("a").Where(it => it.ClassName != null && it.ClassName.Contains("other-sites__outer-link")).SingleOrDefault();
                var desc = item.QuerySelectorAll("div").Where(it => it.ClassName != null && it.ClassName.Contains("other-sites__desc")).SingleOrDefault();
                list.Add(new Message {
                    Link = l2.TextContent, Description = desc.TextContent
                });
            }
                

            //return list;
        }
    }
}
