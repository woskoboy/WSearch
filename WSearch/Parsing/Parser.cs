using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;

namespace WSearch.Parsing
{
    interface IParser // <T> where T: class
    {
        void Parse(IHtmlDocument document); //T
    }
}
