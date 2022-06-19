using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonFlip : MonoBehaviour
{



    Rigidbody buttonRB;



    //Buttons assigned point to go to on the controller;
    public Transform buttonTransformController;

    // Start is called before the first frame update
    void Start()
    {

        buttonRB = this.GetComponent<Rigidbody>();



    }

    // Update is called once per frame
    void Update()
    {




    }


    public void moveForward(GameObject acitavedButton)
    {

        if (moveButtonRoutineStarted == false)
        {
           
            StartCoroutine(moveButtonRoutine(acitavedButton));
        }

    }


    //Coroutine to move object in given time
    private bool moveButtonRoutineStarted;

    private float moveButtonTimer = 1f;
    private float moveButtonCounter;

 

    private IEnumerator moveButtonRoutine(GameObject acitavedButton)
    {

       

        moveButtonRoutineStarted = true;

        Vector3 startPos = this.transform.position;

        //Set RB to kinematic to disable physics
        buttonRB.isKinematic = true;

        //buttonRB.constraints = RigidbodyConstraints.FreezePositionY;


        //Set vectors to work with
        Vector3 midPoint = new Vector3((buttonTransformController.position.x + startPos.x) / 2, startPos.y + 4f,
           (buttonTransformController.position.z + startPos.z) / 2);



       

        //WORK HERE LATER
        while (moveButtonCounter <= moveButtonTimer)
        {


            moveButtonCounter += Time.deltaTime;

            //Flip while moving
            this.transform.eulerAngles = Vector3.Lerp(Vector3.zero, new Vector3(1080f, 45f, 0f), moveButtonCounter / moveButtonTimer);

            Vector3 m1 = Vector3.Lerp(startPos, midPoint, moveButtonCounter / moveButtonTimer);
            Vector3 m2 = Vector3.Lerp(midPoint, buttonTransformController.transform.position, moveButtonCounter / moveButtonTimer);

            this.transform.position = Vector3.Lerp(m1, m2, moveButtonCounter / moveButtonTimer);

            //Go up while moving too

            yield return null;

        }



        //Activate the button
        acitavedButton.SetActive(true);
      




        moveButtonRoutineStarted = false;

        moveButtonCounter = 0f;

        //Disable this gameobject when its done
        this.gameObject.SetActive(false);


    }

   


}

   
