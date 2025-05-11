using UnityEngine;

public class InteractingState : MonoBehaviour
{
    public FirstPersonController FirstPersonController;
    public void Interacting()
    {
        FirstPersonController.walkSpeed = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void NotInteracting()
    {
        FirstPersonController.walkSpeed = 5;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
