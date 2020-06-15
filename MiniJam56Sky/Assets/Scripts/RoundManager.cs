using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

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
