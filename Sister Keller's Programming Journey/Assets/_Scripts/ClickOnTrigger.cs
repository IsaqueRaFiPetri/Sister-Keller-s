using UnityEngine;
using UnityEngine.Events;

public class ClickOnTrigger : MonoBehaviour
{
    public UnityEvent onClick; // evento que será chamado no clique

    private bool isOverCircleMouse = false;

    void Update()
    {
        // Verifica se o player está em contato e clicou
        if (isOverCircleMouse && Input.GetMouseButtonDown(0))
        {
            onClick.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CircleMouse"))
        {
            isOverCircleMouse = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CircleMouse"))
        {
            isOverCircleMouse = false;
        }
    }
}
