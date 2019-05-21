using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiesStat : MonoBehaviour
{
    public float HPmax;
    private float HPcurrent;
    
    public GameObject HPbar;

    private NavMeshAgent agent;
    
    public float BulletDMG;
    public float MeleeDMG;

    public float coolDownTime;
    private float CoolDownTime;
    private bool isMelee;

    public float speed;

    public type myType;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        
        HPcurrent = HPmax;

        CoolDownTime = coolDownTime;

        //green
        if (myType == type.GreenEye)
        {
            InvokeRepeating("greenEye", 1.5f, 1.5f);
        }
        
        //red
        
        //blue
        if (myType == type.BlueThorn)
        {
            InvokeRepeating("blueThorn", 3f, 3f);
        }
        
        //purple
        
        //black
        if (myType == type.BlackSmile)
        {
            agent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
        }
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
        
        //isMeleeAttacked
        coolDown();
    }

    //basic function
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

        agent.isStopped = true;
        isMelee = true;
    }
    private void coolDown()
    {   
        if (isMelee == true)
        {
            CoolDownTime -= Time.deltaTime;

            if (CoolDownTime <= 0)
            {
                isMelee = false;
                agent.isStopped = false;
                CoolDownTime = coolDownTime;
            }
        }
    }
    
    //special Ability
    private void greenEye()
    {
        GameObject target = GameObject.Find("Player");
        Vector3 direction = (target.transform.position - transform.position).normalized;
        
        GameObject bullet = 
            Instantiate(Resources.Load("Prefabs/Enemies/GreenEyeBullet"), transform.position+(direction*1.5f), transform.rotation) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(direction*300);
    }

    private void blueThorn()
    {
        Vector3 direction1 = transform.forward;
        GameObject bullet01 = 
            Instantiate(Resources.Load("Prefabs/Enemies/BlueEyeBullet"), transform.position+(direction1*1.5f), transform.rotation) as GameObject;
        bullet01.GetComponent<Rigidbody>().AddForce(direction1*150);
        
        Vector3 direction2 = transform.forward+transform.right;
        GameObject bullet02 = 
            Instantiate(Resources.Load("Prefabs/Enemies/BlueEyeBullet"), transform.position+(direction2*1.5f), transform.rotation) as GameObject;
        bullet02.GetComponent<Rigidbody>().AddForce(direction2*150);
        
        Vector3 direction3 = transform.right;
        GameObject bullet03 = 
            Instantiate(Resources.Load("Prefabs/Enemies/BlueEyeBullet"), transform.position+(direction3*1.5f), transform.rotation) as GameObject;
        bullet03.GetComponent<Rigidbody>().AddForce(direction3*150);
        
        Vector3 direction4 = transform.right-transform.forward;
        GameObject bullet04 = 
            Instantiate(Resources.Load("Prefabs/Enemies/BlueEyeBullet"), transform.position+(direction4*1.5f), transform.rotation) as GameObject;
        bullet04.GetComponent<Rigidbody>().AddForce(direction4*150);
        
        Vector3 direction5 = -transform.forward;
        GameObject bullet05 = 
            Instantiate(Resources.Load("Prefabs/Enemies/BlueEyeBullet"), transform.position+(direction5*1.5f), transform.rotation) as GameObject;
        bullet05.GetComponent<Rigidbody>().AddForce(direction5*150);
        
        Vector3 direction6 = -transform.forward-transform.right;
        GameObject bullet06 = 
            Instantiate(Resources.Load("Prefabs/Enemies/BlueEyeBullet"), transform.position+(direction6*1.5f), transform.rotation) as GameObject;
        bullet06.GetComponent<Rigidbody>().AddForce(direction6*150);
        
        Vector3 direction7 = -transform.right;
        GameObject bullet07 = 
            Instantiate(Resources.Load("Prefabs/Enemies/BlueEyeBullet"), transform.position+(direction7*1.5f), transform.rotation) as GameObject;
        bullet07.GetComponent<Rigidbody>().AddForce(direction7*150);
        
        Vector3 direction8 = -transform.right + transform.forward;
        GameObject bullet08 = 
            Instantiate(Resources.Load("Prefabs/Enemies/BlueEyeBullet"), transform.position+(direction8*1.5f), transform.rotation) as GameObject;
        bullet08.GetComponent<Rigidbody>().AddForce(direction8*150);
    }
    
    public enum type
    {
        GreenEye,
        RedMouth,
        BlueThorn,
        PurpleHaze,
        BlackSmile
    }
}
