using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Image fillImage;
    public float duration = 60f;
    public float fillSpeed = 0.2f;
    public UnityEvent GameWin;
    public UnityEvent GameLose;
    public WonMinigame WonMinigame;

    private float timer = 0f;
    private bool isFilling = false;

    public float Progress => Mathf.Clamp01(timer / duration);

    public int maxVirusHits = 10;
    public int currentVirusHits = 0;

    public delegate void OnLoseHandler();
    public event OnLoseHandler OnLose;

    void Start()
    {
        StartFilling();
        WonMinigame = Object.FindFirstObjectByType<WonMinigame>();

    }

    void Update()
    {
        if (isFilling)
        {
            timer += Time.deltaTime * fillSpeed;

            fillImage.fillAmount = Progress;

            if (Progress >= 1f)
            {
                isFilling = false;
                Debug.Log("Download completo!");
                GameWin.Invoke();
                WonMinigame.WonPcGame = true;
            }
        }

    }
    public void AfterGame()
    {
        maxVirusHits = 10;
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
        timer -= seconds;
        timer = Mathf.Max(0f, timer); // não deixa passar de 0
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
}
