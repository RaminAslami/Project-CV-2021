using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project_2022_CV.Models;

namespace Project_2022_CV.Controllers.Api
{
    public class GithubController : ApiController
    {

        // GET api/<controller>/5
        public async Task<dynamic> Get(string gitUser)
        {
            // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
            //HttpClient client = new HttpClient();

            // Call asynchronous network methods in a try/catch block to handle exceptions.

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("User-Agent", "C# App");
                    var response = await client.GetStringAsync("https://api.github.com/users/" + gitUser + "/repos");
                    var json = JsonConvert.DeserializeObject<List<GitRepository>>(response);

                    foreach (var i in json)
                    {
                        Debug.WriteLine(i.html_url);
                    }




                    return json;





                    // Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);
                    //JObject json = JObject.Parse(responseBody);
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }




        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}