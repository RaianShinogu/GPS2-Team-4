using UnityEngine;
using System.Collections;

public class WaveSpawnRyan : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;

    public Transform spawnPoint;
    public GameObject Startwave;
    public GameObject tutorialVistor;
    public GameObject wave;
    int visitorType;

    public float timeBetweenWaves = 5f;
    public DialogManager dialogManager;
    private float countdown = 2f;

    public bool gameStart = false;
    public bool isTutorial;
    int StageCount;

    //private int waveIndex = 0;
    private int waveNumber = 1;
     public int totalEnemies = 0;
    public int totalEnemiesEachWave;
    public int incomingWave ;
     public int totalEnemy;
 

    private void Start()
    {
        totalEnemies = incomingWave * totalEnemiesEachWave;
        totalEnemy = totalEnemies;
        Debug.Log("Total enemies (start) = " + totalEnemies);
        Debug.Log(totalEnemies);
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
                   totalEnemiesEachWave--;
                    totalEnemies--;
                    //SpawnWave();
                    countdown = timeBetweenWaves;
                    if(totalEnemies == totalEnemy / 2 && incomingWave >= 0)
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
        visitorType = Random.Range(0, 3);
        if(visitorType == 0)
        {
            Instantiate(enemyPrefab, spawnPoint.position + Vector3.up * 2, spawnPoint.rotation);
        }
        else if(visitorType == 1)
        {
            Instantiate(enemyPrefab2, spawnPoint.position + Vector3.up * 2, spawnPoint.rotation);
        }
        else if (visitorType == 2)
        {
            Instantiate(enemyPrefab3, spawnPoint.position + Vector3.up * 2, spawnPoint.rotation);
        }


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
        if (isTutorial == true)
        {
            dialogManager.buildingDemolish = false;
        }




    }

    
}
