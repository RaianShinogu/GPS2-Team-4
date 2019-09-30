using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;
   

    [Header("Unity Stuff")]
    public Image scareMeter;
    public float ScareMeter = 0;
    void Start()
    {
        target = WayPoint.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.04f)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        if (wavepointIndex >=WayPoint.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = WayPoint.points[wavepointIndex];
    }

    public void TakeDamage (float amount)
    {
        ScareMeter += amount;
        scareMeter.fillAmount = ScareMeter;
    }

    private void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            TakeDamage(0.5f);
        }
    }
}
