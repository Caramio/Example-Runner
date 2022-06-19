using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlatform : MonoBehaviour
{

    Rigidbody platformRB;

    public static float platformMovespeed = 30f;


    void Start()
    {
        platformRB = this.GetComponent<Rigidbody>();


        platformRB.velocity = new Vector3(platformMovespeed, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
