using UnityEngine;

public class PlayerPersistence : MonoBehaviour
{
    private static PlayerPersistence instance;

    void Awake()
    {
        if (transform.parent != null)
            transform.SetParent(null);

        /*if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }*/

        instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

}
