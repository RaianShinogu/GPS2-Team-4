using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    
    public Animator building;
    public string BuildingType;
    [SerializeField] GameObject hand;
    [SerializeField] Transform handPosition;
    [SerializeField] GameObject towerRange;
    public GameObject jackOfTheBox;
    public GameObject spawn;
    public bool isSlow = false;
    public bool isDamage = true;
    public bool isGhost;   
    [HideInInspector]
    public string enemyTag = "Visitor";
    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header ("Designer Editor")]
    public float range = 5f;
    public float fireCountDown = 0f;

    private Queue<Bullet> bulletPool = new Queue<Bullet>();
    private Transform target;
    bool coolDown = false;
    float totalFireCountDown;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        building = gameObject.GetComponent<Animator>();
        totalFireCountDown = fireCountDown;
        fireCountDown = 0f;
    }

    void UpdateTarget()
    {
   
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            if (enemy.GetComponent<EnemyRyan>().health < 40)//a
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;

                }
            }
        }
        //---
        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGhost)
            return;
        //towerRange.transform.localScale = Vector3.one * range * 2.0f;

        if (target == null)
        {
            if (BuildingType == "Building 2" || BuildingType == "Building 1")
            {
                building.SetBool("isAttacking", false);
                return;
            }
            else
            {
                return;
            }
                
        }
            

        if(fireCountDown <= 0f)
        {
            //fireCountDown = 1f / fireRate;
            if( BuildingType == "Building 1")
            {
                 building.SetBool("isAttacking", true);
                GameObject jack = Instantiate(jackOfTheBox, spawn.transform.position + Vector3.back, jackOfTheBox.transform.rotation);
                jack.transform.parent = spawn.transform;
                 Shoot();
                fireCountDown = totalFireCountDown;
            }

            else if (BuildingType == "Building 2" )
            {
                //building.Play("Attack");
                Shoot();
                fireCountDown = totalFireCountDown;
            }
            else
            {
                Shoot();
                fireCountDown = totalFireCountDown;
            }

        }

        fireCountDown -= Time.deltaTime;

       
        

    }

    private void Shoot()
    {//pool
        if (bulletPool.Count < 100)
        {
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            bullet.originPos = this.firePoint.transform;
            bulletPool.Enqueue(bullet);
        }
        foreach (Bullet bullet in bulletPool) 
        {
            if (bullet != null)
            {
                bullet.BulletActive();
                bullet.Seek(target, isDamage, isSlow);
                //subject to change
              if (BuildingType == "Building 3")
              {
                 building.Play("Attack", 0, 0.25f);
              }


             

            }
        }
        
    }
    [ExecuteInEditMode]
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

        if(isGhost)
        {
            towerRange.transform.localScale = Vector3.one * range * 2.0f;
        }
        
    }

}
