using UnityEngine;

public class RandomChildActivator : MonoBehaviour
{
    void OnEnable()
    {
        ActivateRandomChild();
    }

    void ActivateRandomChild()
    {
        int childCount = transform.childCount;

        if (childCount == 0) return;

        // Desativa todos os filhos primeiro
        for (int i = 0; i < childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        // Escolhe um filho aleatório para ativar
        int randomIndex = Random.Range(0, childCount);
        transform.GetChild(randomIndex).gameObject.SetActive(true);
    }
}
