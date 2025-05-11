using UnityEngine;

public class WonMinigame : MonoBehaviour
{
    public bool WonPcGame;

    void Awake()
    {
        var objetos = Object.FindObjectsByType<WonMinigame>(FindObjectsSortMode.None);

        if (objetos.Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

}