using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wareWolf : MonoBehaviour
{
    private Transform target;
    private bool isD = true, isS = false;
    public int damage;

    public GameObject wolfPrab;
    public string enemyTag = "Visitor";
    public float range;
    public float speed;

    BuildingSpawn buildingSpawn;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
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
        if (nearestEnemy != null && shortestDistance <= range)
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


        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            //HitTarget();
            Damage(target);
            Destroy(wolfPrab);
            BuildingSpawn.bulletLeft -= 1;
            Debug.Log("Building Spawn" + BuildingSpawn.bulletLeft);
            return;
        }

        wolfPrab.transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }
    public void Seek(Transform _target, bool _isDamage, bool _isSlow)
    {
        target = _target;
        isD = _isDamage;
        isS = _isSlow;

    }
    void Damage(Transform enemy)
    {
        EnemyRyan e = enemy.GetComponent<EnemyRyan>();

        if (e != null)
        {
            Debug.Log("hit");


            if (isD == true)
            {
                e.TakeDamage(damage);
            }
            if (isS == true)
            {
                e.BecomeSlowed();
            }
        }

    }

    [ExecuteInEditMode]
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, range);
    }
}
