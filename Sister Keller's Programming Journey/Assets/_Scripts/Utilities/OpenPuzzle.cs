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
            OpenMinigameOnAnotherScene();
        else if (isObjInScene)
            OpenMinigameInScene();
    }

    #region ByClick
    public void OpenMinigameByUI()
    {
        puzzleObj.SetActive(true);
        PlayerStats.instance.SetUIingMode();
    }
    public void OpenMinigameOnAnotherScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void OpenMinigameInScene()
    {
        puzzleArea.SetActive(true);
        PlayerStats.instance.SetUIingMode();
        player.SetActive(false);
    }
    #endregion ByClick
}
