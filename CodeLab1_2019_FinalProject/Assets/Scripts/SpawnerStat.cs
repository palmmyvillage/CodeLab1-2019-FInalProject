using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerStat : MonoBehaviour
{
    public float HPmax;
    private float HPcurrent;
    
    public GameObject HPbar;

    public float BulletDMG;
    public float MeleeDMG;
    
    // Start is called before the first frame update
    void Start()
    {
        HPcurrent = HPmax;
        
    }

    // Update is called once per frame
    void Update()
    {
        //scaleHP
        HPbar.transform.localScale =
            new Vector3((HPcurrent/HPmax)*1.9f,HPbar.transform.localScale.y, HPbar.transform.localScale.z);
        
        //death
        if (HPcurrent <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            HPcurrent -= BulletDMG;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Melee"))
        {
            HPcurrent -= MeleeDMG;
        }
    }
}
