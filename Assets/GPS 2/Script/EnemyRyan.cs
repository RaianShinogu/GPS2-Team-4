using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Collections;

public class EnemyRyan : MonoBehaviour
{
    public Image scareMeter;

    [Header("RaycastTesing")]
    public float speed = 10f;
    public int turnLeft = -90;
    public int turnRight = 90;
    public int rotation;
    GameObject targetEnd;
    [SerializeField] NavMeshAgent agent;

    //public float speed = 10f;

    public float health = 0;
    public float maxHealth = 100;

    private Transform target;
    private int wavepointindex = 0;

    public Color outlineColor;

    Renderer rend;
    private int enemyLeft;


    public static bool finalDeath = false;
    

    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(targetEnd.transform.position);
        StartCoroutine(RecalculatePathRotine());
        GameObject gameMaster = GameObject.Find("GameMaster");
        WaveSpawnRyan waveSpawnRyan = gameMaster.GetComponent<WaveSpawnRyan>();
        enemyLeft = waveSpawnRyan.totalEnemies;

        //transform.eulerAngles = new Vector3(80, 0, 0);
        //target = Waypoints.points[0];        
        rend = GetComponent<Renderer>();
        rend.material.SetColor("_FirstOutlineColor", Color.green);
    }

    void Awake()
    {
        targetEnd = GameObject.Find("End");
    }
    public void TakeDamage(float amount)
    {
        Debug.Log("damaged");
        health += amount;


        if(health >= 0 && health <= 20)
        {
            rend.material.SetColor("_FirstOutlineColor", Color.green);
        }
        else if(health > 20 && health <= 40)
        {
            rend.material.SetColor("_FirstOutlineColor", Color.blue);
        }
        else
        {
            rend.material.SetColor("_FirstOutlineColor", Color.red);
        }

        
        


        //scareMeter.fillAmount = health/maxHealth;

        if(health >= maxHealth)
        {
            
            health = maxHealth;
        }
    }

    IEnumerator RecalculatePathRotine()
    {
        WaitForSeconds delay = new WaitForSeconds(0.1f);
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            agent.SetDestination(target.transform.position);
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
        Raycast();
        //transform.Translate(speed * Time.deltaTime, 0, 0);

        /*Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

        if(speed >= 10)
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

    /*private void GetNextWaypoint()
    {
        if(wavepointindex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointindex++;
        target = Waypoints.points[wavepointindex];
    }*/

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
        else
        {
            PlayerStats.spookPoint += 3;
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
            if (rightHit.transform.CompareTag("EnemyTurnLeft"))
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
            }

            else if (rightHit.transform.CompareTag("Finish"))
            {
                EndPath();
                Debug.Log("Spook point = " + PlayerStats.spookPoint);
            }
        }



        //turn right
        /*
        else if (Physics.Raycast(transform.position + Vector3.down / 2, transform.TransformDirection(Vector3.forward), out forwardHit, 0.7f))
        {
            if (forwardHit.transform.CompareTag(TurnLeftPath))
            {
                Debug.Log("turn left");
                rotation += turnLeft;
                transform.eulerAngles = new Vector3(0, rotation, 0);
                
            }


        }



        // right of the object
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out rightHit, 2f))
        {

            if (rightHit.transform.CompareTag("Enemy"))
            {
                //Debug.Log("Hit right");
               
            }


        }
        // front of the object
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out forwardHit, 2f))
        {
            if (forwardHit.transform.CompareTag("Enemy"))
            {
                //Debug.Log("Hit front");
                
            }


        }
        // left of the object
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out leftHit, 2f))
        {
            if (leftHit.transform.CompareTag("Enemy"))
            {
                //Debug.Log("Hit left");
                
            }


        }*/

       
    }
}
