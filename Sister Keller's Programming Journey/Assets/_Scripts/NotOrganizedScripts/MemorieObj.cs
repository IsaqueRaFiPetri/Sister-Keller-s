using UnityEngine;

public class MemorieObj : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        MemoriesCounter.Instance.memoriesCount++;
        Destroy(gameObject);
        Destroy(transform.parent.gameObject);
        MemoriesCounter.Instance.Artifact--;
    }
}
