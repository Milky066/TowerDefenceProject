using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileNode : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughtMoneyColor;
    [Header("Optional")]
    public GameObject turret;
    public Vector3 positionOffset;
    public TurretBlueprint turretBlueprint;

    private Renderer rend;
    private Color startColor;
    BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if(turret != null)
        {
            //Debug.Log("Can't build here");
            buildManager.SelectNode(this);
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        BuildTurret(buildManager.GetTurretToBuild());//Build turret on the tile node
    }
    public void BuildTurret (TurretBlueprint blueprint)
    {
        if (PlayerStats.coin < blueprint.cost)
        {
            Debug.Log("Not enought coin!");
            return;
        }
        GameObject _turret = (GameObject)Instantiate(blueprint.turretPrejab, transform.position, transform.rotation);
        turret = _turret;
        PlayerStats.coin -= blueprint.cost;
        GameObject tempParticle = (GameObject)Instantiate(buildManager.buildParticle, transform.position, buildManager.buildParticle.transform.rotation);
        Destroy(tempParticle, 1f);
        Debug.Log("Built! Coin left = " + PlayerStats.coin);
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    private void OnMouseEnter()
    {

        if (!buildManager.CanBuild)
        {
            return;
        }
        if(buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughtMoneyColor;
        }

    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    public void DismantleTurret()
    {
        Destroy(turret);

        turretBlueprint = null;
    }

}
