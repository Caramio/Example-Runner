using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endPointScript : MonoBehaviour
{

    public GameObject planeMovingObject;


    public Camera sceneCamera;


    public GameObject tvObject;


    //fire UI
    public GameObject fireUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "runnerCharacter")
        {
            planeMovingObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            planeMovingObject.GetComponent<movePlatform>().enabled = false;

            //Zoom in on the TV
            sceneCamera.GetComponent<cameraFollow>().zoomInOnTV();
            fireUI.SetActive(true);



        }


    }



}
