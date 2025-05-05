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
    FirstPersonController controller;
    public static int politicalPoints, politicsPointsToConclude = 58;

    public UnityEvent OnPause, OnUnpause;

    internal Vector3 velocity;
    public GameObject player;

    void Awake()
    {
        instance = this;
        controller = GetComponent<FirstPersonController>();
    }

    void Update()
    {
        switch (modes)
        {
            case PlayerModes.Walking:
                controller.enabled = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                PlayerInteractions.Instance.enabled = true;
                PlayerInteractions.Instance.RayCast();
                break;
            case PlayerModes.UIing:
                controller.enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                PlayerInteractions.Instance.enabled = false;
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
                modes = PlayerModes.UIing;
                OnPause.Invoke();
            }
            else
            {
                Time.timeScale = 1;
                modes = PlayerModes.Walking;
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

    public void SetUIingMode()
    {
        modes = PlayerModes.UIing;
    }
    public void SetWalkingMode()
    {
        modes = PlayerModes.Walking;
    }
}

