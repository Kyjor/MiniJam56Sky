using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
<<<<<<< HEAD

    public class RoundManager : MonoBehaviour
    {
        public TextMeshProUGUI roundCounter;

        int people = 8;
        int helicopters = 0;
        int tanks = 0;

        private int enemyCount;
        private int currentRound = 1;
        private int lastWrittenRound;
        private float roundScalingMultiplier = 1.6f;

        private string path;
        private string jsonString;

        private bool roundActive = false;
        private bool inRound = false;

        private Rounds rounds;

        private static RoundManager m_Instance = null;
        public static RoundManager Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = (RoundManager)FindObjectOfType(typeof(RoundManager));
                    if (m_Instance == null)
                        m_Instance = (new GameObject("RoundManager")).AddComponent<RoundManager>();
                    DontDestroyOnLoad(m_Instance.gameObject);
                }
                return m_Instance;
            }
        }

        void Awake()
        {

        lastWrittenRound = 0;
            
        }

        // Update is called once per frame
        void Update()
        {
            if (this.roundActive)
            {
                this.roundActive = false;
                this.inRound = true;
                this.roundCounter.text = "Round: " + this.currentRound.ToString();

               

                if (currentRound > lastWrittenRound)
                {
                    float scaling = Mathf.Pow(roundScalingMultiplier, currentRound - lastWrittenRound);
                    people += 1; 
                    helicopters += 1;
                    tanks += 1;
                }
                else
                {
                    people += 1;
                    helicopters += 1;
                    tanks += 1;
                }

                SpawnManager.Instance.SetRound(people, helicopters, tanks);
                SpawnManager.Instance.SetSpawn(true);

                this.SetEnemies(people + helicopters + tanks);
            }
        }

        public void KillEnemy()
        {
            this.enemyCount--;
            if (this.enemyCount <= 0)
            {
                this.EndRound();
            }
        }

        public void StartRound()
        {
            this.roundActive = true;
        }

        public bool InRound()
        {
            return this.inRound;
        }

        private void EndRound()
        {
            this.currentRound++;

            // UI, sound updates

            SpawnManager.Instance.SetSpawn(false);
            GameManager.Instance.EndRound();
            this.inRound = false;
        }

        private void SetEnemies(int enemyCount)
        {
            this.enemyCount = enemyCount;
        }
    }
=======

public class RoundManager : MonoBehaviour
{
    public TextMeshProUGUI roundCounter;

    private int enemyCount;
    private int currentRound = 1;
    private int lastWrittenRound;
    private float roundScalingMultiplier = 1.6f;

    private string path;
    private string jsonString;

    private bool roundActive = false;
    private bool inRound = false;

    private Rounds rounds;

    private static RoundManager m_Instance = null;
    public static RoundManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = (RoundManager)FindObjectOfType(typeof(RoundManager));
                if (m_Instance == null)
                    m_Instance = (new GameObject("RoundManager")).AddComponent<RoundManager>();
                DontDestroyOnLoad(m_Instance.gameObject);
            }
            return m_Instance;
        }
    }
    
    void Awake()
    {
        path = Application.streamingAssetsPath + "/rounds.json";
        jsonString = File.ReadAllText(path);
        rounds = JsonUtility.FromJson<Rounds>(jsonString);
        this.lastWrittenRound = this.rounds.rounds.Length-1;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.roundActive)
        {
            this.roundActive = false;
            this.inRound = true;
            this.roundCounter.text = "Round: " + this.currentRound.ToString();

            int people;
            int helicopters;
            int tanks;

            if (currentRound > lastWrittenRound)
            {
                float scaling = Mathf.Pow(roundScalingMultiplier, currentRound - lastWrittenRound);
                people = (int)(this.rounds.rounds[lastWrittenRound].enemies[0] * scaling);
                helicopters = (int)(this.rounds.rounds[lastWrittenRound].enemies[1] * scaling);
                tanks = (int)(this.rounds.rounds[lastWrittenRound].enemies[2] * scaling);
            }
            else
            {
                people = this.rounds.rounds[currentRound-1].enemies[0];
                helicopters = this.rounds.rounds[currentRound-1].enemies[1];
                tanks = this.rounds.rounds[currentRound-1].enemies[2];
            }

            SpawnManager.Instance.SetRound(people, helicopters, tanks);
            SpawnManager.Instance.SetSpawn(true);

            this.SetEnemies(people + helicopters + tanks);
        }
    }

    public void KillEnemy()
    {
        this.enemyCount--;
        if (this.enemyCount <= 0)
        {
            this.EndRound();
        }
    }

    public void StartRound()
    {
        this.roundActive = true;
    }

    public bool InRound()
    {
        return this.inRound;
    }

    private void EndRound()
    {
        this.currentRound++;

        // UI, sound updates

        SpawnManager.Instance.SetSpawn(false);
        GameManager.Instance.EndRound();
        this.inRound = false;
    }

    private void SetEnemies(int enemyCount)
    {
        this.enemyCount = enemyCount;
    }
}
>>>>>>> master
