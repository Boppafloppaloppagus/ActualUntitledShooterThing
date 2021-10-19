using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : SpaceShipScript1
{
    Vector3 sPos;
    Vector3 relativeMousePos;

    public float shotInterval;

    float angleFromPlayerOrigin;
    float shootTimer;

    Renderer yourFace;

    // Start is called before the first frame update
    //I needed some way to differentiate the player and enemy visually.
    void Start()
    {
        sPos = this.gameObject.transform.position;
        yourFace = this.gameObject.GetComponent<Renderer>();
        yourFace.material.SetColor("_Color",Color.green);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeVelocity(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);

        MouseInputRotation();
        
        if (Input.GetButton("Fire1"))
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= shotInterval)
            {
                shootBOOLLET();
                shootTimer = 0;
            }
        }
    }

    //I had said I would implement controller input first, I was lying, Kb/m is superior.
    void MouseInputRotation()
    {
        relativeMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.gameObject.transform.position;
        angleFromPlayerOrigin = Mathf.Atan2(relativeMousePos.y, relativeMousePos.x) * (180 / Mathf.PI);
        ChangeOrientation(angleFromPlayerOrigin);
    }
}
