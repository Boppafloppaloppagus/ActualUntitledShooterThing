using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    GameObject dudeToDispense;

    public float intervalOfDude;

    float dudeTimer;
    float points;

    int dudeIndex;

    GameObject[] dudeRepository;
    GameObject[] oldDudeRepository;

    bool notDone;

    float score;
    // Start is called before the first frame update
    void Start()
    {
        dudeRepository = new GameObject[6];
        for (int i = 0; i < dudeRepository.Length; i++)
        {
            dudeRepository[i] = dudeRepository[dudeIndex] = Instantiate(enemy, new Vector3(15, Random.Range(-4, 4), 0), Quaternion.identity);
            dudeRepository[i].SetActive(false);
            Debug.Log(dudeRepository[i]);
        }
        Debug.Log(dudeRepository.Length);
    }

    // Update is called once per frame
    void Update()
    {
        TheFantasticDudeDispenser();
        if (SpaceShipScript1.enemyDisabled == true)
        {
            points+= 69420;
            SpaceShipScript1.enemyDisabled = false;
            Debug.Log(points);
        }
        if (SpaceShipScript1.playerDisabled == true)
        {
            SpaceShipScript1.enemyDisabled = false;
        }
    }

    void TheFantasticDudeDispenser()
    {
        
        dudeTimer += Time.deltaTime;

        if (dudeTimer >= intervalOfDude)
        {
            notDone = true;
            Debug.Log("loop actually started");
            while (notDone)
            {
                Debug.Log("looptime");
                if (dudeIndex == dudeRepository.Length)
                {
                    Debug.Log("This may crash, case not enough units");
                    oldDudeRepository = new GameObject[dudeRepository.Length];
                    for (int i = 0; i < dudeRepository.Length; i++)
                    {
                        oldDudeRepository[i] = dudeRepository[i];
                    }
                    dudeRepository = new GameObject[oldDudeRepository.Length + 1];
                    for (int i = 0; i < oldDudeRepository.Length; i++)
                    {
                        dudeRepository[i] = oldDudeRepository[i];
                    }
                }
                else if (dudeRepository[dudeIndex] == null)
                {
                    Debug.Log("Case, no unit stored");
                    dudeRepository[dudeIndex] = Instantiate(enemy, new Vector3(15, Random.Range(-4, 4), 0), Quaternion.identity);
                    dudeRepository[dudeIndex].SetActive(false);
                }
                else if (dudeRepository[dudeIndex].activeInHierarchy)
                {
                    Debug.Log("Case, no unused unit at this index." + dudeIndex);
                    dudeIndex++;
                    Debug.Log(dudeIndex);
                }

                else if (!dudeRepository[dudeIndex].activeInHierarchy)
                {
                    Debug.Log("case, enable dude." + dudeIndex);
                    dudeRepository[dudeIndex].SetActive(true);
                    Debug.Log("enabled");
                    dudeRepository[dudeIndex].transform.position = new Vector3(15, Random.Range(-4, 4), 0);
                    Debug.Log("destination set");
                    dudeTimer = 0;
                    Debug.Log("Timer reset");
                    dudeIndex = 0;
                    Debug.Log("index reset");
                    notDone = false;
                    Debug.Log("loop end");

                }
                
            }
        }
    }
}
