public class MemorieObj : InterectableObj
{
    protected override void Interact()
    {
        MemoriesCounter.Instance.memoriesCount++;
        PlayerInteract.Instance.OnInteractionEffected.Invoke();
        Destroy(gameObject);
        Destroy(transform.parent.gameObject);
        MemoriesCounter.Instance.Artifact--;
    }
}
