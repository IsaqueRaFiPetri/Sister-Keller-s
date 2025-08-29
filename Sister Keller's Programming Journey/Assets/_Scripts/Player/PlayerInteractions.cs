using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public static PlayerInteractions Instance;

    [SerializeField] Camera cam;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float tooltipMaxDistance = 5f; // limite de distância em metros

    IInteractable currentInteractable;
    ITooltipProvider currentTooltip;

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

    private void OnDisable()
    {
        TooltipUI.Instance?.HideTooltip();
    }
}
