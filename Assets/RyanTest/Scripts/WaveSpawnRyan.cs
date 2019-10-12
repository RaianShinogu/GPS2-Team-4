using UnityEngine;
using System.Collections;

public class WaveSpawnRyan : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public bool gameStart = false;
    int StageCount;

    //private int waveIndex = 0;
    public int waveNumber = 1;
    public int totalEnemies = 10;

    public GameObject buildUI;

    private void Start()
    {
        Debug.Log("Total enemies (start) = " + totalEnemies);
    }

    void Update ()
    {
        if (gameStart == true)
        {
            if (countdown <= 0f && totalEnemies > 0)
            {
                //Debug.Log("Total enmies = " + totalEnemies);
                StartCoroutine(SpawnWaveMulti());
                totalEnemies--;
                //SpawnWave();
                countdown = timeBetweenWaves;
            }
        }

        

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWaveMulti()
    {
        //waveIndex++;
        for (int i=0; i< waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

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

    public void StartGame()
    {
        if (StageCount >= 1)
        {
            gameStart = true;
        }
        StageCount++;
    }
}
