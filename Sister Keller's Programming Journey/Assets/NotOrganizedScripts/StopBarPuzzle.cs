using UnityEngine;
using UnityEngine.UI;

public class StopBarPuzzle : MonoBehaviour
{
    [SerializeField] RectTransform pointer;
    [SerializeField] RectTransform greenZone;
    [SerializeField] float speed = 200f;

    [SerializeField] GameObject infoPanel;
    [SerializeField] int needToOpen = 3;

    private bool moving = true;
    private int neededCorrect = 0;
    private float direction = 1f;

    // Limites para a reversão (ajuste conforme o layout da sua barra)
    [SerializeField] float limitLeft = -700f;
    [SerializeField] float limitRight = 700f;

    void Start()
    {
        if (infoPanel != null)
            infoPanel.SetActive(false);
    }

    void Update()
    {
        if (moving)
        {
            // Movimento
            pointer.anchoredPosition += Vector2.right * speed * direction * Time.deltaTime;

            // Inverte a direção ao bater nas bordas
            if (pointer.anchoredPosition.x > limitRight || pointer.anchoredPosition.x < limitLeft)
            {
                direction *= -1f;
                // Garante que não passe do limite
                float clampedX = Mathf.Clamp(pointer.anchoredPosition.x, limitLeft, limitRight);
                pointer.anchoredPosition = new Vector2(clampedX, pointer.anchoredPosition.y);
            }

            // Input
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                moving = false;
                CheckSuccess();
            }
        }
    }

    void CheckSuccess()
    {
        Vector3 pointerWorldPos = pointer.TransformPoint(pointer.rect.center);
        Vector3 greenWorldMin = greenZone.TransformPoint(new Vector3(-greenZone.rect.width / 2f, 0f, 0f));
        Vector3 greenWorldMax = greenZone.TransformPoint(new Vector3(greenZone.rect.width / 2f, 0f, 0f));

        if (pointerWorldPos.x >= greenWorldMin.x && pointerWorldPos.x <= greenWorldMax.x)
        {
            Debug.Log("SUCESSO! Parou na zona correta.");
            neededCorrect++;

            if (neededCorrect >= needToOpen)
            {
                Debug.Log("Desbloqueado!");
                if (infoPanel != null)
                    infoPanel.SetActive(true);
                return;
            }

            Invoke(nameof(ResetGame), 1f);
            MoveGreenZoneRandomly();
        }
        else
        {
            Debug.Log("FALHOU! Tente novamente.");
            Invoke(nameof(ResetGame), 1f);
            MoveGreenZoneRandomly();
        }

        float halfWidth = greenZone.rect.width / 2f;
        float randomX = Random.Range(limitLeft + halfWidth, limitRight - halfWidth);
        greenZone.anchoredPosition = new Vector2(randomX, greenZone.anchoredPosition.y);
    }

    public void ResetGame()
    {
        // Opcional: reseta para a borda inicial e direção para direita
        pointer.anchoredPosition = new Vector2(limitLeft, pointer.anchoredPosition.y);
        direction = 1f;
        moving = true;
    }
    void MoveGreenZoneRandomly()
    {
        float halfWidth = greenZone.rect.width / 2f;
        float randomX = Random.Range(limitLeft + halfWidth, limitRight - halfWidth);
        greenZone.anchoredPosition = new Vector2(randomX, greenZone.anchoredPosition.y);
    }

}