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
   
    GameObject targetEnd;
    [SerializeField] NavMeshAgent agent;

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
    

    // Start is called before the first frame update
    void Start()
    {
        //agent.SetDestination(targetEnd.transform.position);
        //StartCoroutine(RecalculatePathRotine());
        GameObject gameMaster = GameObject.Find("Game Manager");
        WaveSpawnRyan waveSpawnRyan = gameMaster.GetComponent<WaveSpawnRyan>();
        enemyLeft = waveSpawnRyan.totalEnemies;
        
        //transform.eulerAngles = new Vector3(80, 0, 0);
        target = WayPoint.points[0];        
        //rend = GetComponent<Renderer>();
        //rend.material.SetColor("_FirstOutlineColor", Color.green);

    }

    void Awake()
    {
        //targetEnd = GameObject.Find("End");
        
    }
    public void TakeDamage(float amount)
    {
        
        health += amount;
        scare.Play("Visitor_Scaredd");




        Debug.Log(health);
        


        //scareMeter.fillAmount = health/maxHealth;

        if(health >= maxHealth)
        {
            
            health = maxHealth;
        }
    }

    /*IEnumerator RecalculatePathRotine()
    {
        WaitForSeconds delay = new WaitForSeconds(0.1f);
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            agent.SetDestination(targetEnd.transform.position);
        }
    }*/

    private void takeDamageChange()
    {
        if (health >= 0 && health <= 20)
        {
            //rend.material.SetColor("_FirstOutlineColor", Color.green);
            health1.SetActive(true);
            health2.SetActive(false);
            health3.SetActive(false);

            if (vistor2 == true)
            {
                health1v2.SetActive(true);
                health2v2.SetActive(false);
                health3v2.SetActive(false);
            }

        }
        else if (health > 20 && health <= 40)
        {
            //rend.material.SetColor("_FirstOutlineColor", Color.blue);
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
        else if (health > 40)
        {
            //rend.material.SetColor("_FirstOutlineColor", Color.red);
            health1.SetActive(false);
            health2.SetActive(false);
            health3.SetActive(true);

            if (vistor2 == true)
            {
                health1v2.SetActive(false);
                health2v2.SetActive(false);
                health3v2.SetActive(true);
            }

        }

    }


    private void reduceHealthOverTime()
    {

        if (health > 0)
        {

            health = health - (reduceHealthAmnt * Time.deltaTime);
            Debug.Log(health);

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
        //transform.Translate(speed * Time.deltaTime, 0, 0);

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        /*if(speed >= 10)
        {
            speed = 10;
        }
        else if(speed > 0 && speed < 10)
        {
            speed += 1 * Time.deltaTime;
        }
        else if (speed <= 0)
        {
            speed = 1;
        }*/
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
        RaycastHit backHit;
        RaycastHit leftHit;
        RaycastHit rightHit;
        RaycastHit forwardHit;
        //Debug.DrawRay(transform.position + Vector3.down/2 , transform.TransformDirection(Vector3.back) * 0.1f, Color.red); //down
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 5f, Color.red); //(back of the object)
        Debug.DrawRay(transform.position + Vector3.down / 2, transform.TransformDirection(Vector3.right) * 0.2f, Color.red); //front
        //Debug.DrawRay(transform.position + Vector3.down/2 , transform.TransformDirection(Vector3.forward) * 0.1f, Color.red);//up


        //straight
        if (Physics.Raycast(transform.position + Vector3.down / 2, transform.TransformDirection(Vector3.right), out rightHit, 0.2f))
        {
            /*if (rightHit.transform.CompareTag("EnemyTurnLeft"))
            {
                Debug.Log("turn left");
                rotation += turnLeft;
                transform.eulerAngles = new Vector3(80, rotation, 0);
            }

            else if (rightHit.transform.CompareTag("EnemyTurnRight"))
            {
                Debug.Log("turn right");
                rotation += turnRight;
                transform.eulerAngles = new Vector3(80, rotation, 0);
            }*/

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
