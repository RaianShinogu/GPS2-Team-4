using UnityEngine;
using System.Collections;

public class WaveSpawnRyan : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;
    public GameObject Startwave;
    public GameObject tutorialVistor;
    public GameObject wave;
    int visitorType;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public bool gameStart = false;
    int StageCount;

    //private int waveIndex = 0;
    public int waveNumber = 1;
    public int totalEnemies = 5;
 

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
            //visitorType = Random.Range(0, 3);
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
        /*if(visitorType == 0)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else if (visitorType == 1)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else if (visitorType == 2)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }*/
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

    public void StartWave()
    {
        gameStart = true;
        wave.SetActive(false);
        tutorialVistor.SetActive(false);
        
        //Startwave.SetActive(false);
        

    }

    
}
