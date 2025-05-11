using UnityEngine;
public class Dropdown : MonoBehaviour
{
    public int correctValue, currentValue;
    bool correct;
    public void DropDown(int i)
    {
        currentValue = i;
        if (currentValue == correctValue)
        {
            correct = true;
        }
        else
            correct = false;
    }
    public void Verify() //put in the event VERIFY in VERIFIER.cs
    {
        if (correct)
        {
            Verifier.Instance.currentDropdowns++;
        }
    }
}