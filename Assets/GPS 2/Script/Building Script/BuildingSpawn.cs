using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawn : MonoBehaviour
{
    #region Public Variable
    public GameObject spawnPosition;
    public GameObject spawnPosition2;
    public GameObject spawnPosition3;
    public GameObject bulletPref;
    public Animator building;
    #endregion

    #region Deginer Editor
    [Header ("Designer Editor")]
    public float spawnTime;
    public int maxBulletSpawn;
    public int bulletLeft = 3;
    public Vector3 offSet;
    #endregion

    #region Private Variable
    private int bulletSpawn;
    float currentTime;
    bool location1, location2, location3;
    bool hasSpawn;
    GameObject wolfBullet1, wolfBullet2, wolfBullet3;
    private List<GameObject> wolfs = new List<GameObject>();
    private bool spawnLocation1, spawnLocation2, spawnLocation3;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        bulletLeft = 0;
        location1 = true;
        location2 = true;
        location3 = true;
        spawnLocation1 = false;
        spawnLocation2 = false;
        spawnLocation3 = false;
        hasSpawn = false;
        currentTime = 0;
        
    }

    void LateUpdate()
    {
        if(hasSpawn == true)
        {
            if (!wolfBullet1.activeSelf == true)
            {
                spawnLocation1 = true;
            }
            if (!wolfBullet2.activeSelf == true)
            {
                spawnLocation2 = true;
            }
            if (!wolfBullet3.activeSelf == true)
            {
                spawnLocation3 = true;
            }
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
        if (bulletLeft >= maxBulletSpawn)
            return;
        bulletSpawn = maxBulletSpawn - bulletLeft;
        if (currentTime > 0)
        {
            currentTime = currentTime - (1 * Time.deltaTime);
            return;
        }    
        for (int i = 0; i < bulletSpawn; i++)
        {
            SpawnBullet();
            currentTime = spawnTime;
        }

    }

    void SpawnBullet()
    {
        if (location1 == true)
        {
            wolfBullet1 = Instantiate(bulletPref, spawnPosition.transform.position + offSet, spawnPosition.transform.rotation);
            wolfBullet1.transform.parent = spawnPosition.transform;
            location1 = false;
            wolfs.Add(wolfBullet1);
            bulletLeft++;

        }

          if (location2 == true)
        {
           wolfBullet2 = Instantiate(bulletPref, spawnPosition2.transform.position + offSet, spawnPosition.transform.rotation);
            wolfBullet2.transform.parent = spawnPosition2.transform;
            location2 = false;
            wolfs.Add(wolfBullet2);
            bulletLeft++;

        }

          if (location3 == true)
        {
            wolfBullet3 = Instantiate(bulletPref, spawnPosition3.transform.position + offSet, spawnPosition.transform.rotation);
            wolfBullet3.transform.parent = spawnPosition3.transform;
            location3 = false;
            wolfs.Add(wolfBullet3);
            bulletLeft++;
        }
        hasSpawn = true;

         if(spawnLocation1 == true)
        {
            wolfBullet1.transform.position = spawnPosition.transform.position;
            wolfBullet1.transform.rotation = spawnPosition.transform.rotation;
            wolfBullet1.SetActive(true);
            spawnLocation1 = false;
        }

        else if (spawnLocation2 == true)
        {
            wolfBullet2.transform.position = spawnPosition2.transform.position;
            wolfBullet2.transform.rotation = spawnPosition.transform.rotation;
            wolfBullet2.SetActive(true);
            spawnLocation2 = false;
        }

        else if (spawnLocation3 == true)
        {
            wolfBullet3.transform.position = spawnPosition3.transform.position;
            wolfBullet3.transform.rotation = spawnPosition.transform.rotation;
            wolfBullet3.SetActive(true);
            spawnLocation3 = false;
        }
    }
}
