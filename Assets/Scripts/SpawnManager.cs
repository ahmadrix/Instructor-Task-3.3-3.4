using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Ball1;
    public GameObject BulletPrefab;
    public GameObject Player;
    public Vector3 SpawnPosition;



    public float interval = 10;
    public float startDelay = 3;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("BallSpawning" , startDelay , interval);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(BulletPrefab , Player.transform.position + new Vector3(0 , 0 ,0) , BulletPrefab.transform.rotation);
        }

        
    }

    void BallSpawning()
    {
        SpawnPosition = new Vector3(7.5f , 8 , -3);

        Instantiate(Ball1 , SpawnPosition , Ball1.transform.rotation);
    }

}
