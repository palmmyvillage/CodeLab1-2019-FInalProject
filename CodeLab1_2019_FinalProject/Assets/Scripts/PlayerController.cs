using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int rotateSpeed;
    public KeyCode rotateRight;
    public KeyCode rotateLeft;

    public KeyCode shootingCode;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotating();
        Shooting();
    }

    void Rotating()
    {
        if (transform.rotation.z >= -0.45f && transform.rotation.z <= 0.45f)
        {
            if (Input.GetKey(rotateRight))
                transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
            if (Input.GetKey(rotateLeft))
                transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime);
        }
        else
        {     
            if (transform.rotation.z < -0.45f)
                transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
            if (transform.rotation.z > 0.45f)
                transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime);
        }
    }

    void Shooting()
    {
        if (Input.GetKeyDown(shootingCode))
        {
            GameObject Bullet = Instantiate(Resources.Load("Prefabs/LoveBullet")) as GameObject;
            Bullet.transform.position = transform.position + transform.up;
            Bullet.transform.rotation = transform.rotation;
            Bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 300);
        }
    }
}
