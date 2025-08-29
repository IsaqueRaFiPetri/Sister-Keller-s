using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [TextArea] public string tooltipMessage;

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipUI.Instance.ShowTooltip(tooltipMessage);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipUI.Instance.HideTooltip();
    }
}
