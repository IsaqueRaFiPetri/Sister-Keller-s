using UnityEngine;
using UnityEngine.Events;

public class ClickOnTrigger : MonoBehaviour, IInteractable
{
    [Header("Evento chamado ao interagir")]
    [SerializeField] private UnityEvent onInteract;

    public void Interact()
    {
        onInteract?.Invoke();
    }
}
