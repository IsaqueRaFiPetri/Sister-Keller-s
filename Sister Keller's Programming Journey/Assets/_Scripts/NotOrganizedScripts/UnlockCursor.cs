using UnityEngine;

public class UnlockCursor : MonoBehaviour
{
    public bool turnSwitch;
    void Start()
    {
        if (turnSwitch)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("CursorUnlocked");
        }
        if (!turnSwitch)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Debug.Log("CursorLocked");
            Cursor.visible = false;
        }
    }

}
