
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name; // Nome do NPC ou do diálogo
    [TextArea(5, 12)]
    public string[] sentences; // Frases do diálogo
    public DialogueOption[] options; // Opções de resposta
}
