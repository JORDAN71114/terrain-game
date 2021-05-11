using UnityEngine;

using System.Collections;




public class EnemySpawn : MonoBehaviour
{

    public GameObject[] enemies; //variable for array of enemies

    public int amount;   //whole number for amount of total enemies

    private Vector3 spawnPoint;  //location for enemy spawn

    // Use this for initialization



    // Update is called once per frame

    void Update()

    {

        enemies = GameObject.FindGameObjectsWithTag("deadly"); //enemy is defined if an object is tagged deadly

        amount = enemies.Length; //the total number of enemies that are in the array

        if (amount <= 20) //if there is not 2 enemies alive in the game

        {

            InvokeRepeating("spawnEnemy", 1, 10f); //start the function for spawning an enemy

        }

    }

    void spawnEnemy() //function for spawning an enemy

    {

        spawnPoint.x = Random.Range(0, 750); //spawn them from x=0 to x=750

        spawnPoint.y = 50;        //spawn them at y=50

        spawnPoint.z = Random.Range(0, 750); //spawn them from z=0 to z=750




        Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Length)], spawnPoint, Quaternion.identity); //create an enemy at one point in our random spawn range

        CancelInvoke(); //cancel the command to continue spawning

    }

}
