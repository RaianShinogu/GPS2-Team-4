using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyRyan : MonoBehaviour
{
    public Image scareMeter;


    public float speed = 10f;

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
        GameObject gameMaster = GameObject.Find("GameMaster");
        WaveSpawnRyan waveSpawnRyan = gameMaster.GetComponent<WaveSpawnRyan>();
        enemyLeft = waveSpawnRyan.totalEnemies;

        target = Waypoints.points[0];        
        rend = GetComponent<Renderer>();
        rend.material.SetColor("_FirstOutlineColor", Color.green);
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

    public void BecomeSlowed()
    {
        Debug.Log("slowed");
        speed -= 4;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
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
        }
    }

    private void GetNextWaypoint()
    {
        if(wavepointindex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointindex++;
        target = Waypoints.points[wavepointindex];
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
}
