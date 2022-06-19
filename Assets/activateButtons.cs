using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateButtons : MonoBehaviour
{
    //Red buttons
    public List<GameObject> addedRedButtonsList;
    //Plus button
    public List<GameObject> plusButtonList;
    //Menu buttons
    public List<GameObject> menuButtonList;


    //GameObject direct references to the controller
    public List<GameObject> paintLinesList;
    //Gameobject for the border of the controller
    public GameObject controllerBorderColor;



    //List to store all pickable objects
    public List<GameObject> activateableObjsList;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        //When a pickable object is hit
        if(other.tag == "pickableObject")
        {
            

            addObjectToRunner(other.gameObject);

        }
        
        

    }


    //Move the pickable object to its correct spot
    private void addObjectToRunner(GameObject hitObj)
    {

        foreach(GameObject listObj in activateableObjsList)
        {

           

            
            //Decide the gameobject to be activated by checking for the name + "Target"
            if (hitObj.name + " Target" == listObj.name)
            {
                
                //If there is a flipping option on the pickable object
                if (hitObj.GetComponent<buttonFlip>() != null)
                {
                    hitObj.GetComponent<buttonFlip>().moveForward(listObj);


                    //Remove from the list and break
                    activateableObjsList.Remove(listObj);

                    break;
                }
                //If we don't need to flip anything, just activate the game object
                else
                {

                    listObj.SetActive(true);

                }
            }


           


        }

    }




}
