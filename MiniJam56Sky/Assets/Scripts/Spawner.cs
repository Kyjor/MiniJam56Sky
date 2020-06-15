using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject target;
    public EnemyType type;

    public void Spawn(GameObject enemy)
    {
        EnemyMovement newEnemy = GameObject.Instantiate(enemy, this.transform.position, this.transform.rotation).GetComponent<EnemyMovement>();
        if (newEnemy != null && newEnemy.GetComponent<Enemy>().type != EnemyType.Helicopter)
        {
           // newEnemy.SetTarget(this.target.transform);
        }
    }
}
