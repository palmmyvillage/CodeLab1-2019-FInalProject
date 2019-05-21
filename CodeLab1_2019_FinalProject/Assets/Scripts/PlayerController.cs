using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private KeyCode upKey;
    private KeyCode downKey;
    private KeyCode rightKey;
    private KeyCode leftKey;

    private Rigidbody rb;

    public float HPmax;
    public float HPcurrent;
    public GameObject HPbar;
    
    public float forceAmount;// determine speed
    public float speedLimit;

    private SpriteRenderer dog;
	
    // Use this for initialization
    void Start ()
    {   
        //iniHP
        HPcurrent = HPmax;
        
        //get rigidbody
        rb = GetComponent<Rigidbody>();
        
        //determine key
        upKey = KeyCode.W;
        downKey = KeyCode.S;
        leftKey = KeyCode.A;
        rightKey = KeyCode.D;
        
        //get Dog
        dog = GameObject.Find("DogSprite").GetComponent<SpriteRenderer>();
    }
	
    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerRotation();
        FireTheBone();
        MeleeAttack();
        
        //scaleHP
        HPbar.transform.localScale =
            new Vector3((HPcurrent/HPmax)*1.9f,HPbar.transform.localScale.y, HPbar.transform.localScale.z);
        
        //death
        if (HPcurrent <= 0)
            Destroy(gameObject);
    }

    void PlayerMovement()
    {
        Vector3 newForce = new Vector3(0, 0,0 ); //renew this every frame so that force does not goes up by itself

        float xspeed = rb.velocity.x;
        float yspeed = rb.velocity.y;
        float zspeed = rb.velocity.z;
        
        //set if press button > move
        if (Input.GetKey(upKey))
        {
            newForce.z += forceAmount;
        }

        if (Input.GetKey(downKey))
        {
            newForce.z -= forceAmount;
        }

        if (Input.GetKey(leftKey))
        {
            newForce.x -= forceAmount;
        }

        if (Input.GetKey(rightKey))
        {
            newForce.x += forceAmount;
        }
        
        //set speedLimit to X
        if (xspeed >= speedLimit)
        {
            xspeed = speedLimit;
        }
        else if (xspeed <= -speedLimit)
        {
            xspeed = -speedLimit;
        }

        //set speedLimit to z
        if (zspeed >= speedLimit)
        {
            zspeed = speedLimit;
        }
        else if (zspeed <= -speedLimit)
        {
            zspeed = -speedLimit;
        }
        
        rb.velocity = new Vector3(xspeed,yspeed,zspeed);
        rb.AddForce(newForce); //add force to the object to move
    }

    void PlayerRotation()
    {
        Vector3 cameraPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePos = new Vector3(cameraPos.x,transform.position.y,cameraPos.z);

        transform.LookAt(mousePos);

        if (mousePos.x > 0)
        {
            dog.flipY = true;
        }
        else if (mousePos.x < 0)
        {
            dog.flipY = false;
        }
    }
    
    void FireTheBone()
    {        
        if (Input.GetMouseButtonDown(0))
        {
            GameObject BoneBullet 
                = Instantiate(Resources.Load("Prefabs/BoneBullet"), transform.position+(transform.forward*1.5f), transform.rotation) as GameObject;
            BoneBullet.GetComponent<Rigidbody>().AddForce(BoneBullet.transform.forward*1000);
        }
    }

    void MeleeAttack()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject MeleeAttack
                = Instantiate(Resources.Load("Prefabs/MeleeAttack"), transform.position+(transform.forward*2f), transform.rotation) as GameObject;
        }
    }
    
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemies"))
        {
            HPcurrent--;
        }
    }
}
