using UnityEngine;
using UnityEngine.Events;

//[RequireComponent(typeof(BoxCollider))]
public class OpenPuzzle : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject puzzleObj, puzzleArea, player;
    [SerializeField] bool isObjUI, isObjInScene;
    [SerializeField] UnityEvent Extras;

    public void Interact()
    {
        Extras?.Invoke();
        if (isObjUI)
            OpenMinigameByUI();

        else if (isObjInScene)
            OpenMinigameInScene();
    }

    #region ByClick
    public void OpenMinigameByUI()
    {
        puzzleObj.SetActive(true);

    }
    
    public void OpenMinigameInScene()
    {
        puzzleArea.SetActive(true);
        player.SetActive(false);
    }
    #endregion ByClick
}
