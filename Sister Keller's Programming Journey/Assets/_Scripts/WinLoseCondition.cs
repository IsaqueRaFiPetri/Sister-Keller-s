using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseCondition : MonoBehaviour
{
    public void EndGame()
    {
        SceneManager.LoadScene("CamTest");
    }
}
