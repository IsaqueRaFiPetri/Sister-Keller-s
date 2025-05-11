using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class InformationCheck : MonoBehaviour
{
   public WonMinigame WonMinigame;
    public UnityEvent Won;
    public UnityEvent DidntWin;


    public void Start()
    {
        WonMinigame = Object.FindFirstObjectByType<WonMinigame>();
    }
    public void Check()
    {
        if (WonMinigame.WonPcGame == true)
        {
            Won.Invoke();
        }
        else
        {
            DidntWin.Invoke();
        }
    }

}
