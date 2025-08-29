using UnityEngine;
using UnityEngine.UI;

public class StopBarPuzzle : MonoBehaviour
{
    [Header("Pointer Variables")]
    [SerializeField] RectTransform pointer;
    [SerializeField] float speed;

    [Header("GreenBar Variables")]
    [SerializeField] RectTransform greenZone;
    [SerializeField] float minSize;
    [SerializeField] float maxSize;

    [Header("Limits of the base bar")]
    [SerializeField] float limitLeft;
    [SerializeField] float limitRight;

    [Header("Reward")]
    [SerializeField] GameObject infoPanel;
    [SerializeField] int needToOpen;
    [SerializeField] GameObject gamePainel;
    [SerializeField] float hideDelay;
    [SerializeField] GameObject hideBTN;

    bool moving = true;
    int neededCorrect = 0;
    float direction = 1f;

    void Start()
    {
        if (infoPanel != null)
            infoPanel.SetActive(false);

        MoveGreenZoneRandomly();
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
                {
                    infoPanel.SetActive(true);
                }
                return;
            }

            Invoke(nameof(ResetGame), hideDelay); // delay instead of instant reset
        }
        else
        {
            Debug.Log("FALHOU! Tente novamente.");
            Invoke(nameof(ResetGame), 0f); // wait before retry
        }

        float halfWidth = greenZone.rect.width / 2f;
        float randomX = Random.Range(limitLeft + halfWidth, limitRight - halfWidth);
        greenZone.anchoredPosition = new Vector2(randomX, greenZone.anchoredPosition.y);
    }


    public void HideMinigame()
    {
        if (infoPanel != null)
        {
            gamePainel.SetActive(false);
            hideBTN.SetActive(true);
        }
            
    }

    public void ResetGame()
    {
        pointer.anchoredPosition = new Vector2(limitLeft, pointer.anchoredPosition.y);
        direction = 1f;
        moving = true;

        AdjustGreenZoneSize();
        MoveGreenZoneRandomly();

    }

    #region GreenBarAjustment
    void MoveGreenZoneRandomly() //for the position of the greenBar
    {
        float halfWidth = greenZone.rect.width / 2f;
        float randomX = Random.Range(limitLeft + halfWidth, limitRight - halfWidth);
        greenZone.anchoredPosition = new Vector2(randomX, greenZone.anchoredPosition.y);
    }
    void AdjustGreenZoneSize() //for the length of the greenBar
    {
        float newWidth = Random.Range(minSize, maxSize);
        greenZone.sizeDelta = new Vector2(newWidth, greenZone.sizeDelta.y);
    }
    #endregion GreenBarAjustment


}