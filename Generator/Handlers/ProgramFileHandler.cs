namespace Generator.Handlers;

internal class ProgramFileHandler : CodeGeneratorsHandler
{
    public override void Generate(ClassNode classNode, string outputPath)
    {
        _outputPath = outputPath;
        Console.WriteLine("ProgramFile Generated");
        if(_nextHandler != null)
        {
            _nextHandler.Generate(classNode, outputPath);
        }
    }
}
