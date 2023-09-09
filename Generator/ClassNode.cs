namespace Generator;

public record FieldnType(string Field, string Type);

public class ClassNode
{
    public string Name { get; set; }

    public List<ClassNode>? Classes { get; set; }

    public List<FieldnType>? Fields { get; set; }

    public ClassNode(string Name)
    {
        this.Name = Name;
    }

    public ClassNode(string Name, List<FieldnType> Fields)
    {
        this.Name = Name;
        this.Classes = new List<ClassNode>();
        this.Fields = Fields;
    }

    public ClassNode()
    {
    }
}
