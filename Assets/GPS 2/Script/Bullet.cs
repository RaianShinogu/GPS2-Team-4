using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    private bool isD = true, isS = false;

    public int damage ;

    public float speed = 70f;
    public float explosionRadius = 0f;

    public Transform originPos;
    
    private void Awake()
    {
        
    }

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
            //HitTarget();
            Damage(target);
            Destroy(gameObject);
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        //transform.LookAt(target);
    }

    private void BulletEnqueue()
    {
        this.transform.position = this.originPos.position;
        this.gameObject.SetActive(false);

    }

    public void BulletActive() { if(this.gameObject.activeSelf == false)this.gameObject.SetActive(true); }

    private void HitTarget()
    {
        if(explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }


        //BulletEnqueue();
        //Destroy(gameObject);       
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Visitor")
            {
                Damage(collider.transform);
            }
        }
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
