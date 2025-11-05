using UnityEngine;

// Estados possíveis
public enum PlayerState
{
    Free,       // Pode interagir normalmente
    InPuzzle    // Fazendo puzzle - interações desabilitadas
}
public class PlayerInteractions : MonoBehaviour
{
    public static PlayerInteractions Instance;

    [SerializeField] Camera cam;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float tooltipMaxDistance = 5f; // limite de distância em metros

    IInteractable currentInteractable;
    ITooltipProvider currentTooltip;    

    private PlayerState currentState = PlayerState.Free;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        MousePos();
    }

    public void MousePos()
    {
        // Só processa a interação do mouse se não estiver em puzzle
        if (currentState == PlayerState.InPuzzle)
            return;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit rayHit, tooltipMaxDistance, layerMask, QueryTriggerInteraction.Ignore))
        {
            transform.position = rayHit.point;

            // Interação por clique
            currentInteractable = rayHit.collider.GetComponent<IInteractable>();
            if (currentInteractable != null && Input.GetMouseButtonDown(0))
            {
                currentInteractable.Interact();
            }

            // Tooltip
            var provider = rayHit.collider.GetComponentInParent<ITooltipProvider>();

            if (provider != currentTooltip)
            {
                currentTooltip = provider;

                if (currentTooltip != null)
                {
                    TooltipUI.Instance?.ShowTooltip(currentTooltip.TooltipText);
                }
                else
                {
                    TooltipUI.Instance?.HideTooltip();
                }
            }
        }
        else
        {
            if (currentTooltip != null)
            {
                currentTooltip = null;
                TooltipUI.Instance?.HideTooltip();
            }
        }
    }

    // Métodos para controlar o estado
    public void EnterPuzzleMode()
    {
        currentState = PlayerState.InPuzzle;
        // Esconde o tooltip quando entra no modo puzzle
        TooltipUI.Instance?.HideTooltip();
    }

    public void ExitPuzzleMode()
    {
        currentState = PlayerState.Free;
    }

    public bool IsInPuzzleMode()
    {
        return currentState == PlayerState.InPuzzle;
    }

    public PlayerState GetCurrentState()
    {
        return currentState;
    }

    private void OnDisable()
    {
        TooltipUI.Instance?.HideTooltip();
    }
}