using UnityEngine;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(BoxCollider))]
public class OpenPuzzle : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject puzzleObj, puzzleArea, player;
    [SerializeField] string sceneName;

    [SerializeField] bool isObjUI, isScene, isObjInScene;

    public void Interact()
    {
        if (isObjUI)
            OpenMinigameByUI();
        else if (isScene)
            OpenMinigameScene();
        else if (isObjInScene)
            OpenMinigameInScene();
    }

    #region ByClick
    void OpenMinigameByUI()
    {
        puzzleObj.SetActive(true);
        PlayerStats.instance.SetUIingMode();
    }
    void OpenMinigameScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    void OpenMinigameInScene()
    {
        puzzleArea.SetActive(true);
        PlayerStats.instance.SetUIingMode();
        player.SetActive(false);
    }
    #endregion ByClick
}
