using System.Runtime.CompilerServices;
using System.Text;

namespace Generator.Handlers;

internal class ClassesHandler : CodeGeneratorsHandler
{ 
    public override void Generate(ClassNode classNode, string outputPath)
    {
        _outputPath = outputPath+"/Models/";

        IterateClasses(classNode);

        if (_nextHandler != null)
        {
            _nextHandler.Generate(classNode, outputPath);
        }

        Console.WriteLine("Classes Generated");
    }

    private void IterateClasses(ClassNode classes)
    {
        ExtractClass(classes);
        int classCount = classes.Classes.Count;
        while (classCount > 0)
        {
            foreach (var item in classes.Classes)
            {
                IterateClasses(item);
                classCount--;
            }
        }
    }

    private void ExtractClass(ClassNode classes)
    {
        StringBuilder code = new StringBuilder();
        code.AppendLine($"public class {classes.Name}");
        code.AppendLine("{");
        foreach (var item in classes.Fields)
        {
            switch (item.Type)
            {
                case "Number":
                    code.AppendLine(@"    public int " + item.Field + " { get; set;}");
                    break;
                case "String":
                    code.AppendLine(@"    public string " + item.Field + " { get; set;}");
                    break;
                case ("True" or "False"):
                    code.AppendLine(@"    public bool " + item.Field + " { get; set;}");
                    break;
                case "Class":
                    code.AppendLine(@"    public " + item.Field + " " + item.Field + " { get; set;}");
                    break;
                case "Array":
                    code.AppendLine(@"    public ICollection<" + item.Field + "> " + item.Field + "List { get; set;}");
                    break;
                default:
                    break;
            }
        }
        code.AppendLine("}");
        //TODO: Store this content in cs file.
        if (!Directory.Exists(_outputPath))
        {
            Directory.CreateDirectory(_outputPath);
        }
        File.WriteAllText($"{_outputPath}{classes.Name}.cs", code.ToString());
    }
}
