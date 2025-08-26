using TMPro;
using UnityEngine;

public class DropdowManager : MonoBehaviour
{
    TMP_Dropdown dropdown;
    public int correctValue;
    bool isCorrect;

    private void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        dropdown.onValueChanged.AddListener(OnDropdownChanged); // listen for changes
        OnDropdownChanged(dropdown.value); // initialize state
    }

    private void OnDropdownChanged(int value)
    {
        isCorrect = (value == correctValue);
    }

    public bool IsCorrect()
    {
        return isCorrect;
    }
}
