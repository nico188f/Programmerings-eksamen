using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoundController : MonoBehaviour
{

    public GameObject enemyPrefab;

    public float timeBetweenWaves;
    public float timeBeforeRoundStart;
    public float timeVariable;

    public bool isRoundGoing;
    public bool isIntermission;
    public bool isStartOfRound;

    public int round;

    private void Start()
    {
        isRoundGoing = false;
        isIntermission = false;
        isStartOfRound = true;

        timeVariable = Time.time + timeBeforeRoundStart;

        round = 1;
    }

    private void spawnEnemies()
    {
        StartCoroutine("ISpawnEnemies");
    }

    IEnumerator ISPawnEnemies()
    {
        for (int i = 0; i < round; i++)
        {
            //GameObject newEnemy = Instantiate(enemyPrefab, MapGenerator.startTile.transform.postion, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
    private void Update()
    {
        if (isStartOfRound)
        {
            if (Time.time >= timeVariable)
            {
                isStartOfRound = false;
                isRoundGoing = true;
            }
        }
        else if (isIntermission)
        {
            if (Time.time >= timeVariable)
            {
                isIntermission = false;
                isRoundGoing = true;
            }
        }
        else if (isRoundGoing)
        {
            if (1>2)
            {

            } //Skal tjekke hvor mange "enemies" tilbage
            else
            {
                isIntermission = true;
                isRoundGoing = false;

                timeVariable = Time.time + timeBetweenWaves;
                round++;
            }
        }
    }
}
