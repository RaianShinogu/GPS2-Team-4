using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawn : MonoBehaviour
{
    public GameObject spawnPosition;
    public GameObject spawnPosition2;
    public GameObject spawnPosition3;
    public GameObject bulletPref;
    public float spawnTime;
    public int maxBulletSpawn;
    public Vector3 offSet;
    public static int bulletLeft = 3;
    public Animator building;
    private int currentBulletAmount;
    private bool isFull;
    // Start is called before the first frame update
    void Start()
    {
        isFull = false;
        currentBulletAmount = 0;
        building.SetBool("isAttacking", true);
        GameObject bulletPrefab = Instantiate(bulletPref, spawnPosition.transform.position + offSet, spawnPosition.transform.rotation);
        GameObject bulletPrefab1 = Instantiate(bulletPref, spawnPosition2.transform.position + offSet, spawnPosition.transform.rotation);
        GameObject bulletPrefab2 = Instantiate(bulletPref, spawnPosition3.transform.position + offSet, spawnPosition.transform.rotation);
        bulletPrefab.transform.parent = spawnPosition.transform;
        bulletPrefab1.transform.parent = spawnPosition2.transform;
        bulletPrefab2.transform.parent = spawnPosition3.transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (bulletLeft == 0)
        {
            currentBulletAmount = 0;
            isFull = false;
            bulletLeft = 3;
        }

        if (currentBulletAmount >= maxBulletSpawn)
        {
            isFull = true;
            return;
        }

        if(isFull == false)
        {
            GameObject bulletPrefab = Instantiate(bulletPref, spawnPosition.transform.position + offSet , spawnPosition.transform.rotation);
            GameObject bulletPrefab1 = Instantiate(bulletPref, spawnPosition2.transform.position + offSet, spawnPosition.transform.rotation);
            GameObject bulletPrefab2 = Instantiate(bulletPref, spawnPosition3.transform.position + offSet, spawnPosition.transform.rotation);
            bulletPrefab.transform.parent = spawnPosition.transform;
            bulletPrefab1.transform.parent = spawnPosition2.transform;
            bulletPrefab2.transform.parent = spawnPosition3.transform;
            currentBulletAmount++;
        }

        
       
    }

   
}
