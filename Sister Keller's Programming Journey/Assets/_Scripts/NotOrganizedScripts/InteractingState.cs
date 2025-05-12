using UnityEngine;

public class InteractingState : MonoBehaviour
{
    public FirstPersonController FirstPersonController;
    public void Interacting()
    {
        PlayerStats.instance.SetUIingMode();
    }
    public void NotInteracting()
    {
        PlayerStats.instance.SetWalkingMode();
    }
    public void Start()
    {
        FirstPersonController = Object.FindFirstObjectByType<FirstPersonController>();
    }
}
