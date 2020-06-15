using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public TextMeshProUGUI pointDisplay;

    private int points;

    private static PointManager m_Instance = null;
    public static PointManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = (PointManager)FindObjectOfType(typeof(PointManager));
                if (m_Instance == null)
                    m_Instance = (new GameObject("PointManager")).AddComponent<PointManager>();
                DontDestroyOnLoad(m_Instance.gameObject);
            }
            return m_Instance;
        }
    }

    void Update()
    {
        this.pointDisplay.text = points.ToString() + " points";
    }

    public bool SpendPoints(int points)
    {
        if (points > this.points)
            return false;

        this.points -= points;
        return true;
    }
}
