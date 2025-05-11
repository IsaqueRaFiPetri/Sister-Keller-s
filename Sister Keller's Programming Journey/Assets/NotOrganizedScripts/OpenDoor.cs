using UnityEngine;

public class OpenDoor : MonoBehaviour, IInteractable
{
    [SerializeField] bool doorOpened;
    [SerializeField]float openAngle, closeAngle;
    Transform doorRotation;
    [Space(5)]
    public AudioSource[] audioDoor = new AudioSource[0];

    private void Start()
    {
        doorRotation = GetComponent<Transform>();
    }
    public void Interact()
    {
        if (doorOpened)
        {
            doorRotation.rotation = Quaternion.Euler(0, closeAngle, 0);
            doorOpened = false;
            return;
        }
        doorOpened = true;
        doorRotation.rotation = Quaternion.Euler(0, openAngle, 0);
    }
}
