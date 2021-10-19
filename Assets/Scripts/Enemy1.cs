using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : SpaceShipScript1
{
    public float tTL;
    public float shotRange;
    public float shotInterval;
    public float volleyInterval;

    float distanceToPlayer;
    float timer;
    float shootTimer;
    float volleyTimer;

    public GameObject player;

    Vector3 rotation;
    Vector3 dPosToPlayer;
    public Vector3 newStartPos;

   
    Renderer thisGuysFace;
    // Start is called before the first frame update
    //This causes the enemy to blush, because frankly you're kind of embarressing.
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        thisGuysFace = this.gameObject.GetComponent<Renderer>();
        thisGuysFace.material.SetColor("_Color", Color.red);
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeVelocity(-speed, 0);

        LookAtPlayer();

        timer += Time.deltaTime;
        if (timer >= tTL)
        {
            timer = 0;
            volleyTimer = 0;
            this.gameObject.SetActive(false);
        }
        if (Mathf.Abs(dPosToPlayer.x) <= shotRange || Mathf.Abs(dPosToPlayer.y) <= shotRange)
        {
            volleyTimer += Time.deltaTime;
            if (volleyTimer <= volleyInterval)
            {
                shootTimer += Time.deltaTime;
                if (shootTimer >= shotInterval)
                {
                    shootBOOLLET();
                    shootTimer = 0;
                }
            }
            
        }
    }

    public void LookAtPlayer()
    {
        try
        {
            dPosToPlayer = player.transform.position - this.transform.position;
            rotation = new Vector3(0, 0, Mathf.Atan2(dPosToPlayer.y, dPosToPlayer.x)) * (180 / Mathf.PI);
            this.transform.eulerAngles = rotation;
        }
        catch {
            //this is a temp notice to the compiler to stfu.
        }
    }
}
