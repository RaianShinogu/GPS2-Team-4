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
    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.points[0];
    }

    public void TakeDamage(float amount)
    {
        Debug.Log("damaged");
        health += amount;
        scareMeter.fillAmount = health/maxHealth;

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
            Destroy(gameObject);
            return;
        }

        wavepointindex++;
        target = Waypoints.points[wavepointindex];
    }
}
