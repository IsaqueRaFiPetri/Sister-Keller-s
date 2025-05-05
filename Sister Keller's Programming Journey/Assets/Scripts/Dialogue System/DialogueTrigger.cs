using UnityEngine;

public class DialogueTrigger : MonoBehaviour, IInteractable
{
    public Dialogue dialogue; // Referência ao diálogo deste NPC
    public DialogueManager dialogueManager; // Referência ao DialogueManager

    public void Interact()
    {
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        dialogueManager.StartDialogue(this.dialogue);
        PlayerStats.instance.SetUIingMode();
    }
}