
using System.Diagnostics;

HttpClient client = new HttpClient();
client.BaseAddress = new Uri("https://localhost:7032/");
Random random = new Random();

await client.GetAsync("updatecity/sync/1000/1000/Brno");

Stopwatch s = new Stopwatch();

s.Start();
for (int i = 0; i < 100; i++)
{
    int from = random.Next(1,900);
    int amount = 100;
    await client.GetAsync($"updatecity/sync/{amount}/{from}/Brno");
}
s.Stop();
Console.WriteLine($"db sync - {s.ElapsedMilliseconds}");


s.Reset();
s.Start();
for (int i = 0; i < 100; i++)
{
    int from = random.Next(1, 900);
    int amount = 100;
    await client.GetAsync($"updatecity/async/{amount}/{from}/Brno");
}
s.Stop();
Console.WriteLine($"db async - {s.ElapsedMilliseconds}");

s.Reset();
s.Start();
for (int i = 0; i < 10; i++)
{
    await client.GetAsync($"file/sync");
}
s.Stop();
Console.WriteLine($"file sync - {s.ElapsedMilliseconds}");

s.Reset();
s.Start();
for (int i = 0; i < 10; i++)
{
    await client.GetAsync($"file/async");
}
s.Stop();
Console.WriteLine($"file async - {s.ElapsedMilliseconds}");

Console.ReadLine();