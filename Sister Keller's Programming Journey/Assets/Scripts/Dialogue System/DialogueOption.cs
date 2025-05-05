[System.Serializable]
public class DialogueOption
{
    public string responseText; // Texto da resposta do jogador
    public Dialogue nextDialogue; // O próximo diálogo a ser iniciado após essa resposta
}
