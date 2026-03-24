/****************************************************************************
* File Name: EnemySpawning.c
* Author: Michael Chiodo
* DigiPen Email: michael.chiodo@digipen.edu
* Course: Game Projects
*
* Description: Spawns enemies at a set y coordinate, with a random x coordinate.
* Must be adjusted when we have the actual y coordinate for the barricades.
*
****************************************************************************/

using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public float timer = 1f;
    private float countdown = 1f;
    private int randomInt;
    public GameObject enemyPrefab;
    public static float levelTimer = 50f;
    public static float levelCountdown = 0f;
    // Update is called once per frame
    void Update()
    {
        levelCountdown += Time.deltaTime;
        randomInt = Random.Range(-12, 12);
        if (countdown >= timer && levelCountdown < levelTimer)
        {
            //Instantiates a new enemy at a set y coordinate
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(randomInt, -5, 0), Quaternion.Euler(0, 0, 0));
            countdown = 0f;
        }
        else if (countdown < timer)
        {
            countdown += Time.deltaTime;
        }
    }
}
