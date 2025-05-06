using UnityEngine;

public class OpenPuzzle : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject puzzleObj;

    #region ByClick
    void OpenPuzzleByUI()
    {
        puzzleObj.SetActive(true);
    }

    public void Interact()
    {
        OpenPuzzleByUI();
    }
    #endregion ByClick
}
