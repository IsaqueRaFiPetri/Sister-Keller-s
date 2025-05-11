using UnityEngine;
using UnityEngine.Events;

public class MainCam : MonoBehaviour
{
    public UnityEvent Evento;

    public void Start()
    {
        Evento.Invoke();
    }
    
}
