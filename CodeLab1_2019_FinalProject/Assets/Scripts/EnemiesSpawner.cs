using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    
    public List<GameObject> enemiesList; //declared boxList
    public float spawnTime;

    public spawnType myType;
    public int[] possibleEnemies;
    
    // Start is called before the first frame update
    void Start()
    {
        enemiesList = new List<GameObject>(); //init boxList
        
        InvokeRepeating("Spawn", spawnTime, spawnTime); //this will keep calling enemies
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private GameObject getEnemies()
    {
        GameObject enemy = null;
        
        if (enemiesList.Count > 0) //Do we have any boxes to recycle?
        {
            //get a box out of the list and recycle it
            enemy = enemiesList[0];
            enemiesList.Remove(enemy);
            enemy.SetActive(true);
        }
        else  //No?
        {
            //make a new box
            int chosenOne = possibleEnemies[Random.Range(0, possibleEnemies.Length + 1)];
            enemy = 
                Instantiate(Resources.Load<GameObject>("Prefabs/Enemies/EnemiesNo." + chosenOne),transform.position+(transform.forward*2),transform.rotation); //init prefab from resources
        }

        return enemy;
    }

    private void Spawn()
    {
        getEnemies();
    }

    public enum spawnType
    {
        level1,
        level2,
        level3
    }
}
