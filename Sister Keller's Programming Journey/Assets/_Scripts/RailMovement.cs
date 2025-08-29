using UnityEngine;

public class RailMovement : MonoBehaviour
{
    [Header("Pontos de limite")]
    public Transform pointA; // limite superior
    public Transform pointB; // limite inferior

    [Header("Configurações de movimento")]
    public float moveSpeed = 5f; // velocidade de movimento
    public float rotateSpeed = 100f; // velocidade de rotação (graus por segundo)

    // Valor 0 = em A, valor 1 = em B
    private float t = 0.5f; // começa no meio da linha

    private void Update()
    {
        HandleMovement();
        HandleRotation();

        // Atualiza posição ao longo da linha
        transform.position = Vector3.Lerp(pointA.position, pointB.position, t);
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            // Move em direção ao pointA
            t -= (moveSpeed * Time.deltaTime) / Vector3.Distance(pointA.position, pointB.position);
        }

        if (Input.GetKey(KeyCode.S))
        {
            // Move em direção ao pointB
            t += (moveSpeed * Time.deltaTime) / Vector3.Distance(pointA.position, pointB.position);
        }

        // Mantém o valor dentro dos limites
        t = Mathf.Clamp01(t);
    }

    private void HandleRotation()
    {
        float rotation = 0f;

        if (Input.GetKey(KeyCode.A))
            rotation = -rotateSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
            rotation = rotateSpeed * Time.deltaTime;

        transform.Rotate(0f, rotation, 0f);
    }
}
