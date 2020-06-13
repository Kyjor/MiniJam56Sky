using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private int enemyCount;
    private int currentRound;

    private int p = 3;
    private int h = 1;
    private int t = 2;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            p *= 2;
            h *= 2;
            t *= 2;
            SpawnManager.Instance.SetRound(p, h, t);
            SpawnManager.Instance.SetSpawn(true);
            this.SetEnemies(p+h+t);
        }
    }

    public void SetEnemies(int enemyCount)
    {
        this.enemyCount = enemyCount;
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
        this.currentRound++;

        // UI, sound updates

        SpawnManager.Instance.SetSpawn(false);
    }
}
