using UnityEngine;

public class DialogueTrigger : InteractableObject
{
    public Dialogue dialogue; // Referência ao diálogo deste NPC
    public DialogueManager dialogueManager; // Referência ao DialogueManager
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
        dialogueManager.StartDialogue(dialogue, this); // Passa o próprio DialogueTrigger como parâmetro
    }
}