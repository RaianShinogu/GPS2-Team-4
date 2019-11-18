using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]

    public float range = 5f;
    public float fireRate = 1f;
    public float fireCountDown = 0f;
    float totalFireCountDown;
    public float inputAnimationCountDown;
    float animationCountDown;

    public bool isSlow = false;
    public bool isDamage = true;
    public Animator building;
    public string BuildingType;
    [SerializeField] GameObject hand;
    [SerializeField] Transform handPosition;


    [Header("Unity Setup Fields")]

    public string enemyTag = "Visitor";

    public GameObject bulletPrefab;
    public Transform firePoint;
    bool coolDown = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        building = gameObject.GetComponent<Animator>();
        totalFireCountDown = fireCountDown;
        animationCountDown = inputAnimationCountDown;
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

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
        
        if (target == null)
            return;

        if(fireCountDown <= 0f)
        {
            
            //fireCountDown = 1f / fireRate;
            if(BuildingType == "Building 2" || BuildingType == "Building 1")
            {
                if(coolDown == false)
                {
                    building.SetBool("isAttacking", true);
                    Shoot();
                    coolDown = true;
                    animationCountDown = inputAnimationCountDown; 
                }   
                if(animationCountDown <= 0f)
                {
                    building.SetBool("isAttacking", false);
                    fireCountDown = totalFireCountDown;
                    coolDown = false;
                    
                }
                animationCountDown -= Time.deltaTime;
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
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target, isDamage, isSlow);
            //subject to change
            if (building != null)
            {
                if(BuildingType == "Building 2")
                {
                    
                }
                
                else if(BuildingType == "Building 1")
                {
                    building.Play("Attack", 0, 0.25f);
                    Instantiate(hand, handPosition.position + Vector3.up + Vector3.back, hand.transform.rotation);
                }

                else if (BuildingType == "Building 3")
                {
                    building.Play("Attack", 0, 0.25f);
                }



            }
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
