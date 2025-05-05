using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public static PlayerInteractions Instance;
    
    Transform cam;
    public float handDistance = 3;
    private IInteractable currentInteractable;

    //public GameObject interactionInstruction;

    void Start()
    {
        Instance = this;
        cam = Camera.main.transform;
    }
    void Update()
    {
        RayCast();

        if (currentInteractable != null && Input.GetButtonDown("Fire1"))
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

            /*if (Input.GetButtonDown("Fire1") && interactable != null)
            {
                currentInteractable.Interact();
                currentInteractable = interactable;

                //hit.collider.SendMessage("Interact", SendMessageOptions.DontRequireReceiver);
            }
            //interactionInstruction.SetActive(hit.collider.CompareTag("Interagivel"));
        }
        else
        {
            interactionInstruction.SetActive(false);
        }*/
            print(hit);
        }
    }

}
