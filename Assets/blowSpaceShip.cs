using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class blowSpaceShip : MonoBehaviour
{

    public TMPro.TextMeshProUGUI victoryText;

    public GameObject UIholder;

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
        if(other.tag == "missileObj")
        {
            other.gameObject.SetActive(false);

            if (UIholder != null && victoryText != null)
            {

                UIholder.SetActive(true);

                if (this.gameObject.name == "Alien Ship 8X")
                {
                    victoryText.text = "You won \n" + "8X!";
                }
                if (this.gameObject.name == "Alien Ship 4X")
                {
                    victoryText.text = "You won \n" + "4X!";
                }
                if (this.gameObject.name == "Alien Ship 2X")
                {
                    victoryText.text = "You won \n" + "2X!";
                }

                //deactivate spaceship
                this.gameObject.SetActive(false);
            }

            //SceneManager.LoadScene(0);

            
        }

        
    }
}
