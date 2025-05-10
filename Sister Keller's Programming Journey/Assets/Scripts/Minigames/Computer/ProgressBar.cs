using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Image fillImage;
    public float duration = 20f;

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
    }

    void Update()
    {
        if (isFilling)
        {
            timer += Time.deltaTime;
            fillImage.fillAmount = Progress;

            if (Progress >= 1f)
            {
                isFilling = false;
                Debug.Log("Download completo!");
            }
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
        }
    }
}
