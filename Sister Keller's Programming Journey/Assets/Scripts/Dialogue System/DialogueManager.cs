using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; // Texto para exibir o diálogo
    public TextMeshProUGUI nameText; // Texto para exibir o diálogo
    public GameObject dialoguePanel; // Painel de diálogo
    public Button[] responseButtons; // Array de botões de resposta

    private Queue<string> sentences; // Fila de frases do diálogo atual
    private Dialogue currentDialogue; // Referência ao diálogo atual
    private DialogueTrigger currentTrigger; // Adicionando uma referência ao DialogueTrigger

    [HideInInspector] public bool hasTriggered;

    void Start()
    {
        sentences = new Queue<string>();
        dialoguePanel.SetActive(false);
        HideResponseButtons();
    }

    // Método para iniciar o diálogo
    public void StartDialogue(Dialogue dialogue, DialogueTrigger trigger)
    {
        hasTriggered = true;

        currentDialogue = dialogue;
        currentTrigger = trigger; // Armazena a referência ao DialogueTrigger
        nameText.SetText(currentDialogue.name);
        dialoguePanel.SetActive(true);
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    // Exibir a próxima frase do diálogo
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            DisplayResponses();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    // Coroutine para animar o texto sendo exibido
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    // Exibe as opções de resposta
    void DisplayResponses()
    {
        if (currentDialogue.options.Length > 0)
        {
            for (int i = 0; i < currentDialogue.options.Length; i++)
            {
                responseButtons[i].gameObject.SetActive(true);
                responseButtons[i].GetComponentInChildren<TMP_Text>().text = currentDialogue.options[i].responseText;

                // Adiciona o listener ao botão
                int optionIndex = i; // Criação de uma cópia local para evitar problemas de escopo
                responseButtons[i].onClick.RemoveAllListeners();
                responseButtons[i].onClick.AddListener(() => OnResponseSelected(optionIndex));
            }
        }
        else
        {
            //EndDialogue();
        }
    }

    // Método chamado quando uma resposta é selecionada
    void OnResponseSelected(int optionIndex)
    {
        HideResponseButtons();
        DialogueOption selectedOption = currentDialogue.options[optionIndex];
        if (selectedOption.nextDialogue != null)
        {
            StartDialogue(selectedOption.nextDialogue, currentTrigger);
        }
        else
        {
            //EndDialogue();
        }
    }

    // Oculta os botões de resposta
    void HideResponseButtons()
    {
        foreach (Button button in responseButtons)
        {
            button.gameObject.SetActive(false);
        }
    }

    // Método para encerrar o diálogo
    /*void EndDialogue()
    {
        currentTrigger.DialogueGivePoints(); // Use a referência ao DialogueTrigger armazenada

        if (currentTrigger.dialogue.isPartOfQuests == true)
        {
            currentTrigger.questsSys.CompleteQuest();
        }

        hasTriggered = false;

        PlayerStats.instance.SetWalkingMode();
        dialoguePanel.SetActive(false);
        HideResponseButtons();
        Debug.Log("Fim do diálogo.");
    }*/
}
