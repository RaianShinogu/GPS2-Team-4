using UnityEngine;
using System.Collections;

public class WaveSpawnRyan : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    //private int waveIndex = 0;
    private int waveNumber = 1;

    void Update ()
    {
        if(countdown <= 0f)
        {
            //StartCoroutine(SpawnWave());
            SpawnWave();
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    /*IEnumerator SpawnWave()
    {
        //waveIndex++;
        for (int i=0; i< waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }*/

    void SpawnWave()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
        }
        //waveNumber++;

    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
