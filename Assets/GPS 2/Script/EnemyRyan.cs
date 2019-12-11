using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Collections;

public class EnemyRyan : MonoBehaviour
{
    #region Public Variable
    public GameObject health1, health2, health3, health1v2, health2v2, health3v2, health1v3, health2v3, health3v3;
    public bool vistor2;
    public bool vistor3;
    public Animator scare1, scare2, scare3;
    public static bool finalDeath = false;
    //[HideInInspector]
    public float health = 0;
    #endregion

    #region Designer Editor
    [Header ("Designer Editor")]
    public float speed = 5f;
    public int Income;
    public float maxHealth = 100;
    public float reduceHealthPerSec = 2.0f;
    [Header ("Yellow To Orange")]
    public int minYellow;
    public int maxYellow;
    [Header("Orange To Red")]
    public int minOrange;
    public int maxOrange;
    [Header(" Red")]
    public int minRed;
    #endregion

    #region Private Variable
    GameObject targetEnd;
    Renderer rend;
    BuildManager buildManager;
    private int enemyLeft;
    private Transform target;
    private int wavepointindex = 0;
    bool firstHit = true;
    [SerializeField] NavMeshAgent agent;
    GameManager gameManager;
    #endregion
   
    void Start()
    {
        finalDeath = false;
        GameObject gameMaster = GameObject.Find("Game Manager");
        WaveSpawnRyan waveSpawnRyan = gameMaster.GetComponent<WaveSpawnRyan>();
        gameManager = gameMaster.GetComponent<GameManager>();
        enemyLeft = waveSpawnRyan.totalEnemies;
        target = WayPoint.points[0];
        buildManager = BuildManager.instance;

    }

    public void TakeDamage(float amount)
    {
        
        health += amount;
        scare1.Play("Visitor_Scaredd");
        if(vistor2 == true)
        {
            scare2.Play("Visitor_Scaredd");
        }
        if (vistor3 == true)
        {
            scare3.Play("Visitor_Scaredd");
        }

        if (health >= maxHealth)
        {
            
            health = maxHealth;
        }

        Debug.Log("Damage Duel " + amount);
    }

    private void takeDamageChange()
    {
        if (health >= minYellow && health <= maxYellow)
        {
            health1.SetActive(true);
            health2.SetActive(false);
            health3.SetActive(false);

            if (vistor2 == true)
            {
                health1v2.SetActive(true);
                health2v2.SetActive(false);
                health3v2.SetActive(false);
            }
            if (vistor3 == true)
            {
                health1v3.SetActive(true);
                health2v3.SetActive(false);
                health3v3.SetActive(false);
            }

            if (firstHit == false)
            {
                Income = (Income * 75)/ 100;
                firstHit = true;
            }

        }
        else if (health > minOrange && health <= maxOrange)
        {
            health1.SetActive(false);
            health2.SetActive(true);
            health3.SetActive(false);

            if (vistor2 == true)
            {
                health1v2.SetActive(false);
                health2v2.SetActive(true);
                health3v2.SetActive(false);
            }

            if (vistor3 == true)
            {
                health1v3.SetActive(false);
                health2v3.SetActive(true);
                health3v3.SetActive(false);
            }

        }
        else if (health >= minRed)
        {
            health1.SetActive(false);
            health2.SetActive(false);
            health3.SetActive(true);

            if (vistor2 == true)
            {
                health1v2.SetActive(false);
                health2v2.SetActive(false);
                health3v2.SetActive(true);
            }

            if (vistor3 == true)
            {
                health1v3.SetActive(false);
                health2v3.SetActive(false);
                health3v3.SetActive(true);
            }

            if (firstHit == true)
            {
                buildManager.income(Income);
                firstHit = false;
            }
        }

    }


    private void reduceHealthOverTime()
    {

        if (health > 0)
        {

            health = health - (reduceHealthPerSec * Time.deltaTime);

        }

    }

    public void BecomeSlowed()
    {
        Debug.Log("slowed");
        speed -= 4;
    }

    void Update()
    {
        takeDamageChange();
        reduceHealthOverTime();
        Raycast();
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

    }

    private void GetNextWaypoint()
    {
        if(wavepointindex >= WayPoint.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointindex++;
        target = WayPoint.points[wavepointindex];
    }

    void EndPath()
    {        
        Debug.Log("Enemies left = " + enemyLeft);
        if (health > 0 && health <= 20)
        {
            PlayerStats.spookPoint += 1;
        }
        else if (health > 20 && health <= 40)
        {
            PlayerStats.spookPoint += 2;
        }
        else if (health >= 40)
        {
            PlayerStats.spookPoint += 3;
        }
        else if (health <= 0)
        {
            PlayerStats.losePoint += 1;
        }

        Destroy(gameObject);
        gameManager.enemyLeft -= 1;
        /*
        if(enemyLeft <= 0)
        {
            finalDeath = true;
            Debug.Log("Final enemy died");
        }
        enemyLeft--;
        */
    }

    void Raycast()
    {
        RaycastHit rightHit;
        if (Physics.Raycast(transform.position + Vector3.down / 2, transform.TransformDirection(Vector3.right), out rightHit, 0.2f))
        {

             if (rightHit.transform.CompareTag("Finish"))
            {
                EndPath();
                Debug.Log("Spook point = " + PlayerStats.spookPoint);
                Debug.Log("EnemyRyan" + enemyLeft);
                Debug.Log("EnemyRyan" + finalDeath);
            }
        }



        

       
    }
}
