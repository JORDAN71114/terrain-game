
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyseeker : MonoBehaviour
{
    public Transform target; //the enemy's target
    public int moveSpeed = 5; //move speed
    private int rotationSpeed = 3; //the speed of the enemy turning
    private Transform myTransform; //current transform data of this enemy

    public void Awake()
    {
        myTransform = transform; //cache transform data for easy access/performance
    }

    // Start is called before the first frame update
    public void Start()
    {
        target = GameObject.FindWithTag("Player").transform; //target the player
        //GetComponent.<Animation>().Play("orcwalk");
    }

    // Update is called once per frame
    public void Update()
    {
        //rotate to look at the player
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
        myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
    }

    /*
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "deadly")
        {
            Destroy(gameObject);
            
        }

    }
    */

}
