using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveRunnerCharacter : MonoBehaviour
{


    private Rigidbody runnerRB;

    //Floats to determine normalized and use later
    private float normalizedX , normalizedZ;

    //Movement speed of the runner
    public float moveSpeed;



    public Transform screenMiddlePoint;


    float screenCenterX;


    //Test vars
    public GameObject raycastPlane;

    //Adjust the inital analog spot
    private Vector3 analogSpot;
    //Adjusted the analog spot or not
    private bool analogAdjusted;

    void Start()
    {
        //Assign the rigidbody
        runnerRB = this.GetComponent<Rigidbody>();

        
    }

 



    // Update is called once per frame
    void Update()
    {

        //Control with touchpad
        //touchControls();

        //Move with PC
        moveForPC();

        //Control with touchpad
        touchControl();



        //If key was released, go back to only moving straight
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {

            runnerRB.velocity = new Vector3(0f, 0f, 0f);
        }


        //moveRunners();
    }


    private void moveForPC()
    {
        if (Input.GetMouseButton(0))
        {


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (analogAdjusted == false)
            {
                analogSpot = ray.direction;
                analogAdjusted = true;
            }


            Debug.Log(ray.direction);

            if (ray.direction.z < analogSpot.z)
            {
                runnerRB.velocity = new Vector3(0, 0, -1).normalized * moveSpeed;
            }
            if (ray.direction.z > analogSpot.z)
            {
                runnerRB.velocity = new Vector3(0, 0, 1).normalized * moveSpeed;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {


            analogAdjusted = false;


            runnerRB.velocity = Vector3.zero;

        }
    }
    public Material colorTest;
    public GameObject runnerobj;
    public Material colorOriginal;
    private void touchControl()
    {

        if (Input.touchCount > 0)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            //Adjust analogs spot on the screen
            if (analogAdjusted == false)
            {
                analogSpot = ray.direction;
                analogAdjusted = true;
            }


            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary)
            {

                runnerobj.GetComponent<MeshRenderer>().material = colorTest;

                Ray movingRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

                if (movingRay.direction.z < analogSpot.z)
                {
                    runnerRB.velocity = new Vector3(0, 0, -1).normalized * moveSpeed;
                }
                if (movingRay.direction.z > analogSpot.z)
                {
                    runnerRB.velocity = new Vector3(0, 0, 1).normalized * moveSpeed;
                }

            }

            //Touch was ended
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {

                runnerobj.GetComponent<MeshRenderer>().material = colorOriginal;

                analogAdjusted = false;

                runnerRB.velocity = Vector3.zero;


            }



        }

    }


    

    private void moveRunner()
    {


        if (Input.GetKey(KeyCode.LeftArrow))
        {
           
            runnerRB.velocity = new Vector3(0, 0, -1).normalized * moveSpeed;
        }





        if (Input.GetKey(KeyCode.RightArrow))
        {

            runnerRB.velocity = new Vector3(0, 0, 1).normalized * moveSpeed;


        }

        


    }
}
