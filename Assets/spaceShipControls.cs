using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceShipControls : MonoBehaviour
{

    //speed to move left and right
    public float moveSpeed;
    //fired missile movespeed
    public float missileSpeed;


    //Missile to fire
    public GameObject firedMissile;
    //Fire Point
    public Transform firePoint;


    //Left and Right boundaries
    public Transform leftBound, rightBound;



    private bool analogAdjusted;
    private Vector3 analogSpot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        touchControl();


        //PCcontrols();


    }

    private void PCcontrols()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * moveSpeed);
        }

    }

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

               

                Ray movingRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

               

                if (movingRay.direction.z < analogSpot.z && transform.position.z > leftBound.position.z)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Time.deltaTime * moveSpeed);
                }
                if (movingRay.direction.z > analogSpot.z && transform.position.z < rightBound.position.z)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * moveSpeed);
                }

            }

            //Touch was ended
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {

                analogAdjusted = false;

            }



        }

    }




    private void touchControls()
    {

        if (Input.touchCount > 0)
        {

            //Touched and started to move to a direciton
            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary)
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    // Gets a vector that points from the player's position to the target's.
                    var heading = hit.point - ray.origin;
                    var distance = heading.magnitude;
                    var direction = heading / distance; // This is now the normalized direction.



                    Debug.DrawRay(ray.origin, direction * distance, Color.red);



                    if (heading.z < 0 && transform.position.z > leftBound.position.z)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Time.deltaTime * moveSpeed);
                    }
                    if (heading.z > 0 && transform.position.z < rightBound.position.z)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * moveSpeed);
                    }
                }

            }

        }

      



    }


    public void fireMissile()
    {

        GameObject missileObj = Instantiate(firedMissile, firePoint.position, firedMissile.transform.rotation);

        //give it a velocity
        missileObj.GetComponent<Rigidbody>().velocity = new Vector3(0f, missileSpeed, 0f);

        

    }

   

   
}
