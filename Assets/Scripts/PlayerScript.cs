using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : SpaceShipScript1
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeVelocity(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);
        /*if (Input.GetButtonDown("Space"))
        {
            shootBOOLLET();
        }*/
    }
}
