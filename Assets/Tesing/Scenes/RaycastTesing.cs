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
       
        
        transform.Translate(speed * Time.deltaTime, 0, 0);
         Raycast();
            
                              
    }

    void Raycast()
    {
        RaycastHit backHit;
        RaycastHit leftHit;
        RaycastHit rightHit;
        RaycastHit forwardHit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * 1f /2, Color.red);
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 5f, Color.red); //(back of the object)
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1f/2, Color.red);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1f/2, Color.red);


        //trun left
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out forwardHit, 1f) && Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out rightHit, 1f))
        { 
            if (forwardHit.transform.CompareTag("Enemy") && rightHit.transform.CompareTag("Enemy"))
            {
                Debug.Log("turn left");
                rotation += turnLeft;
                transform.eulerAngles = new Vector3(0, rotation, 0);
                
            }
        }
        //turn right
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out forwardHit, 1f) && Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out leftHit, 1f))
        {
            if (forwardHit.transform.CompareTag("Enemy") && leftHit.transform.CompareTag("Enemy"))
            {
                Debug.Log("turn right");
                rotation += turnRight;
                transform.eulerAngles = new Vector3(0, rotation, 0);
                
            }


        }



        // right of the object
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out rightHit, 1f))
        {

            if (rightHit.transform.CompareTag("Enemy"))
            {
                //Debug.Log("Hit right");
               
            }


        }
        // front of the object
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out forwardHit, 1f))
        {
            if (forwardHit.transform.CompareTag("Enemy"))
            {
                //Debug.Log("Hit front");
                
            }


        }
        // left of the object
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out leftHit, 1f))
        {
            if (leftHit.transform.CompareTag("Enemy"))
            {
                //Debug.Log("Hit left");
                
            }


        }
    }
}
