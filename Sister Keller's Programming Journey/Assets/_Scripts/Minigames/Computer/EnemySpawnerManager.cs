using UnityEngine;
using System.Collections.Generic;

public class EnemySpawnerManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<Transform> spawnPoints = new List<Transform>();
    public ProgressBar progressBar;

    private float spawnTimer = 0f;
    private float baseSpawnInterval = 2f;
    public Transform target; // alvo do vírus (ex: ícone de download)
    public VirusManager virusManager;
    public float spawnAcceleration = 0.01f;



    void Update()
    {
        if (progressBar == null || spawnPoints.Count == 0) return;

        float progress = progressBar.Progress;
        float currentSpawnInterval = Mathf.Lerp(baseSpawnInterval, 0.9f, progress);

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= currentSpawnInterval)
        {
            spawnTimer = 0f;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        int index = Random.Range(0, spawnPoints.Count);
        Transform spawnPoint = spawnPoints[index];

        GameObject virusObj = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        Virus virus = virusObj.GetComponent<Virus>();
        if (virus != null)
        {
            virus.Setup(target, progressBar, virusManager);
        }
    }

}
