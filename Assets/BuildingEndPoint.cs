using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingEndPoint : MonoBehaviour
{
    RaycastHit leftHit;
    private string VerticalPath = "Vertical Path";
    private string HorizontalPath = "Horizontal Path";
    private string TurnLeftPath = "Turn Left";
    private string TurnRightPath = "Turn Right";
    private string InverseTurnRightPath = "Inverse Turn Right";
    private string InverseTurnLeftPath = "Inverse Turn Left";
    public GameObject nextStageButton;
    public GameObject gameManager;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position + Vector3.down/2, transform.TransformDirection(Vector3.left) * 1.3f, Color.red);

        if (Physics.Raycast(transform.position + Vector3.down / 2, transform.TransformDirection(Vector3.left), out leftHit, 1.3f) )
        {
            if (leftHit.transform.CompareTag(InverseTurnRightPath) || leftHit.transform.CompareTag(InverseTurnLeftPath) || leftHit.transform.CompareTag(VerticalPath))
            {
                NextStageButton();
            }
        }
    }

    void NextStageButton()
    {
        if(count == 0)
        {
            nextStageButton.SetActive(true);
            gameManager.GetComponent<tutorialManager>().startGame = 1;
            count++;
        }
        return;
        
    }
}
