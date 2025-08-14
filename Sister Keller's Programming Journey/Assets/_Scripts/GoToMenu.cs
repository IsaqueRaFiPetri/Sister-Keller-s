using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour
{
    public bool goToMenuOnEnable = false;

    private void OnEnable()
    {
        if (goToMenuOnEnable)
        {
            SceneManager.LoadScene("GameMap");
        }
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("GameMap");
    }
}