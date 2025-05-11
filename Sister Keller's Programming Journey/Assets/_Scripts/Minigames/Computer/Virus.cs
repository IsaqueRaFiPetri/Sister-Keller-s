using UnityEngine;

public class Virus : MonoBehaviour
{
    public Transform target;
    public float speed;
    public int health;

    private ProgressBar progressBar;
    private VirusManager virusManager;

    void Start()
    {
        speed = Random.Range(2f, 6f);
        health = Random.Range(2, 5); // de 3 a 10
    }

    public void Setup(Transform target, ProgressBar progressBar, VirusManager virusManager)
    {
        this.target = target;
        this.progressBar = progressBar;
        this.virusManager = virusManager;
    }

    void Update()
    {
        if (target == null) return;

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            virusManager.OnVirusReachedDownload();
            Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
