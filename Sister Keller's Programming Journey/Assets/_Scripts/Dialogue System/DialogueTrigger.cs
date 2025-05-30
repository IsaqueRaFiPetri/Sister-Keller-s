using UnityEngine;

public class DialogueTrigger : MonoBehaviour, IInteractable
{
    public Dialogue dialogue; // ReferÍncia ao diŠlogo deste NPC
    public DialogueManager dialogueManager; // ReferÍncia ao DialogueManager

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