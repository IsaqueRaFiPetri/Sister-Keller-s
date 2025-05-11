using UnityEngine;
using UnityEngine.Events;

public class BookGame : MonoBehaviour, IInteractable
{ 
    public UnityEvent bookGame;
    public void Interact()
    {
        bookGame.Invoke();
    }
}
