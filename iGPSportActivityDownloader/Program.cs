// See https://aka.ms/new-console-template for more information

using iGPSportActivityDownloader;
using System.Net.Http.Json;

var client = new HttpClient();

client.DefaultRequestHeaders.Add("Cookie", File.ReadAllText("cookie.txt"));

int pages = int.MaxValue;

for (int i = 1; i <= pages; i++)
{

    var res = await client.GetAsync($"https://i.igpsport.com/Activity/ActivityList?pageindex={i}");


    var str = await res.Content.ReadFromJsonAsync<ActivityList>();
    pages = (str.total + 9) / 10;
    foreach (var activity in str.item)
    {
        var name = $"{activity.StartTime.Replace(':', '_')}.fit";
        if (File.Exists(name))
            continue;

        var rideRequest = await client.GetAsync($"https://i.igpsport.com/fit/activity?type=0&rideid={activity.RideId}");
        var bytes = await rideRequest.Content.ReadAsByteArrayAsync();
        File.WriteAllBytes(name, bytes);
        Console.WriteLine($"Written {name} with {bytes.Length / 1000}kb");
    }
}
