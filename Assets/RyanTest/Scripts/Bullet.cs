using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    private bool isD = true, isS = false;

    public int damage = 20;

    public float speed = 70f;

    public void Seek(Transform _target, bool _isDamage, bool _isSlow)
    {
        target = _target;
        isD = _isDamage;
        isS = _isSlow;

    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    private void HitTarget()
    {
        Damage(target);
        
        Destroy(gameObject);       
    }

    void Damage(Transform enemy)
    {
        EnemyRyan e = enemy.GetComponent<EnemyRyan>();      

        if(e !=null)
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
}
