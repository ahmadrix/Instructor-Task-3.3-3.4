using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator PlayerAnim;


    public float horizontalInput;


    public bool rightArrow = false;       //bools for left , right, up and down rotation
    public bool leftArrow = false;

    public ParticleSystem DirtParticle;
    public ParticleSystem SmokeParticle;


    // Start is called before the first frame update
    void Start()
    {
        PlayerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if(horizontalInput == 0)
        {
            DirtParticle.Stop();
        }

        else if(Input.GetKey(KeyCode.RightArrow))             //function checks if right arrow is pressed
        {
            leftArrow = false;
            rightArrow = true;

            // changing the angle to 90
            gameObject.transform.eulerAngles = new Vector3( gameObject.transform.eulerAngles.x,      
            90 , gameObject.transform.eulerAngles.z);

            DirtParticle.Play();
        }

        else if(Input.GetKey(KeyCode.LeftArrow))         //function checks if left arrow is pressed
        {
            leftArrow = true;
            rightArrow = false;

            // changing the angle to -90
            gameObject.transform.eulerAngles = new Vector3( gameObject.transform.eulerAngles.x,
            -90 , gameObject.transform.eulerAngles.z);

            DirtParticle.Play();
        }


        if(rightArrow)
        {
            PlayerAnim.SetFloat("Speed_f" , horizontalInput);
            transform.Translate(Vector3.forward * Time.deltaTime * horizontalInput * 5);

        }

        else if(leftArrow)
        {
            PlayerAnim.SetFloat("Speed_f" , -horizontalInput);

            transform.Translate(Vector3.back * Time.deltaTime * horizontalInput * 5);

        }
        

        if(transform.position.x > 17)
        {
            transform.position = new Vector3(15 , 0 , -3) ;
        }

        if(transform.position.x < -3)
        {
            transform.position = new Vector3(0 , 0 , -3);
        }
        
        Physics.IgnoreLayerCollision(6,6);

        if(GameManager.life < 0)
        {
            PlayerAnim.SetBool("Death_b" , true);
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ball1"))
        {
            GameManager.life--;
        }

        else if(collision.gameObject.CompareTag("Ball2"))
        {

            GameManager.life--;
        }

        else if(collision.gameObject.CompareTag("Ball3"))
        {

            GameManager.life--;
        }

        
    }
    
}
