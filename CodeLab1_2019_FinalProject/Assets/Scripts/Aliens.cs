using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aliens : MonoBehaviour
{
    public string alienType;

    public bool getDestroy = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            getDestroy = true; 
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (getDestroy == true)
        {
            if (other.gameObject.GetComponent<Aliens>() != null)
            {
                if (other.gameObject.GetComponent<Aliens>().alienType == alienType)
                {
                    other.gameObject.GetComponent<Aliens>().ChainDestroy();
                    selfDestroy();
                }
            }
            else
            {
                selfDestroy();
            }
        }
    }

    private void selfDestroy()
    {
        Destroy(transform.parent.gameObject);
    }
    
    public void ChainDestroy()
    {
        getDestroy = true;
    }
}
