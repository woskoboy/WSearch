using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WSearch.Parsing
{
    class Loader
    {
        readonly HttpClient client;
        readonly string url;
        public Loader(IParserSettings settings)
        {
            client = new HttpClient();
            url = $"{settings.EngineUrl}" +
                  $"&url={settings.ImageUrl}"; //image_url
                                               //$"&start={{CountPage}}";
        }

        public async Task<string> GetSource() //int page)
        {
            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));
            //string cur_url = url.Replace("{CountPage}", $"{page * 10}");

            using (var response = await client.GetAsync(url)) //(cur_url, HttpCompletionOption.ResponseHeadersRead);
            {
                string source = null;
                if(response != null && response.StatusCode == HttpStatusCode.OK)
                    source =  await response.Content.ReadAsStringAsync();

                return source;
            }
        }
    }
}
