using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public static PlayerInteractions Instance;
    [SerializeField] Camera cam;
    [SerializeField] LayerMask layerMask;

    IInteractable currentInteractable;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        MousePos();        
    }

    public void MousePos()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit rayHit, float.MaxValue, layerMask))
        {
            transform.position = rayHit.point;

            currentInteractable = rayHit.collider.GetComponent<IInteractable>();

            if (currentInteractable != null && Input.GetMouseButtonDown(0))
            {
                currentInteractable.Interact();
            }
        }
    }   
}
