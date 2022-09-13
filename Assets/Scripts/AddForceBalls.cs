using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceBalls : MonoBehaviour
{
    private Rigidbody PlayerRb;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        PlayerRb.AddForce(Vector3.right * 0.2f , ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
