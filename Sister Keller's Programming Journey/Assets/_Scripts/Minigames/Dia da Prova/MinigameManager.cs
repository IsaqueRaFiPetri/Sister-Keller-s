using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MinigameManager : MonoBehaviour
{
    [Header("Game Data")]
    public List<Student> availableStudents;
    public List<Question> questions;

    private int currentQuestionIndex = 0;
    private int correctAnswers = 0;

    [Header("UI References")]
    public TextMeshProUGUI questionTextUI;
    public List<TextMeshProUGUI> answerOptionUIs;
    public TextMeshProUGUI hintTextUI;

    public void StartMinigame()
    {
        currentQuestionIndex = 0;
        correctAnswers = 0;
        ShowCurrentQuestion();
    }

    private void ShowCurrentQuestion()
    {
        Question current = questions[currentQuestionIndex];

        questionTextUI.text = current.questionText;

        for (int i = 0; i < answerOptionUIs.Count; i++)
        {
            answerOptionUIs[i].text = current.answerOptions[i];
        }

        hintTextUI.text = "Choose a student to help you...";
    }

    public void SelectStudent(Student student)
    {
        Question current = questions[currentQuestionIndex];
        string hint = current.hints[(int)student.knowledge];
        hintTextUI.text = $"{student.name} says: \"{hint}\"";
    }

    public void SelectAnswer(int selectedIndex)
    {
        Question current = questions[currentQuestionIndex];

        if (selectedIndex == current.correctAnswerIndex)
        {
            correctAnswers++;
        }

        currentQuestionIndex++;

        if (currentQuestionIndex >= questions.Count)
        {
            EndMinigame();
        }
        else
        {
            ShowCurrentQuestion();
        }
    }

    private void EndMinigame()
    {
        int total = questions.Count;
        bool passed = correctAnswers >= (total / 2);

        if (passed)
        {
            Debug.Log("You passed the test! Congratulations!");
        }
        else
        {
            Debug.Log("You failed the test. Try again!");
        }
    }
}
