using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : SpaceShipScript1
{
    public float tTL;
    public GameObject player;
    public Vector3 startPos;
    Vector3 rotation;
    Vector3 dPosToPlayer;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        dPosToPlayer = this.transform.position - player.transform.position;
        rotation = new Vector3(0,0,Mathf.Atan(dPosToPlayer.y / dPosToPlayer.x)) * Mathf.Rad2Deg;
        Debug.Log(Mathf.Atan(dPosToPlayer.y / dPosToPlayer.x) * Mathf.Rad2Deg);
        this.transform.eulerAngles = rotation;
        ChangeVelocity(0, -speed);

        if (timer >= tTL)
        {
            timer = 0;
            this.transform.position = startPos;
            this.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
