using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeftRightSpaceship : MonoBehaviour
{

    public Transform leftBound, rightBound;

  

    //Reached side
    public bool reachedRight;

    //Float for movespeed
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


      

        if (reachedRight == false)
        {
            movingRight();
        }

        if (reachedRight == true)
        {
            movingLeft();
        }

    }

    private bool floatIsBetween(float a, float b, float val)
    {
        return (Mathf.Abs(a - b) < val);
    }

    private void movingRight()
    {


        Debug.Log("moving right");
        transform.position = Vector3.MoveTowards(transform.position, rightBound.position, Time.deltaTime * moveSpeed);


        if (floatIsBetween(transform.position.z, rightBound.position.z, 0.5f))
        {
            reachedRight = true;
        }



    }

    //Move to the left
    private void movingLeft()
    {


        Debug.Log("moving left");
        transform.position = Vector3.MoveTowards(transform.position, leftBound.position, Time.deltaTime * moveSpeed);



        if (floatIsBetween(transform.position.z, leftBound.position.z, 0.5f) )
        {
            reachedRight = false;
        }



    }






}
