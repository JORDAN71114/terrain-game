using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProjectileShooter : MonoBehaviour
{
    private bool ihavegun; //checks to see if we have touched the gun
    public GameObject prefab; //the projectile that is being shot
    public GameObject Shooter; //the gun that we are shooting with
    public GameObject guntext; //the text after we pick up the gun
    public GameObject advicetext; //the text when the game starts
    // Use this for initialization
    void Start()
    {
        advicetext.SetActive(true); //we can see advice text
        guntext.SetActive(false); //we can't see gun text
        ihavegun = false; //we aren't touching the gun at the start
        //prefab = Resources.Load("projectile") as GameObject; // finds the projectile in the Resources folder and assigns the name prefab
    }

    // Update is called once per frame
    void Update()
    {
     if(ihavegun == true) //if we touch the gun
        {
            ineedgun(); //we can fire bullets
        }
    }
    /*
    void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "bottom")
        {
            Destroy(gameObject);
        }

    }
    */
    void ineedgun() //shooting projectiles
    {
        if (Input.GetMouseButtonDown(0)) //if the left click is being pressed on the mouse
        { 
            GameObject projectile = Instantiate(prefab) as GameObject; //create the gameobject projectile
                                                                      
            projectile.transform.position = transform.position + Camera.main.transform.forward * 2; //set the projectile position to appear at the player's position where the player is looking and add a bit to get the bullet in front of the view

            Rigidbody rb = projectile.GetComponent<Rigidbody>(); //to make it go forward assign a simple name rb to the rigidbody of the projectile

            rb.velocity = Camera.main.transform.forward * 50; //set the velocity in the direction the player is looking at whatever factor you want. In this case 40.
        }
    }

   void OnTriggerEnter(Collider target) //if we collide with something
    {
        if (target.gameObject.CompareTag("gun")) //if we touch the gun
        {
            advicetext.SetActive(false); //we can't see advice text
            ihavegun = true; //ihavegun = true
            Object.Destroy(Shooter); //destroys the gun
            guntext.SetActive(true); //we can see the guntext

        }
    }
}