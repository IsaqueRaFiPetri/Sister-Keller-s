using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText; // Texto para exibir o diálogo
    public GameObject dialoguePanel; // Painel de diálogo
    public Button[] responseButtons; // Array de botões de resposta

    private Queue<string> sentences; // Fila de frases do diálogo atual
    private Dialogue currentDialogue; // Referência ao diálogo atual

    void Start()
    {
        sentences = new Queue<string>();
        dialoguePanel.SetActive(false);
        HideResponseButtons();
    }

    // Método para iniciar o diálogo
    public void StartDialogue(Dialogue dialogue)
    {
        currentDialogue = dialogue;
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
            yield return null;
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
                TMP_Text buttonText = responseButtons[i].GetComponentInChildren<TMP_Text>();
                if (buttonText != null)
                {
                    buttonText.text = currentDialogue.options[i].responseText;
                }

                // Adiciona o listener ao botão
                int optionIndex = i; // Cópia local para evitar problemas de escopo
                responseButtons[i].onClick.RemoveAllListeners();
                responseButtons[i].onClick.AddListener(() => OnResponseSelected(optionIndex));
            }
        }
        else
        {
            EndDialogue();
        }
    }

    // Método chamado quando uma resposta é selecionada
    void OnResponseSelected(int optionIndex)
    {
        HideResponseButtons();
        DialogueOption selectedOption = currentDialogue.options[optionIndex];
        if (selectedOption.nextDialogue != null)
        {
            StartDialogue(selectedOption.nextDialogue);
        }
        else
        {
            EndDialogue();
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
    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        HideResponseButtons();
        Debug.Log("Fim do diálogo.");
        PlayerStats.instance.SetWalkingMode();
    }
}