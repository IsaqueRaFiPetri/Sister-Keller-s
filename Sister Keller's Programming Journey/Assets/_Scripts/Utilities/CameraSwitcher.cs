using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera camera2D;
    public Camera camera3D;

    void Start()
    {
        Debug.Log("Camera 3D active");
        camera2D.gameObject.SetActive(false);
        camera3D.gameObject.SetActive(true);
    }

    public void SwitchTo2D()
    {
        Debug.Log("Switching to 2D");
        camera2D.gameObject.SetActive(true);
        camera3D.gameObject.SetActive(false);

        camera2D.tag = "MainCamera";
        camera3D.tag = "Untagged";
    }

    public void SwitchTo3D()
    {
        Debug.Log("Switching to 3D");
        camera2D.gameObject.SetActive(false);
        camera3D.gameObject.SetActive(true);

        camera2D.tag = "Untagged";
        camera3D.tag = "MainCamera";
    }
}
