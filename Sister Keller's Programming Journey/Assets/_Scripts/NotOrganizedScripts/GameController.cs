using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject player;

    private static GameController instance;
    public PlayerStats playerStats;
    public PlayerInteractions playerInt;


    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        
    }
    public void Start()
    {
        playerStats = Object.FindFirstObjectByType<PlayerStats>();
        playerInt = Object.FindFirstObjectByType<PlayerInteractions>();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameMap")
        {
            if (player != null)
                player.SetActive(true);
                playerInt.enabled = true;

        }
        else
        {
            if (player != null)
                player.SetActive(false);
        }
    }
}
