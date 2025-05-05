using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name; // Nome do NPC ou do diálogo
    [TextArea(3, 10)]
    public string[] sentences; // Frases do diálogo
    public DialogueOption[] options; // Opções de resposta
}
