using UnityEngine;

public class VirusManager : MonoBehaviour
{
    public ProgressBar progressBar;
    public float virusDelayTime = 2f; // atraso que um vírus causa

    public void OnVirusReachedDownload()
    {
        progressBar.DelayProgress(virusDelayTime);
        progressBar.RegisterVirusHit();
    }
}
