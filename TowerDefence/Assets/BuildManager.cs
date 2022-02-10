using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    /*
    public GameObject mageTurretPrefab;
    public GameObject ballistaPrefab;
    public GameObject flameTurretPrefab;
    */
    public GameObject buildParticle;

    private TurretBlueprint turretToBuild;

    private TileNode selected;

    public TurretUI turretUI;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one BuildManager");
            return;
        }
        instance = this;
    }

    public void SelectNode(TileNode tileNode)
    {
        if(selected == tileNode)
        {
            DeselectNode();
            return;
        }
        selected = tileNode;
        turretToBuild = null;
        turretUI.SetTarget(selected);
    }
    public void DeselectNode()
    {
        selected = null;
        turretUI.Hide();
    }
    public void SetTurrentToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }
    public bool CanBuild { get { return turretToBuild != null; } } //read only variable. If turrentTobuild is == null?
    public bool HasMoney { get { return PlayerStats.coin >= turretToBuild.cost; } }
    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
 
}
