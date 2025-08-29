using UnityEngine;

public class Tooltip3D : MonoBehaviour
{
    [TextArea] public string tooltipMessage;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform == transform)
            {
                TooltipUI.Instance.ShowTooltip(tooltipMessage);
            }
            else
            {
                TooltipUI.Instance.HideTooltip();
            }
        }
        else
        {
            TooltipUI.Instance.HideTooltip();
        }
    }
}
