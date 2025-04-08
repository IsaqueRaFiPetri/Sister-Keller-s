using UnityEngine;

public class DialogueTrigger : InteractableObject
{
    public Dialogue dialogue; // Refer�ncia ao di�logo deste NPC
    DialogueManager dialogueManager; // Refer�ncia ao DialogueManager

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
        dialogueManager.StartDialogue(dialogue, this); // Passa o pr�prio DialogueTrigger como par�metro
    }
}