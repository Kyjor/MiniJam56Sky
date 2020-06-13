using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    List<EnemyType> spawnOrder = new List<EnemyType>();

    private bool spawnEnemies = false;

    private float timeToSpawn = float.MinValue;
    public float timeBetweenSpawns;
    public float varationBetweenSpawns;

    private static SpawnManager m_Instance = null;
    public static SpawnManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = (SpawnManager)FindObjectOfType(typeof(SpawnManager));
                if (m_Instance == null)
                    m_Instance = (new GameObject("SpawnManager")).AddComponent<SpawnManager>();
                DontDestroyOnLoad(m_Instance.gameObject);
            }
            return m_Instance;
        }
    }

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

        // TODO: Read in data file to know spawn probabilities (needs done in round manager)
    }

    // Update is called once per frame
    void Update()
    {
        if (this.spawnEnemies && this.timeToSpawn <= Time.time)
        {
            Debug.Log("spawning");
            Debug.Log(this.timeToSpawn);
            Debug.Log(Time.time);

            EnemyType spawnType = IListExtensions.Pop(this.spawnOrder);
            if (this.spawnOrder.Count == 0) this.spawnEnemies = false;
            
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

            this.timeToSpawn = Time.time + Random.Range(this.timeBetweenSpawns-this.varationBetweenSpawns, 
                this.timeBetweenSpawns + this.varationBetweenSpawns);
        }
    }

    public void SetRound(int personCount, int helicopterCount, int tankCount)
    {
        this.spawnOrder.AddRange(Enumerable.Repeat(EnemyType.Person, personCount));
        this.spawnOrder.AddRange(Enumerable.Repeat(EnemyType.Helicopter, helicopterCount));
        this.spawnOrder.AddRange(Enumerable.Repeat(EnemyType.Tank, tankCount));

        IListExtensions.Shuffle(this.spawnOrder);
    }

    public void SetSpawn(bool spawn)
    {
        this.spawnEnemies = spawn;
    }
}
