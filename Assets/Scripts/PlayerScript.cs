using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : SpaceShipScript1
{
    Vector3 sPos;
    Vector3 relativeMousePos;
    Vector3 inputAngle;

    float maxSpeed;

    public float shotInterval;

    float angleFromPlayerOrigin;
    float shootTimer;

    Renderer yourFace;

    // Start is called before the first frame update
    //I needed some way to differentiate the player and enemy visually.
    new void Start()
    {
        base.Start();
        sPos = this.gameObject.transform.position;
        yourFace = this.gameObject.GetComponent<Renderer>();
        yourFace.material.SetColor("_Color",Color.green);
        maxSpeed = this.speed;
    }

    // Update is called once per frame
    void Update()
    {
        IYamSpeed();
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
        if (Mathf.Abs(this.gameObject.transform.position.y) >= 4.5f)
        {
            if (this.gameObject.transform.position.y < 0)
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - (this.gameObject.transform.position.y + 4.5f), this.gameObject.transform.position.z);
            else
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - (this.gameObject.transform.position.y - 4.5f), this.gameObject.transform.position.z);
        }
        if (Mathf.Abs(this.gameObject.transform.position.x) >= 11.5f)
        {
            if (this.gameObject.transform.position.x < 0)
                this.gameObject.transform.position = new Vector3( this.gameObject.transform.position.x - (this.gameObject.transform.position.x + 11.5f), this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            else
                this.gameObject.transform.position = new Vector3( this.gameObject.transform.position.x - (this.gameObject.transform.position.x - 11.5f), this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }
    }

    //I had said I would implement controller input first, I was lying, Kb/m is superior.
    void MouseInputRotation()
    {
        relativeMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.gameObject.transform.position;
        angleFromPlayerOrigin = Mathf.Atan2(relativeMousePos.y, relativeMousePos.x) * (180 / Mathf.PI);
        ChangeOrientation(angleFromPlayerOrigin);
    }

    void IYamSpeed()
    {
        inputAngle = new Vector3(0,0,Mathf.Atan2(Input.GetAxis("Vertical"),Input.GetAxis("Horizontal")) * (180 / Mathf.PI));
        if (Mathf.Abs((Mathf.Abs(inputAngle.z) - Mathf.Abs(angleFromPlayerOrigin))) < 45)
            this.speed = (maxSpeed * ((90 - (Mathf.Abs(Mathf.Abs(inputAngle.z) - Mathf.Abs(angleFromPlayerOrigin))))/90));
        else
            this.speed = maxSpeed/2;
    } 
}
