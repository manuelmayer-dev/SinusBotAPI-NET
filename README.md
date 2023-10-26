# SinusBotAPI-NET
A client for the SinusBot API, written in C#/.NET

### Features

- ☑️ Authentication
- ☑️ Full control over your instances
- ☑️ Full control over your files except for upload (coming soon)
- ☑️ Full control over the bot's playback
- ☑️ No extra dependencies
- ☑️ Asynchronous

### Usage

```c#
using SinusBotAPI;

class Program
{
    public static async Task Main(string[] args)
    {
        var sinusBotClient = new SinusBotClient("http://yourboturl:8087");
        
        await sinusBotClient.Authenticate("YOUR_USERNAME", "YOUR_PASSWORD");

        var instances = await sinusBotClient.GetInstances();
        var instance = instances.FirstOrDefault();

        if (instance is null)
        {
            Console.WriteLine("You have no instances");
            return;
        }
        
        Console.WriteLine(instance.Name);
    }    
}
```
