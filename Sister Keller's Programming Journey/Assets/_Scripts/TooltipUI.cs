using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TooltipUI : MonoBehaviour
{
    public static TooltipUI Instance;

    [SerializeField] private RectTransform tooltipTransform;
    [SerializeField] private TextMeshProUGUI tooltipText;
    [SerializeField] private CanvasGroup canvasGroup; // para fade
    [SerializeField] private float fadeSpeed = 8f;
    [SerializeField] private Vector2 offset = new Vector2(15f, 15f); // offset configurável

    private bool visible = false;

    private void Awake()
    {
        Instance = this;
        HideTooltip();
    }

    private void Update()
    {
        // Pega posição do mouse
        Vector2 mousePos = Input.mousePosition;
        Vector2 newPos = mousePos + offset;

        // --- Evitar que o tooltip saia da tela ---
        Vector2 tooltipSize = tooltipTransform.sizeDelta * tooltipTransform.lossyScale;
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // Limite na direita
        if (newPos.x + tooltipSize.x > screenWidth)
            newPos.x = screenWidth - tooltipSize.x;

        // Limite no topo
        if (newPos.y + tooltipSize.y > screenHeight)
            newPos.y = screenHeight - tooltipSize.y;

        // Limite na esquerda
        if (newPos.x < 0)
            newPos.x = 0;

        // Limite embaixo
        if (newPos.y < 0)
            newPos.y = 0;

        // Aplica posição final
        tooltipTransform.position = newPos;

        // Fade in/out
        float targetAlpha = visible ? 1f : 0f;
        canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAlpha, Time.deltaTime * fadeSpeed);

        // Se invisível e alpha já zerado -> desativa
        if (!visible && canvasGroup.alpha <= 0.01f)
            gameObject.SetActive(false);
    }

    public void ShowTooltip(string text)
    {
        tooltipText.text = text;
        visible = true;
        gameObject.SetActive(true); // garante que está ativo
    }

    public void HideTooltip()
    {
        visible = false;
    }
}
