using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTesing : MonoBehaviour
{
    public float speed = 10f;
    public int turnLeft = -90;
    public int turnRight = 90;
    public int rotation;

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {       
        Raycast();
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void Raycast()
    {
        RaycastHit backHit;
        RaycastHit leftHit;
        RaycastHit rightHit;
        RaycastHit forwardHit;
        //Debug.DrawRay(transform.position + Vector3.down/2 , transform.TransformDirection(Vector3.back) * 0.1f, Color.red); //down
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 5f, Color.red); //(back of the object)
        Debug.DrawRay(transform.position + Vector3.down/2 , transform.TransformDirection(Vector3.right) * 0.2f, Color.red); //front
        //Debug.DrawRay(transform.position + Vector3.down/2 , transform.TransformDirection(Vector3.forward) * 0.1f, Color.red);//up


        //straight
        if (Physics.Raycast(transform.position + Vector3.down / 2 , transform.TransformDirection(Vector3.right), out rightHit, 0.2f))
        { 
            if (rightHit.transform.CompareTag("EnemyTurnLeft"))
            {
                Debug.Log("turn left");
                rotation += turnLeft;
                transform.eulerAngles = new Vector3(0, rotation, 0);
            }

            else if (rightHit.transform.CompareTag("EnemyTurnRight"))
            {
                Debug.Log("turn right");
                rotation += turnRight;
                transform.eulerAngles = new Vector3(0, rotation, 0);
            }

            else if (rightHit.transform.CompareTag("Finish"))
            {
                Destroy(gameObject);
            }
        }

        

        //turn right
        /*
        else if (Physics.Raycast(transform.position + Vector3.down / 2, transform.TransformDirection(Vector3.forward), out forwardHit, 0.7f))
        {
            if (forwardHit.transform.CompareTag(TurnLeftPath))
            {
                Debug.Log("turn left");
                rotation += turnLeft;
                transform.eulerAngles = new Vector3(0, rotation, 0);
                
            }


        }



        // right of the object
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out rightHit, 2f))
        {

            if (rightHit.transform.CompareTag("Enemy"))
            {
                //Debug.Log("Hit right");
               
            }


        }
        // front of the object
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out forwardHit, 2f))
        {
            if (forwardHit.transform.CompareTag("Enemy"))
            {
                //Debug.Log("Hit front");
                
            }


        }
        // left of the object
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out leftHit, 2f))
        {
            if (leftHit.transform.CompareTag("Enemy"))
            {
                //Debug.Log("Hit left");
                
            }


        }*/
    }
}
