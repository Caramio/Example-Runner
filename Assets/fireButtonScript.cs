using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //spaceship object
    public GameObject spaceship;
    public void fireMissileFromShip()
    {

        if (startedFireMissileRoutine == false)
        {
            StartCoroutine(fireMissileRoutine());
        }

        

    }


    //Cooldown on the attack
    private float cooldownTimer = 1f;
    private float cooldownCounter;

    //Bool to see if routine is going on
    private bool startedFireMissileRoutine;

    private IEnumerator fireMissileRoutine()
    {

        startedFireMissileRoutine = true;

        spaceship.GetComponent<spaceShipControls>().fireMissile();

        while (cooldownCounter <= cooldownTimer)
        {

            cooldownCounter += Time.deltaTime;

            yield return null;

        }

        cooldownCounter = 0f;

        startedFireMissileRoutine = false;

    }

}
