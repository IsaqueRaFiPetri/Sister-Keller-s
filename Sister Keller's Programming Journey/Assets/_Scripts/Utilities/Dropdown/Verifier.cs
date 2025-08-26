using UnityEngine;
using UnityEngine.Events;

public class Verifier : MonoBehaviour
{
    public static Verifier Instance;

    public UnityEvent Correct;
    public UnityEvent Wrong;
    public UnityEvent Verify;

    [SerializeField] DropdowManager[] dropdowns;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void VerifyCall() // put on OnClick
    {
        Verify?.Invoke();

        // reset count
        int currentDropdowns = 0;
        
        foreach (var d in dropdowns)
        {
            if (d.IsCorrect())
                currentDropdowns++;
        }

        // check result
        if (currentDropdowns == dropdowns.Length)
        {
            Correct?.Invoke();
            Debug.Log("Está Correto");
        }
        else
        {
            Wrong?.Invoke();
            Debug.Log("Está Incorreto");
        }
    }
}
