using UnityEngine;
using UnityEngine.Events;

public class NotePad : MonoBehaviour
{
    [SerializeField] UnityEvent Open, Close;
    bool isOpen = false;

    public void OpenCloseNotePad()
    {
        isOpen =! isOpen;

        if (isOpen == true)
            Open.Invoke();
        else
            Close.Invoke();
    }
}
