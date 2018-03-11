using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using WSearch.Parsing;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using Autofac.Core;

namespace WSearch.ViewModel
{
    class DataService
    {
        private IContainer container;
        public DataService()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainViewModel>().SingleInstance();

            builder.RegisterType<Gparser>();
            builder.RegisterType<Gsettings>().WithParameter("img_url", @"https://cashbuzz.ru/img/embargo-rossii-dlya-germanii.jpg");
            // new List<Parameter> { new NamedParameter(),new NamedParameter("count_page",1) }

            builder.Register<IParserSettings>(s => s.Resolve<Gsettings>());
            builder.Register<IParser>(p => p.Resolve<Gparser>());

            builder.RegisterType<Loader>();
            builder.RegisterType<Worker>(); //<List<string>

            container = builder.Build();
        }

        public void StartServiceLocator()
        {
            var locator = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => locator);
        }
    }
}
