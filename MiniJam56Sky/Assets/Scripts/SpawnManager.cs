using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // enemy prefabs
    public GameObject tank;
    public GameObject person;
    public GameObject helicopter;

    List<Spawner> tankSpawners = new List<Spawner>();
    List<Spawner> personSpawners = new List<Spawner>();
    List<Spawner> helicopterSpawners = new List<Spawner>();

    void Start()
    {
        // Grab all spawners and assign them to relevant group
        foreach (Spawner s in GetComponentsInChildren<Spawner>(false))
        {
            switch(s.type)
            {
                case EnemyType.Helicopter:
                    helicopterSpawners.Add(s);
                    break;
                case EnemyType.Person:
                    personSpawners.Add(s);
                    break;
                case EnemyType.Tank:
                    tankSpawners.Add(s);
                    break;
            }
        }

        // TODO: Read in data file to know spawn probabilities
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: remove space trigger for a time based trigger
        if (Input.GetKeyDown("space"))
        {

            // TODO: use round-based probabilities
            EnemyType spawnType = (EnemyType)Random.Range(0,3);
            int spawner = 0;

            switch (spawnType)
            {
                case EnemyType.Helicopter:
                    spawner = Random.Range(0, helicopterSpawners.Count);
                    helicopterSpawners[spawner].Spawn(this.helicopter);
                    break;
                case EnemyType.Person:
                    spawner = Random.Range(0, personSpawners.Count);
                    personSpawners[spawner].Spawn(this.person);
                    break;
                case EnemyType.Tank:
                    spawner = Random.Range(0, tankSpawners.Count);
                    tankSpawners[spawner].Spawn(this.tank);
                    break;
            }
        }
    }
}
