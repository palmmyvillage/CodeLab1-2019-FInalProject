using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    private float timeLimit = 0.3f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLimit -= Time.deltaTime;

        if (timeLimit <= 0)
        {
            Destroy(gameObject);
        }
    }
}
