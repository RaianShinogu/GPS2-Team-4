using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialGuy : MonoBehaviour
{
    public GameObject target;
    public GameObject tutorialGame;
    public GameObject guyWalking;
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        if(transform.position == target.transform.position)
        {
            tutorialGame.SetActive(true);
            guyWalking.SetActive(false);

        }
    }
}
