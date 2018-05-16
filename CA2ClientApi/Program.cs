using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CA2Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        public static async Task RunAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:49682/booking/");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //test get free meetings rooms on 09/06/2018 from 09:00 to 10:00
                    Console.WriteLine("List of free meeting rooms on 09/06/2018 from 9am to 10am");

                    HttpResponseMessage response = await client.GetAsync("GetAvailableRooms?_date=20180609000000&_startTime=20180609090001&_endTime=20180609100000");
                    if (response.IsSuccessStatusCode)
                    {
                        var rooms = await response.Content.ReadAsAsync<IEnumerable<MeetingRoom>>();
                        if (rooms == null)
                        {
                            Console.WriteLine("Sorry, there is no room free on those date and times.");
                        }
                        else
                        {
                            foreach (var room in rooms)
                            {
                                Console.WriteLine(room);
                            }
                        }                       
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadKey();
        }
    }
}
