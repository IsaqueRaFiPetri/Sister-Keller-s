using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [Header("UI")]
    public Image fillImage;

    [Header("Gameplay")]
    public float duration;
    public float fillSpeed;

    [Header("Events")]
    public UnityEvent GameWin;
    public UnityEvent GameLose;

    [Header("Optional Result Tracker (per instance)")]
    public WonMinigame wonMinigame; // drag the local one in Inspector if needed

    float timer = 0f;
    bool isFilling = false;

    public float Progress => Mathf.Clamp01(timer / duration);

    [Header("Virus Settings")]
    public int maxVirusHits = 10;
    [HideInInspector] public int currentVirusHits = 0;
    [SerializeField] VirusManager virusManager;

    public delegate void OnLoseHandler();
    public event OnLoseHandler OnLose;

    void Start()
    {
        StartFilling();
    }

    void Update()
    {
        if (!isFilling) return;

        timer += Time.deltaTime * fillSpeed;
        fillImage.fillAmount = Progress;

        if (Progress >= 1f)
        {
            isFilling = false;
            Debug.Log("Download completo!");
            GameWin.Invoke();

            if (wonMinigame != null)
                wonMinigame.WonPcGame = true; // per-instance
        }
    }

    public void StartFilling()
    {
        timer = 0f;
        currentVirusHits = 0;
        isFilling = true;
        fillImage.fillAmount = 0f;
    }

    public void DelayProgress(float seconds)
    {
        timer = Mathf.Max(0f, timer - seconds);
        fillImage.fillAmount = Progress;
    }

    public void RegisterVirusHit()
    {
        currentVirusHits++;
        if (currentVirusHits >= maxVirusHits)
        {
            OnLose?.Invoke();
            isFilling = false;
            Debug.Log("Você perdeu: vírus demais atingiram o download.");
            GameLose.Invoke();
        }
    }

    public void RestartPuzzle()
    {
        // Reset win/lose state
        if (wonMinigame != null)
            wonMinigame.ResetWin();

        // Reset progress bar state
        timer = 0f;
        currentVirusHits = 0;
        isFilling = true;

        if (fillImage != null)
            fillImage.fillAmount = 0f;

        // Reset UnityEvents so they can fire again
        GameWin.RemoveAllListeners();
        GameLose.RemoveAllListeners();

        // Optional: restart virus manager counters if needed
        if (virusManager != null)
            virusManager.ResetVirusCounters();

        Debug.Log("Puzzle fully restarted!");
    }
}