using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseCondition : MonoBehaviour
{
    public void EndGame()
    {
        SceneManager.LoadScene("CamTest");
    }

    public void EndWonGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
