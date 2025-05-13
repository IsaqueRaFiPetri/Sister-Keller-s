using UnityEngine;
using TMPro;

public class InitialText : MonoBehaviour
{
    public TextMeshProUGUI textToFade; // arraste o TextMeshProUGUI aqui pelo Inspector
    private float fadeDuration = 5f;
    private float timer = 0f;

    private Color originalColor;

    void Start()
    {
        if (textToFade != null)
        {
            originalColor = textToFade.color;
        }
        else
        {
            Debug.LogWarning("TextMeshProUGUI não atribuído no Inspector.");
            enabled = false;
        }
    }

    void Update()
    {
        if (textToFade != null)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);

            Color newColor = originalColor;
            newColor.a = alpha;
            textToFade.color = newColor;

            if (timer >= fadeDuration)
            {
                Destroy(textToFade.gameObject);
                enabled = false;
            }
        }
    }
}
