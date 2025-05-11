using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenPuzzle : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject puzzleObj;
    [SerializeField] string sceneName;

    [SerializeField] bool isObj, isScene;

    #region ByClick
    void OpenPuzzleByUI()
    {
        puzzleObj.SetActive(true);
    }

    void OpenMinigameScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Interact()
    {
        if(isObj)
            OpenPuzzleByUI();

        else if(isScene)
            OpenMinigameScene();
    }
    #endregion ByClick
}
