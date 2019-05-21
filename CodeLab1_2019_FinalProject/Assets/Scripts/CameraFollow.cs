using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject target;
    private Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        //set target as player
        findPlayer();
        
        //set how far camera will be from target pbject
        offset = new Vector3(0, 37,0 );
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + offset;
    }

    void findPlayer()
    {
        target = GameObject.Find("Player");
    }
}
