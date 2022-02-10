using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    public TurretBlueprint mageTurret;
    public TurretBlueprint fireTurret;
    public TurretBlueprint ballista;


    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectBallita()
    {
        Debug.Log("Buy Ballista");
        buildManager.SetTurrentToBuild(ballista);
    }
    public void SelectFlameTurret()
    {
        Debug.Log("Buy Flame Tower");
        buildManager.SetTurrentToBuild(fireTurret);
    }
    public void SelectMageTurret()
    {
        Debug.Log("Buy Mage Tower");
        buildManager.SetTurrentToBuild(mageTurret);
    }

}
