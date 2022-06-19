using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleCamera : MonoBehaviour
{



    private float screenWidth, screenHeight;

    private float initialRatio;

    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        initialRatio = screenWidth / screenHeight;



      

        //transform.localScale = new Vector3(transform.localScale.x / initialRatio, transform.localScale.y / initialRatio, transform.localScale.z / initialRatio);

    }

    // Update is called once per frame
    void Update()
    {


      
    }


    private void adjustCameraScale()
    {



        



    }
}
