using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private Bullet bulletShotPrefab;

    private Queue<Bullet> bulletShots = new Queue<Bullet>();

    public static BulletPool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

   /* private void OnEnable()// to change
    {
        AddShots(10);    
    }*/

    public Bullet GetBullet()
    {
        if(bulletShots.Count == 0)
        {
            AddShots(1);
        }
        return bulletShots.Dequeue();
    }



    private void AddShots(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Bullet bulletFired = Instantiate(bulletShotPrefab);
            bulletFired.gameObject.SetActive(false);
            bulletShots.Enqueue(bulletFired);
        }
    }

    public void ReturnToPool(Bullet bulletFired)
    {
        bulletFired.gameObject.SetActive(false);
        bulletShots.Enqueue(bulletFired);
    }
}
