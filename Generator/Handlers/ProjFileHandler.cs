namespace Generator.Handlers;

internal class ProjFileHandler : CodeGeneratorsHandler
{
    public override void Generate(ClassNode classNode, string outputPath)
    {
        _outputPath = outputPath;
        Console.WriteLine("ProjFile Generated");
        if(_nextHandler != null)
        {
            _nextHandler.Generate(classNode, outputPath);
        }
    }
}
