using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSearch.Parsing
{
    interface IParserSettings
    {

        string EngineUrl { get; set; }

        string ImageUrl { get; set; }

        int Pages { get; set; }

    }
}
