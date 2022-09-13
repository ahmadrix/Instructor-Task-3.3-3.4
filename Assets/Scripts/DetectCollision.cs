using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public GameObject[] SmallPrefab;
    public GameObject CollisionBall1;
    public GameObject CollisionBall2;

    public AudioSource playerAudio;
    public AudioClip jumpSound;
    
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 10);

        if(transform.position.y > 10)
        {
            Destroy(gameObject);
        }

    }

     void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ball1"))
        {
            AudioSource.PlayClipAtPoint(jumpSound , gameObject.transform.position);

            Destroy(gameObject);
            Destroy(collision.gameObject);

            Instantiate(SmallPrefab[0] , transform.position + new Vector3 (0.8f , 0 ,0) , SmallPrefab[0].transform.rotation);
            Instantiate(SmallPrefab[0] , transform.position , SmallPrefab[0].transform.rotation);

            GameManager.score++;

            Instantiate(CollisionBall1 , transform.position + new Vector3(.4f , -.2f , 0) , CollisionBall1.transform.rotation);
            
        }

        if(collision.gameObject.CompareTag("Ball2"))
        {
            AudioSource.PlayClipAtPoint(jumpSound , gameObject.transform.position);

            Destroy(gameObject);
            Destroy(collision.gameObject);

            Instantiate(SmallPrefab[1] , transform.position + new Vector3 (0.5f , 0 ,0) , SmallPrefab[1].transform.rotation);
            Instantiate(SmallPrefab[1] , transform.position , SmallPrefab[1].transform.rotation);

            GameManager.score++;

            Instantiate(CollisionBall2, transform.position + new Vector3(.25f , -.1f , 0) , CollisionBall2.transform.rotation);

            
        }

        if(collision.gameObject.CompareTag("Ball3"))
        {
            AudioSource.PlayClipAtPoint(jumpSound , gameObject.transform.position);

            GameManager.score++;
            Destroy(gameObject);
            Destroy(collision.gameObject);


        }
        

    }

}
