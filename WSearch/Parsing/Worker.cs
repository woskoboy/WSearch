using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator;
using AngleSharp.Parser.Html;

namespace WSearch.Parsing
{
    class Worker //<T> where T: class
    {
        private readonly IParser parser; //<T>
        private readonly IParserSettings settings;
        //public event Action<object, T> newData;

        public Worker(IParser parser, IParserSettings settings)
        {
            this.parser = parser;
            this.settings = settings;
        }

        public async void Run()
        {
            var loader = ServiceLocator.Current.GetInstance<Loader>();
            //for (int i = 0; i < settings.Pages; i++)
            //{
            var source = await loader.GetSource();// i);

                var domParser = new HtmlParser();
                var document = await domParser.ParseAsync(source);

                parser.Parse(document); //var result = 
                //newData?.Invoke(this, result);
            //}
        }
    }
}
