using UnityEngine;
using UnityEngine.Events;

public enum PlayerModes
{
    Walking, UIing
}
public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    PlayerModes modes;
    
    public UnityEvent OnPause, OnUnpause;
    PlayerInteractions playerInteract;

    void Awake()
    {
        instance = this;
        playerInteract = GetComponent<PlayerInteractions>();
    }

    void Update()
    {
        switch (modes)
        {
            case PlayerModes.Walking:
                PlayerInteractions.Instance.MousePos();
                break;
            case PlayerModes.UIing:
                break;
        }
        PauseControl();
    }

    public void PauseControl()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                OnPause.Invoke();
            }
            else
            {
                Time.timeScale = 1;
                OnUnpause.Invoke();
            }
        }
    }
    public void SetPause()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}

