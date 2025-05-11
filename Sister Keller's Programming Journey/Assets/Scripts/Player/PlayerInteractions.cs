using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public static PlayerInteractions Instance;
    
    Transform cam;
    public float handDistance = 3;
    private IInteractable currentInteractable;

    //public GameObject interactionInstruction;

    private void Awake()
    {
        Instance = this;
        cam = Camera.main.transform;
    }

    void Update()
    {
        RayCast();

        if (currentInteractable != null && Input.GetMouseButtonDown(0))
        {
            currentInteractable.Interact();
        }
    }

    public void RayCast()
    {
        RaycastHit hit;
        Debug.DrawRay(cam.position, cam.forward * handDistance, Color.blue);

        currentInteractable = null;

        if (Physics.Raycast(cam.position, cam.forward, out hit, handDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                currentInteractable = interactable;
            }
        }
    }

}
