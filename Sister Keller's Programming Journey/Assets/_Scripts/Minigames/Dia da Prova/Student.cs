public enum KnowledgeLevel
{
    Poor, Average, Strong
}

[System.Serializable]
public class Student
{
    public string name;
    public KnowledgeLevel knowledge;
}