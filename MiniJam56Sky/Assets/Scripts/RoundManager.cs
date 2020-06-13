using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class RoundManager : MonoBehaviour
{
    public TextMeshProUGUI roundCounter;

    private int enemyCount;
    private int currentRound = 1;

    private string path;
    private string jsonString;

    private bool roundActive = false;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            this.roundActive = true;
            this.roundCounter.text = this.currentRound.ToString();

            int people = this.rounds.rounds[currentRound-1].enemies[0];
            int helicopters = this.rounds.rounds[currentRound-1].enemies[1];
            int tanks = this.rounds.rounds[currentRound-1].enemies[2];

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

    private void EndRound()
    {
        this.roundActive = false;
        this.currentRound++;

        // UI, sound updates

        SpawnManager.Instance.SetSpawn(false);
    }

    private void SetEnemies(int enemyCount)
    {
        this.enemyCount = enemyCount;
    }
}