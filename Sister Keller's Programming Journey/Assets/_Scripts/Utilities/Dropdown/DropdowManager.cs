using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropdowManager : MonoBehaviour
{
    TMP_Dropdown dropdown;
    public int correctValue, currentValue;
    bool correct;
    public void DropDown()
    {
        currentValue = dropdown.value;
        if (currentValue == correctValue)
        {
            correct = true;
        }
        else
            correct = false;
    }
    private void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
    }
    private void Update()
    {
        Debug.Log(currentValue);
    }
    public void Verify() //put in the event VERIFY in VERIFIER.cs
    {
        if (correct == true)
        {
            Verifier.Instance.currentDropdowns++;
        }
    }
}