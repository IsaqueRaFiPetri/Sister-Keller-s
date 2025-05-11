using System.Collections.Generic;
using UnityEngine;

public class ActivateNextObject : MonoBehaviour
{
    [Header("Lista de objetos a serem ativados")]
    public List<GameObject> objectsToActivate;

    private int currentIndex = -1;

    public void ActivateNext()
    {
        // Desativa o anterior (se houver)
        if (currentIndex >= 0 && currentIndex < objectsToActivate.Count)
        {
            objectsToActivate[currentIndex].SetActive(false);
        }

        // Avança para o próximo
        currentIndex++;

        // Se chegou ao fim da lista, volta pro início (ou comente esta linha se quiser parar no fim)
        if (currentIndex >= objectsToActivate.Count)
        {
            currentIndex = 0;
        }

        // Ativa o objeto atual
        if (objectsToActivate.Count > 0)
        {
            objectsToActivate[currentIndex].SetActive(true);
        }
    }
}
