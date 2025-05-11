using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public string cena;
    public void loadScenes()
    {
        SceneManager.LoadScene(cena);
    }

}
