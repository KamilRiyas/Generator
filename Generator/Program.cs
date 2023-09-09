using System.Text.Json;

namespace Generator;

internal class Program
{
    private static ClassNode Classes { get; set; } = new ClassNode();

    static void Main(string[] args)
    {
        //Read Json
        //replace the hardcoded value with cmdline arg
        var jsonDocument = JsonSerializer.Deserialize<JsonDocument>(File.ReadAllText("c:/data.json"))!;
        var outputPath = "C:/GeneratedProject" + DateTime.Now.TimeOfDay.Ticks.ToString();

        IterateJson(jsonDocument.RootElement, Classes);

        //First node is going to be for the root node
        Classes = Classes.Classes.First();

        //GenerateCode
        CodeGenerator codeGenerator = new();
        codeGenerator.GenerateCode(Classes, outputPath);
    } 

    private static void IterateJson(JsonElement element, ClassNode node)
    {
        node.Classes = new List<ClassNode>();
        node.Fields = new List<FieldnType>();
        foreach (var item in element.EnumerateObject())
        {
            if (item.Value.ValueKind == JsonValueKind.Object || item.Value.ValueKind == JsonValueKind.Array)
            {
                ClassNode childClass = new ClassNode(item.Name);
                node.Classes.Add(childClass);
                if (item.Value.ValueKind == JsonValueKind.Object)
                {
                    node.Fields.Add(new FieldnType(item.Name, "Class"));
                    IterateJson(item.Value, childClass);
                } 
                else if (item.Value.ValueKind == JsonValueKind.Array)
                {
                    node.Fields.Add(new FieldnType(item.Name, item.Value.ValueKind.ToString()));
                    IterateJson(item.Value.EnumerateArray().First(), childClass);
                }
            }
            else
            {
                node.Fields.Add(new FieldnType(item.Name, item.Value.ValueKind.ToString()));
            }
        }
    }
}