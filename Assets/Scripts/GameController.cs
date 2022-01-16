using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    GameObject headNode;
    GameObject checkNode;
    NodeMachine checkNodeScript;
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

        checkNode = Instantiate(enemy, new Vector3(15, Random.Range(-4, 4), 0), Quaternion.identity);
        checkNodeScript = checkNode.GetComponent<NodeMachine>();
        headNode = checkNode;

        /*dudeRepository = new GameObject[6];
        for (int i = 0; i < dudeRepository.Length; i++)
        {
            dudeRepository[i] = dudeRepository[dudeIndex] = Instantiate(enemy, new Vector3(15, Random.Range(-4, 4), 0), Quaternion.identity);
            dudeRepository[i].SetActive(false);
            Debug.Log(dudeRepository[i]);
        }
        Debug.Log(dudeRepository.Length);*/
    }

    // Update is called once per frame
    void Update()
    {
        TheFantasticDudeDispenser2();
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
            while (notDone)
            {
                if (dudeIndex == dudeRepository.Length)
                {
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
                    dudeRepository[dudeIndex] = Instantiate(enemy, new Vector3(15, Random.Range(-4, 4), 0), Quaternion.identity);
                    dudeRepository[dudeIndex].SetActive(false);
                }
                else if (dudeRepository[dudeIndex].activeInHierarchy)
                {
                    dudeIndex++;
                }

                else if (!dudeRepository[dudeIndex].activeInHierarchy)
                {
                    dudeRepository[dudeIndex].SetActive(true);
                    dudeRepository[dudeIndex].transform.position = new Vector3(15, Random.Range(-4, 4), 0);
                    dudeTimer = 0;
                    dudeIndex = 0;
                    notDone = false;

                }
                
            }
        }
    }

    void TheFantasticDudeDispenser2()
    {

        dudeTimer += Time.deltaTime;

        if (dudeTimer >= intervalOfDude)
        {
            checkNode = headNode;
            checkNodeScript = headNode.GetComponent<NodeMachine>();
            notDone = true;
            while (notDone)
            {
                if (checkNode.activeInHierarchy)
                {
                    if (checkNodeScript.nextNode != null)
                    {
                        checkNode = checkNodeScript.nextNode;
                        checkNodeScript = checkNode.GetComponent<NodeMachine>();
                    }
                    else
                    {
                        checkNodeScript.nextNode = Instantiate(enemy, new Vector3(15, Random.Range(-4, 4), 0), Quaternion.identity);
                        checkNode = checkNodeScript.nextNode;
                        checkNodeScript = checkNode.GetComponent<NodeMachine>();
                        checkNode.SetActive(false);
                    }
                }

                else
                {
                    checkNode.SetActive(true);
                    checkNode.transform.position = new Vector3(15, Random.Range(-4, 4), 0);
                    dudeTimer = 0;
                    dudeIndex = 0;
                    notDone = false;

                }

            }
        }
    }
}
