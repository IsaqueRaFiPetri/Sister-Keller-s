using UnityEngine;

public class VirusManager : MonoBehaviour
{
    public ProgressBar progressBar;
    public float virusDelayTime = 2f;

    public void OnVirusReachedDownload()
    {
        if (progressBar == null) return;

        progressBar.DelayProgress(virusDelayTime);
        progressBar.RegisterVirusHit();
    }

    public void ResetVirusCounters()
    {
        // For now, reset progress bar hits
        if (progressBar != null)
        {
            progressBar.currentVirusHits = 0;
        }


    }
}