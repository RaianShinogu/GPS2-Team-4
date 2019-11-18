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

    private bool gameStart = false;
    public bool isTutorial;
    int StageCount;

    //private int waveIndex = 0;
    private int waveNumber = 1;
    [HideInInspector] public int totalEnemies;
    public int totalEnemiesEachWave;
    public int incomingWave ;
    int totalEnemy;
 

    private void Start()
    {
        totalEnemies = incomingWave * totalEnemiesEachWave;
        totalEnemy = totalEnemies;
        Debug.Log("Total enemies (start) = " + totalEnemies);
    }

    void Update ()
    {
        if (gameStart == true)
        {
            if(incomingWave >= 0)
            {

              if (countdown <= 0f && totalEnemies > 0)
              {
                 //Debug.Log("Total enmies = " + totalEnemies);
                   StartCoroutine(SpawnWaveMulti());
                   totalEnemies--;
                   totalEnemiesEachWave--;
                   
                   //SpawnWave();
                   countdown = timeBetweenWaves;
                    if(totalEnemies == totalEnemy / 2 && incomingWave >= 2)
                    {
                        wave.SetActive(true);
                        gameStart = false;
                        incomingWave--;
                    }
              }
               
                 


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
            yield return new WaitForSeconds(1.0f);
        }
    }

    void SpawnWave()
    {
        /*for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
        }*/
        //waveNumber++;
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        
        Instantiate(enemyPrefab, spawnPoint.position + Vector3.up*2, spawnPoint.rotation);

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
        if(isTutorial == true)
        {
            tutorialVistor.SetActive(false);
        }
        
        
        
        

    }

    
}
