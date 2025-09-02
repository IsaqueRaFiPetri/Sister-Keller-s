using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExamManager : MonoBehaviour
{
    [Header("Questions Pool (20 total)")]
    public List<Question> allQuestions = new List<Question>();

    [Header("UI References")]
    public TextMeshProUGUI questionTextUI;
    public Button[] answerButtons;

    private List<Question> selectedQuestions = new List<Question>();
    private int currentQuestionIndex = 0;
    private int score = 0;

    void Start()
    {
        SetupExam();
        ShowQuestion();
    }

    void SetupExam()
    {
        List<Question> shuffled = new List<Question>(allQuestions);
        ShuffleList(shuffled);

        int numberToTake = Mathf.Min(10, shuffled.Count);
        selectedQuestions = shuffled.GetRange(0, numberToTake);
    }

    void ShowQuestion()
    {
        if (currentQuestionIndex >= selectedQuestions.Count)
        {
            EndExam();
            return;
        }

        Question q = selectedQuestions[currentQuestionIndex];

        List<int> answerOrder = new List<int> { 0, 1, 2, 3 };
        ShuffleList(answerOrder);

        questionTextUI.text = q.questionText;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            int answerIndex = answerOrder[i];
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = q.answers[answerIndex];

            answerButtons[i].onClick.RemoveAllListeners();

            int capturedIndex = answerIndex;
            answerButtons[i].onClick.AddListener(() => OnAnswerSelected(capturedIndex == q.correctAnswerIndex));
        }
    }

    void OnAnswerSelected(bool isCorrect)
    {
        if (isCorrect)
        {
            Debug.Log("Correct!");
            score++;
        }
        else
        {
            Debug.Log("Wrong!");
        }

        currentQuestionIndex++;
        ShowQuestion();
    }

    void EndExam()
    {
        Debug.Log("Exam Finished! Score: " + score + "/" + selectedQuestions.Count);
    }

    void ShuffleList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rnd = Random.Range(i, list.Count);
            T temp = list[rnd];
            list[rnd] = list[i];
            list[i] = temp;
        }
    }
}
