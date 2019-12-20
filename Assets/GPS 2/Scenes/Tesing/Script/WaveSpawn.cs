using UnityEngine;
using System.Collections;

public class WaveSpawn : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private int waveIndex = 0;
    public bool gameStart = false;
    int StageCount;
    public GameObject buildUI;
    void Update ()
    {
        if(gameStart == true)
        {
            if (countdown <= 0f)
            {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
            }
        }
        

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i=0; i< waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }
        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public void StartGame()
    {
        if (StageCount >= 1)
        {
            gameStart = true;
        }
        StageCount++;
    }
}
