using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class InteractableObject : MonoBehaviour
{
    protected abstract void Interact();

}