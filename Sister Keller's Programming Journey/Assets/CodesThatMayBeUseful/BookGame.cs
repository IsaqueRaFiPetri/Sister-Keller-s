using UnityEngine;
using UnityEngine.Events;

public class BookGame : InterectableObj
{
    public UnityEvent bookGame;

    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Interact()
    {
        PlayerInteract.Instance.OnInteractionEffected.Invoke();
        bookGame.Invoke();
    }
}
