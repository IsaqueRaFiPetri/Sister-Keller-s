using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExamManager : MonoBehaviour
{
    [Header("Questions Pool (20 total)")]
    public List<Question> allQuestions = new List<Question>();

    [Header("UI References")]
    public Text questionTextUI;
    public Button[] answerButtons; // assign 4 buttons in inspector

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
        // Shuffle all questions
        List<Question> shuffled = new List<Question>(allQuestions);
        ShuffleList(shuffled);

        // Pick first 10
        selectedQuestions = shuffled.GetRange(0, 10);
    }

    void ShowQuestion()
    {
        if (currentQuestionIndex >= selectedQuestions.Count)
        {
            EndExam();
            return;
        }

        Question q = selectedQuestions[currentQuestionIndex];

        // Shuffle answer order
        List<int> answerOrder = new List<int> { 0, 1, 2, 3 };
        ShuffleList(answerOrder);

        // Set question text
        questionTextUI.text = q.questionText;

        // Set button texts and listeners
        for (int i = 0; i < answerButtons.Length; i++)
        {
            int answerIndex = answerOrder[i];
            answerButtons[i].GetComponentInChildren<Text>().text = q.answers[answerIndex];

            // Clear old listeners
            answerButtons[i].onClick.RemoveAllListeners();

            // Capture index inside closure
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
        // TODO: Show results on canvas (you can add a panel with final message)
    }

    // Utility: shuffle any list
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
