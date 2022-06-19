using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    //Objects to follow
    public GameObject runnerCharacterObj;

    //TV object
    public GameObject TVObject;

    //Space Ship controllable by the player
    public GameObject playerShip;

    //Distance followed from
    public float XZDistanceController, YDistanceController;

    //Distance from TV
    public float XZDistanceTV, YDistanceTV;


    //Floats to determine zoom amount
    public static float zoomXZAmount;

    //Floats for screen resolution
    float screenWidth, screenHeight;
    //float for the ratio
    float screenZoomRatio;


    // Start is called before the first frame update
    void Start()
    {

        screenWidth = Screen.width;
        screenHeight = Screen.height;

        screenZoomRatio = screenWidth / screenHeight;



        

    }

    // Update is called once per frame
    void Update()
    {

        if (startedZoomRoutine == false)
        {
            followObject();
        }

    }


    private void followObject()
    {

       

        transform.position = new Vector3(runnerCharacterObj.transform.position.x + XZDistanceController / screenZoomRatio, runnerCharacterObj.transform.position.y + YDistanceController / screenZoomRatio,
            runnerCharacterObj.transform.position.z);

    }

    public void zoomInOnTV()
    {


        if(startedZoomRoutine == false)
        {
            StartCoroutine(zoomInRoutine());
        }

    }

    private float zoomTimer = 1f;
    private float zoomCounter;

    private bool startedZoomRoutine;

    //Once the zoom in is done, we will also activate the space ships controls
    private IEnumerator zoomInRoutine()
    {

        startedZoomRoutine = true;

        //Position
        Vector3 startPos = this.transform.position;

        Vector3 endPos = new Vector3(TVObject.transform.position.x + XZDistanceTV / screenZoomRatio, TVObject.transform.position.y + YDistanceTV / screenZoomRatio,
            TVObject.transform.position.z);


        //Rotation
        Vector3 startAngle = this.transform.eulerAngles;

        Vector3 endAngle = new Vector3(0f, 270f, 0f);

        

        while (zoomCounter <= zoomTimer)
        {

            zoomCounter += Time.deltaTime;

            this.transform.position = Vector3.Lerp(startPos, endPos, zoomCounter / zoomTimer);

            this.transform.eulerAngles = Vector3.Lerp(startAngle, endAngle, zoomCounter / zoomTimer);

            yield return null;
        }

        //Allow spaceship to move
        playerShip.GetComponent<spaceShipControls>().enabled = true;

    }
}
