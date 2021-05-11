using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemycontroller : MonoBehaviour
{
    private Animator GetAnimator; //for using the animator
    public Transform target; //the enemy's target
    public int moveSpeed = 10; //move speed is 10
    private int rotationSpeed = 3; //the speed of the enemy turning is 3
    private Transform myTransform; //current transform data of this enemy
    public int counter; //counting how many bullets hit the enemy
    public GameObject guntext; //text after we pick up gun

    // Start is called before the first frame update
    public void Awake()
    {
        myTransform = transform; //cache transform data for easy access/performance
    }
    void Start()
    {

        target = GameObject.FindWithTag("Player").transform; //target the player
        GetAnimator = GetComponent<Animator>(); //setting the animator term to the animator tab
        GetAnimator.SetBool("ImAlive", true); //start game with enemy alive
        GetAnimator.SetBool("nearby", false); //start game with enemy not nearby


    }

    // Update is called once per frame
    void Update()
    {
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime); //how it moves pt1
        myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime; //how it moves pt2, sorry, even i have no idea how this works

        if (counter == 6) //if we hit an enemy 6 times
        {
            moveSpeed = 0; //move speed goes to 0
            rotationSpeed = 0; //rotation speed goes to 0
            GetAnimator.SetBool("ImAlive", false); //imalive switches to false if bullet touches them
            GetAnimator.Play("Monster_anim|Death 0");//plays the death animation
            StartCoroutine(Attack()); //start the death state
            guntext.SetActive(false); //we can no longer see the gun 
                                    
            

        }

    }

    





    void OnCollisionEnter(Collision target) //if we hit an enemy
    {
        if (target.gameObject.tag == "bullet") //if enemy touches a bullet
        {
     
            counter++; //add one to the counter
        }
    

        
        if (target.gameObject.tag == "bottom") //if enemy touches the kill florr
        {
            moveSpeed = 0; //move speed goes to 0
            rotationSpeed = 0; //rotation speed goes to 0
            GetAnimator.SetBool("ImAlive", false); //imalive switches to false if bottom touches them
            GetAnimator.Play("Monster_anim|Death 0"); //play the death animation
            Destroy(gameObject); //destroy the object
        }
    }
    void OnTriggerEnter(Collider target) //if we collide with a trigger box
    {
        if (target.gameObject.CompareTag("Player")) //if we enter the players range
        {
            
            moveSpeed = 5; //switch movement speed to 5
            //rotationSpeed = 0; //rotational speed goes to 0
            GetAnimator.SetBool("nearby", true); //switch nearby to true
            GetAnimator.Play("Monster_anim|Atack 0"); //play the attack animation
        }
       
    }
   void OnTriggerExit(Collider target) //if we touch a trigger box
    {
        if (target.gameObject.CompareTag("Player")) //if we leave the players range
        {
           
            moveSpeed = 10; //switch movement speed to 10
           GetAnimator.Play("Monster_anim|Run"); //play the run animation
            GetAnimator.SetBool("nearby", false); //switch nearby to false
        }
    }
    IEnumerator Attack() //always look for when a projectile is spawned, death state
    {
        yield return new WaitForSeconds(1f); //wait for 1.5 seconds
        Destroy(gameObject); //then destroy the game object
    }
}
