using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HttpConfiguration
{
    class Program
    {
        //https://www.youtube.com/watch?v=EPSjxg4Rzs8
        static void Main(string[] args)
        {
            string url = "http://www.google.com.pk";
            string testpostserver = "http://www.thomas-bayer.com/sqlrest/";
                //"https://posttestserver.com/post.php";
            //GetRequest(url);
            //GetRequestHeader(url);
            GetRequestHeader(testpostserver);
            Console.ReadLine();
        }

        async static void GetRequest(string url)
        {
            using (HttpClient _client = new HttpClient())
            {
                using (HttpResponseMessage _response = await _client.GetAsync(url))
                {
                    using (HttpContent content = _response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();
                        Console.WriteLine(mycontent);
                    }
                }

            };
        }

        async static void GetRequestHeader(string url)
        {
            using (HttpClient _client = new HttpClient())
            {
                using (HttpResponseMessage _response = await _client.GetAsync(url))
                {
                    using (HttpContent content = _response.Content)
                    {
                        HttpContentHeaders headers = content.Headers;
                        Console.WriteLine(headers);
                    }

                }

            };
        }
        async static void PostRequest(string url)
        {
            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("query1","Asiman"),
                new KeyValuePair<string, string>("query2", "Isabala")
            };

            HttpContent query = new FormUrlEncodedContent(queries);

            using (HttpClient _client = new HttpClient())
            {
                using (HttpResponseMessage _response = await _client.PostAsync(url, query))
                {
                    using (HttpContent content = _response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();
                        HttpContentHeaders headers = content.Headers;
                        Console.WriteLine(mycontent);
                    }
                }
            };
        }
    }

}

