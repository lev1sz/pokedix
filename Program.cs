//https://discord.com/oauth2/authorize?client_id=1396604129949782156&permissions=8&integration_type=0&scope=bot

using Discord;
using Discord.WebSocket;
using DotNetEnv;

Env.Load();
var discordToken = Environment.GetEnvironmentVariable("DiscordToken");

async Task RunBotAsync()
{
    var client = new DiscordSocketClient(new DiscordSocketConfig
    {
        LogLevel = LogSeverity.Debug
    });

    await client.LoginAsync(TokenType.Bot, discordToken);

    Console.WriteLine(client.LoginState);

    await client.StartAsync();

    client.Ready += async () =>
    {
        var guild = client.GetGuild(1255669205035126847);
        var channel = guild.GetTextChannel(1396605533863149748);

        var embed = new EmbedBuilder();
        embed.WithImageUrl("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTIvyK38HshaQ0tf2yO9a9BD8xGQlW_rh8vyg&s");
        await channel.SendMessageAsync(embed: embed.Build());
        await channel.SendMessageAsync("Squirtle squad!");
        await channel.SendMessageAsync("https://bulbapedia.bulbagarden.net/wiki/Squirtle_Squad");

        await client.DisposeAsync();
    };

    client.Log += (log) =>
    {
        Console.WriteLine($"{DateTime.Now} -> {log.Message}");
        return Task.CompletedTask;
    };
}

await RunBotAsync();

Console.ReadKey();