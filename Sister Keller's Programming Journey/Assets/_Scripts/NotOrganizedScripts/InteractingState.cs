using UnityEngine;

public class InteractingState : MonoBehaviour
{
    public FirstPersonController FirstPersonController;
    
    public void Start()
    {
        FirstPersonController = Object.FindFirstObjectByType<FirstPersonController>();
    }
}
