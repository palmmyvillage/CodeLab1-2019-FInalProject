using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //set gravity to help stop object 
        Physics.gravity = 4 * Physics.gravity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            Application.Quit();

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene("TestScene");
    }
}
