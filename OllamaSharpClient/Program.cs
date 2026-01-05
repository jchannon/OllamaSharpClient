using OllamaSharp;

var uri = new Uri("http://localhost:11434");
var ollama = new OllamaApiClient(uri);
ollama.SelectedModel = "deepseek-r1:8b";

var chat = new Chat(ollama);

Console.WriteLine("Chat with deepseek-r1:8b (type 'exit' to quit)");
Console.WriteLine();

while (true)
{
    Console.Write("You: ");
    var message = Console.ReadLine();

    if (string.IsNullOrEmpty(message) || message.ToLower() == "exit")
        break;

    Console.Write("AI: ");
    await foreach (var answerToken in chat.SendAsync(message))
        Console.Write(answerToken);

    Console.WriteLine();
    Console.WriteLine();
}