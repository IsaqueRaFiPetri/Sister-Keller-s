using UnityEngine;

public class DialogueTrigger : InteractableObject
{
    public Dialogue dialogue; // Refer�ncia ao di�logo deste NPC
    public DialogueManager dialogueManager; // Refer�ncia ao DialogueManager
    public AudioSource audioSource;
        
    protected override void Interact()
    {
        //PlayerInteraction.Instance.OnInteractionEffected.Invoke();
        //PlayerStats.instance.SetUIingMode();
        TriggerDialogue();
        audioSource.Play();
    }
    public void TriggerDialogue()
    {
        dialogueManager.StartDialogue(dialogue, this); // Passa o pr�prio DialogueTrigger como par�metro
    }
}