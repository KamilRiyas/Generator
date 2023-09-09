namespace Generator.Handlers;

internal class DBContextHandler : CodeGeneratorsHandler
{
    public override void Generate(ClassNode classNode, string outputPath)
    {
        _outputPath = outputPath+"/DbContext/";

        if (_nextHandler != null)
        {
            _nextHandler.Generate(classNode, outputPath);
        }

        Console.WriteLine("DBContext Generated");
    }
}
