using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectilescript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(death()); //start the enumerator attack when projectile is spawned
    }
    void OnCollisionEnter(Collision target) //for when the projectile touches something else
    {

        if (target.gameObject.tag == "bottom") //if we come in contact with the death floor
        {
            Destroy(gameObject); //destroy the projectile
        }
        if (target.gameObject.tag == "deadly") //if we come in contact with an enemy
        {
            Destroy(gameObject); //destroy the projectile
        }
    }
    IEnumerator death() //always look for when a projectile is spawned
    {
        yield return new WaitForSeconds(1f); //wait for 1 second
        Destroy(gameObject); //then destroy the game object
    }
}
