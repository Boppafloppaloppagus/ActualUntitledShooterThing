using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletScript : MonoBehaviour
{
    public string THENAMEOFMYGLORIOUSCREATOR;
    public float speed;

    Vector3 rotationDegrees;
    Vector3 forwardVector;
    Vector3 arbitraryPoint;
    float riseOverRun;
    public float tTL;

    // Update is called once per frame
    void Update()
    {
        this.transform.position += CalculateForwardVelocity();

        //This is essentially a hotfix.
        tTL += Time.deltaTime;
        if (tTL >= 3)
        {
            this.gameObject.SetActive(false);
        }
    }
    //Some trig that determines what 'forward' is relative to the object rotation in the worldspace.
    Vector3 CalculateForwardVelocity()
    {
        rotationDegrees = this.transform.eulerAngles;
        arbitraryPoint = new Vector3(Mathf.Cos(rotationDegrees.z/(180/Mathf.PI)), Mathf.Sin(rotationDegrees.z/(180 / Mathf.PI)), 0);
        forwardVector = arbitraryPoint * speed * Time.deltaTime;

        return forwardVector;
    }
}
