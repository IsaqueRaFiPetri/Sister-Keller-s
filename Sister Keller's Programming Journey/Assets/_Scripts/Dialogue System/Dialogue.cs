using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name; // Nome do NPC ou do di�logo
    [TextArea(3, 10)]
    public string[] sentences; // Frases do di�logo
    public DialogueOption[] options; // Op��es de resposta
}
