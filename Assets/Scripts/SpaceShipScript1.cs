using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipScript1 : MonoBehaviour
{
    public int speed;
    public GameObject bullet;
    public void shootBOOLLET()
    {
        Debug.Log("Pew Pew");
    }
    public void ChangeVelocity(float speedX, float speedY)
    {
        Vector3 velocity = new Vector3(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);
        this.transform.position += velocity;
    }

    public void deactivateShip()
    {
        this.gameObject.SetActive(false);
    }
}
