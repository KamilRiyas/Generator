using Generator.Handlers;

namespace Generator
{
    public class CodeGenerator
    {
        private readonly ClassesHandler classHandler = new();
        private readonly ControllersHandler controllersHandler = new();
        private readonly DBContextHandler dbContextHandler = new();
        private readonly ProgramFileHandler programFileHandler = new();
        private readonly ProjFileHandler projFileHandler = new();

        public CodeGenerator()
        {
         
            classHandler.SetNextHandler(controllersHandler)
                .SetNextHandler(dbContextHandler)
                .SetNextHandler(programFileHandler)
                .SetNextHandler(projFileHandler);
        }

        public void GenerateCode(ClassNode classes,string outputPath)
        {
            classHandler.Generate(classes,outputPath);
        }
    }
}
