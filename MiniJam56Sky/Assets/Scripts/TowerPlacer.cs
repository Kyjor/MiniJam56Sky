using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacer : MonoBehaviour
{
    public int AirTowerCost;
    public int GroundTowerCost;

    public GameObject AirTower;
    public GameObject GroundTower;

    public void BuyAirTower()
    {
        if (PointManager.Instance.SpendPoints(AirTowerCost))
        {
            Instantiate(AirTower);
        }
    }

    public void BuyGroundTower()
    {
        if (PointManager.Instance.SpendPoints(GroundTowerCost))
        {
            Instantiate(GroundTower);
        }
    }
}
