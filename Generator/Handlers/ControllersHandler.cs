namespace Generator.Handlers;

internal class ControllersHandler : CodeGeneratorsHandler
{
    public override void Generate(ClassNode classNode, string outputPath)
    {
        _outputPath = outputPath + "/Controllers/";

        if (_nextHandler != null)
        {
            _nextHandler.Generate(classNode, outputPath);
        }

        Console.WriteLine("Controller Generated");
    }
}
