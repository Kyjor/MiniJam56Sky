using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kickoff : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("EnemyMovement");
    }
}
