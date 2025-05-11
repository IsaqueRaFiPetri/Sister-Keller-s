using UnityEngine;

public class DialogueTrigger : MonoBehaviour, IInteractable
{
    public Dialogue dialogue; // Refer�ncia ao di�logo deste NPC
    public DialogueManager dialogueManager; // Refer�ncia ao DialogueManager

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