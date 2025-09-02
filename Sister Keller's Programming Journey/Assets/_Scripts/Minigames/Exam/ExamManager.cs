using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ExamManager : MonoBehaviour
{
    [Header("Questions Pool (20 total)")]
    public List<Question> allQuestions = new List<Question>();

    [Header("UI References")]
    public TextMeshProUGUI questionTextUI;
    public Button[] answerButtons;

    List<Question> selectedQuestions = new List<Question>();
    int currentQuestionIndex = 0;
    int goodScore = 0;
    int badScore = 0;

    [SerializeField] UnityEvent AnswerCorrectly, AnswerWrongly;
    [SerializeField] UnityEvent GoodFinal, BadFinal, NeutralFinal;

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
            AnswerCorrectly.Invoke();
            goodScore++;
        }
        else
        {
            Debug.Log("Wrong!");
            AnswerWrongly.Invoke();
            badScore++;
        }

        currentQuestionIndex++;
        ShowQuestion();
    }

    void EndExam()
    {
        if(goodScore > badScore)
        {

        }
        else if(badScore > goodScore)
        {

        }
        else
        {

        }
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
