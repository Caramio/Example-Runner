using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickObject : MonoBehaviour
{
    

    


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "pickableItem")
        {

            GameObject pickableObj = other.gameObject;
           
        }

    }
}
