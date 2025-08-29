using UnityEngine;

public class TooltipProvider : MonoBehaviour, ITooltipProvider
{
    [TextArea] public string tooltipMessage;
    public string TooltipText => tooltipMessage;
}
