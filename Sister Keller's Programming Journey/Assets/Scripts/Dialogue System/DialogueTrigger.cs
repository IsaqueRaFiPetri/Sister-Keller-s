using UnityEngine;

public class DialogueTrigger : InteractableObject
{
    public Dialogue dialogue; // Referência ao diálogo deste NPC
    DialogueManager dialogueManager; // Referência ao DialogueManager

    private void Awake()
    {
        dialogueManager = GetComponent<DialogueManager>();
    }

    protected override void Interact()
    {
        //PlayerInteraction.Instance.OnInteractionEffected.Invoke();
        //PlayerStats.instance.SetUIingMode();
        TriggerDialogue();
    }
    public void TriggerDialogue()
    {
        dialogueManager.StartDialogue(dialogue, this); // Passa o próprio DialogueTrigger como parâmetro
    }
}