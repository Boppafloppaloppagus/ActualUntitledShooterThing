using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Both player and enemy units inherit Monobehaviour through this script.
public class SpaceShipScript1 : MonoBehaviour
{
    public int speed;

    public GameObject bullet;

    GameObject lastBulletFired;

    BulletScript lastFiredScript;

    Vector3 rotation;

    //Some pretty greedy bullets.
    public void shootBOOLLET()
    {
        lastBulletFired = Instantiate(bullet, this.gameObject.transform.position, Quaternion.Euler(this.gameObject.transform.eulerAngles));
        lastFiredScript = lastBulletFired.GetComponent<BulletScript>();
        lastFiredScript.THENAMEOFMYGLORIOUSCREATOR = this.gameObject.tag;
    }

    //Damn I wish I could read.
    public void ChangeVelocity(float speedX, float speedY)
    {
        Vector3 velocity = new Vector3(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);
        this.transform.position += velocity;
    }
    //Boom.
    public void deactivateShip()
    {
        this.gameObject.SetActive(false);
    }
    //To convert radians to degrees multiply by pi/180
    public void ChangeOrientation(float dEGREESNOTRADIANSYOUDOLT)
    {
        Vector3 orientation = new Vector3(0,0,dEGREESNOTRADIANSYOUDOLT);
        this.gameObject.transform.eulerAngles = orientation;
    }

    //This handles the bullet collisions, may add enemy collisions.
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        if (other.gameObject.tag == "Lethal")
        {
            BulletScript checkForCreator = other.GetComponent<BulletScript>();
            if (checkForCreator.THENAMEOFMYGLORIOUSCREATOR != this.gameObject.tag)
            {
                deactivateShip();
            }
        }
    }

}
