using UnityEngine;

public class OutlineRaycaster : MonoBehaviour
{
    public Camera cam; // pode ser a main camera
    public float rayDistance = 10f;

    private Outline lastOutline;

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition); // ou usa transform.forward se quiser Raycast na frente do player
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            Outline outline = hit.collider.GetComponent<Outline>();

            if (outline != null)
            {
                // Se o objeto for diferente do último, desativa o anterior
                if (lastOutline != null && lastOutline != outline)
                {
                    lastOutline.enabled = false;
                }

                outline.enabled = true;
                lastOutline = outline;
            }
            else if (lastOutline != null)
            {
                // Se o Raycast não bateu num objeto com Outline
                lastOutline.enabled = false;
                lastOutline = null;
            }
        }
        else if (lastOutline != null)
        {
            // Se o Raycast não bateu em nada
            lastOutline.enabled = false;
            lastOutline = null;
        }
    }
}
