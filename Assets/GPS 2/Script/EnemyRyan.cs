using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Collections;

public class EnemyRyan : MonoBehaviour
{
    public bool vistor2;
    public Animator scare;
    [Header("RaycastTesing")]
    public float speed = 5f;
    BuildManager buildManager;
    GameObject targetEnd;
    [SerializeField] NavMeshAgent agent;
    public int Income;

    //public float speed = 10f;

    public float health = 0;
    public float maxHealth = 100;
    public GameObject health1, health2, health3, health1v2, health2v2, health3v2;

    //private Transform target;
    private int wavepointindex = 0;

    public Color outlineColor;
    
    //lose amount
    public float reduceHealthAmnt = 2.0f;

    Renderer rend;
    private int enemyLeft;
    private Transform target;


    public static bool finalDeath = false;
    bool firstHit = true;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameMaster = GameObject.Find("Game Manager");
        WaveSpawnRyan waveSpawnRyan = gameMaster.GetComponent<WaveSpawnRyan>();
        enemyLeft = waveSpawnRyan.totalEnemies;
        target = WayPoint.points[0];
        buildManager = BuildManager.instance;

    }

    public void TakeDamage(float amount)
    {
        
        health += amount;
        scare.Play("Visitor_Scaredd");

        if(health >= maxHealth)
        {
            
            health = maxHealth;
        }
    }

    private void takeDamageChange()
    {
        if (health >= 0 && health <= 49)
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

            if (firstHit == false)
            {
                Income = (Income * 25)/ 100;
                firstHit = true;
            }

        }
        else if (health > 50 && health <= 69)
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

        }
        else if (health >= 70)
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

            if(firstHit == true)
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

            health = health - (reduceHealthAmnt * Time.deltaTime);

        }

    }

    public void BecomeSlowed()
    {
        Debug.Log("slowed");
        speed -= 4;
    }

    // Update is called once per frame
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
        if (health >= 0 && health <= 20)
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

        if(enemyLeft <= 0)
        {
            finalDeath = true;
            Debug.Log("Final enemy died");
        }
        enemyLeft--;
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
