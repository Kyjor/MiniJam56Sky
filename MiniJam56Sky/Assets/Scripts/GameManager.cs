using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject betweenRoundPrompt;

    private bool readyToStart = true;

    private static GameManager m_Instance = null;
    public static GameManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = (GameManager)FindObjectOfType(typeof(GameManager));
                if (m_Instance == null)
                    m_Instance = (new GameObject("GameManager")).AddComponent<GameManager>();
                DontDestroyOnLoad(m_Instance.gameObject);
            }
            return m_Instance;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && readyToStart)
        {
            // start round
            readyToStart = false;
            betweenRoundPrompt.gameObject.SetActive(false);
            RoundManager.Instance.StartRound();
        }
    }

    public void EndRound()
    {
        betweenRoundPrompt.gameObject.SetActive(true);
        readyToStart = true;
    }
}
