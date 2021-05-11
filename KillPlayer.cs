using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KillPlayer : MonoBehaviour
{
    public Slider healthBar;
    public float health = 10f;
    private float healthBurn = 1f;
    public int Respawn;
    
    // Start is called before the first frame update
    void Start()
    {
        //healthBar = GameObject.Find("health slider").GetComponent<Slider>(); 
        //healthBar.minValue = 0f; //minimum value for health is 0
        //healthBar.maxValue = health; //maximum value for health is what the health is, 10
        //healthBar.value = healthBar.maxValue; //healthbar starts at 10 health
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        HandleInput();
        if (health <= 0) //if we are at or less than 0 health
        {
            youlose(); //command for ending the level
        }
    }
    
    void OnCollisionEnter(Collision target) //if we collide with an enemy
    {
        if (target.gameObject.tag == "deadly") //if the player collides with an enemy tagged deadly
        {

            UpdateHealth(); //lower the health
            //StartCoroutine(Wait()); //wait to update again
                                      //SceneManager.LoadScene(Respawn); //switch to the dead screen

        }
        if (target.gameObject.tag == "bottom") //if the player collides with the death floor
        {
            SceneManager.LoadScene(Respawn); //switch to the dead screen
          
        }
    }
    void UpdateHealth ()
    {
        if (health > 1)
        {
            //if the health bar has life left..
            health -= healthBurn; //current value of health minus 2f
            healthBar.value = health;  //update the interface slider
            
        }
        else
        {
            youlose(); //command for ending the level
        }
    }
    void youlose()
    {
        health = 0; //set health to 0
        healthBar.value = health; //update the slider
        SceneManager.LoadScene(Respawn); //switch to the dead screen
    }
    IEnumerator Wait() //always look for when a projectile is spawned, death state
    {
        yield return new WaitForSeconds(1f); //wait for 1 seconds
    }
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("lvl_1");
        }
    }
}
