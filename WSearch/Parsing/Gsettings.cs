using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSearch.Parsing
{
    class Gsettings : IParserSettings
    {
        public Gsettings(string img_url) //, int count_page)
        {
            ImageUrl = img_url;
           // Pages = count_page;
        }

        public string EngineUrl { get; set; }
            = "https://yandex.ru/images/search?rpt=imageview";
        // = "https://images.google.com/searchbyimage?&hl=ru";
        public string ImageUrl { get; set; }
        public int Pages { get; set; }
    }
}
