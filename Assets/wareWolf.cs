using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wareWolf : MonoBehaviour
{
    #region Public Variable
    public GameObject wolfPrab;
    public GameObject Pref;
    [HideInInspector]
    public string enemyTag = "Visitor";
    #endregion

    #region Designer Editor
    [Header("Designer Editor")]
    [Header("Visitor 1")]
    public int strongDamage;
    [Header("Visitor 2")]
    public int damage;
    [Header("Visitor 3")]
    public int WeakDamage;
    public float range; 
    public float speed;
    #endregion

    #region Private Variable
    private Transform target;
    private bool isD = true, isS = false;
    bool isDone;
    BuildingSpawn buildingSpawn;
    #endregion

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        buildingSpawn = FindObjectOfType<BuildingSpawn>();
    }

    void UpdateTarget()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            if (enemy.GetComponent<EnemyRyan>().health < 70)//a
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

    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            Damage(target);
            wolfPrab.SetActive(false);
            buildingSpawn.bulletLeft--;
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
            //Debug.Log("hit");


            if (isD == true)
            {
                if (enemy.transform.name == "Visitor 1(Clone)")
                {
                    e.TakeDamage(WeakDamage);
                }
                else if (enemy.transform.name == "Visitor 2(Clone)")
                {
                    e.TakeDamage(damage);
                }
                else if (enemy.transform.name == "Visitor 3(Clone)")
                {
                    e.TakeDamage(strongDamage);
                }
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
