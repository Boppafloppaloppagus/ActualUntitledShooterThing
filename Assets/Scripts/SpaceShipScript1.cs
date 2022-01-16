using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Both player and enemy units inherit Monobehaviour through this script.
public class SpaceShipScript1 : MonoBehaviour
{
    public int speed;

    public static bool enemyDisabled;
    public static bool playerDisabled;

    public GameObject bullet;

    GameObject lastBulletFired;

    BulletScript lastFiredScript;
    BulletScript nodeObjectScript;

    bool notDone;
    GameObject headNode;
    GameObject checkNode;
    NodeMachine checkNodeScript;

    public void Start()
    {
        checkNode = Instantiate(bullet, this.gameObject.transform.position, Quaternion.Euler(this.gameObject.transform.eulerAngles));
        headNode = checkNode;
        checkNodeScript = headNode.GetComponent<NodeMachine>();
        nodeObjectScript = headNode.GetComponent<BulletScript>();
        nodeObjectScript.THENAMEOFMYGLORIOUSCREATOR = this.gameObject.tag;

        checkNode.SetActive(false);
    }
    /*public void shootBOOLLET()
    {
        lastBulletFired = Instantiate(bullet, this.gameObject.transform.position, Quaternion.Euler(this.gameObject.transform.eulerAngles));
        lastFiredScript = lastBulletFired.GetComponent<BulletScript>();
        lastFiredScript.THENAMEOFMYGLORIOUSCREATOR = this.gameObject.tag;
    }*/
    public void shootBOOLLET()
    {
        checkNode = headNode;
        checkNodeScript = checkNode.GetComponent<NodeMachine>();
        nodeObjectScript = checkNode.GetComponent<BulletScript>();
        notDone = true;
        while (notDone)
        {
            if (checkNode.activeInHierarchy || nodeObjectScript.THENAMEOFMYGLORIOUSCREATOR != this.gameObject.tag)
            {
                if (checkNodeScript.nextNode != null)
                {
                    checkNode = checkNodeScript.nextNode;
                    checkNodeScript = checkNode.GetComponent<NodeMachine>();
                    nodeObjectScript = checkNode.GetComponent<BulletScript>();
                }
                else
                {
                    checkNodeScript.nextNode = Instantiate(bullet, this.gameObject.transform.position, Quaternion.Euler(this.gameObject.transform.eulerAngles));
                    checkNode = checkNodeScript.nextNode;
                    checkNodeScript = checkNode.GetComponent<NodeMachine>();
                    nodeObjectScript = checkNode.GetComponent<BulletScript>();
                    nodeObjectScript.THENAMEOFMYGLORIOUSCREATOR = this.gameObject.tag;
                    checkNode.SetActive(false);
                }
            }
            else
            {
                checkNode.transform.position = new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                checkNode.transform.rotation = Quaternion.Euler(this.gameObject.transform.eulerAngles);
                nodeObjectScript.tTL = 0;
                checkNode.SetActive(true);
                notDone = false;
            }
        }
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
        if (this.gameObject.tag != "Player")
            enemyDisabled = true;
        else if (this.gameObject.tag == "Player")
            playerDisabled = true;
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
        if (other.gameObject.tag == "Lethal")
        {
            BulletScript checkForCreator = other.GetComponent<BulletScript>();
            if (checkForCreator.THENAMEOFMYGLORIOUSCREATOR != this.gameObject.tag)
            {
                other.gameObject.SetActive(false);
                deactivateShip();
            }
        }
    }

}
