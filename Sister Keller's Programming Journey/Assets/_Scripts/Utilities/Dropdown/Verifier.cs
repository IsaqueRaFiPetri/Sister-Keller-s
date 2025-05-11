
using UnityEngine;
using UnityEngine.Events;

enum verifier
{
    none, wrong, correct
}
public class Verifier : MonoBehaviour
{
    public static Verifier Instance;
    public int correctDropdowns, currentDropdowns;
    public UnityEvent Correct, Wrong, Verify;

    public void Awake()
    {
        currentDropdowns = 0;
        Instance = this;
    }
    public void VerifyCall()
    {
        Verify.Invoke();
    }
    public void verifier()
    {
        if (currentDropdowns >= correctDropdowns)
        {
            Correct.Invoke();
            Debug.Log("Está Correto");
        }
        else
        {
            Wrong.Invoke();
            Debug.Log("Está Incorreto");
        }
    }
}
