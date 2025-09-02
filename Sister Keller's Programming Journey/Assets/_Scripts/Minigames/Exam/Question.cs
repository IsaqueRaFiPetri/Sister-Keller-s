using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "Scriptable Objects/Question")]
public class Question : ScriptableObject
{
    [TextArea] public string questionText;       // The text of the question
    public string[] answers = new string[4];     // The 4 possible answers
    public int correctAnswerIndex;               // Which one is correct (0-3)
}

