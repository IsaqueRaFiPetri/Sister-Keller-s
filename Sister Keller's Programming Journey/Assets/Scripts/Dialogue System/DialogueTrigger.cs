/*using UnityEngine;

public class DialogueTrigger : InteractableObject
{
    public Dialogue dialogue; // Referência ao diálogo deste NPC
    public DialogueManager dialogueManager; // Referência ao DialogueManager
    public AudioSource audioSource;

    public PoliticalPoints ppPoints;
    public QuestsSystem questsSys;

    private void Start()
    {
        print(dialogue.hasGivedPoints);
        ppPoints = FindObjectOfType<PoliticalPoints>();
    }
    protected override void Interact()
    {
        PlayerInteraction.Instance.OnInteractionEffected.Invoke();
        PlayerStats.instance.SetUIingMode();
        TriggerDialogue();
        audioSource.Play();
    }
    public void TriggerDialogue()
    {
        dialogueManager.StartDialogue(dialogue, this); // Passa o próprio DialogueTrigger como parâmetro
    }
    public void DialogueGivePoints()
    {
        if (dialogue.hasGivedPoints == false)
        {
            PoliticalPoints.OnNPCInteraction(dialogue.pointsToGive);
            dialogue.hasGivedPoints = true;
        }
        else
        {
            return;
        }
    }
}*/