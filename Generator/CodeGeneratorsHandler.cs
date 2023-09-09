namespace Generator;

public abstract class CodeGeneratorsHandler
{
    protected CodeGeneratorsHandler? _nextHandler;

    public string? _outputPath;

    public CodeGeneratorsHandler SetNextHandler(CodeGeneratorsHandler nextHandler)
    {
        return _nextHandler = nextHandler;
    }

    public abstract void Generate(ClassNode classNode, string outputPath);
}
