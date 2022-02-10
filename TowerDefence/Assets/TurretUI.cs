using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUI : MonoBehaviour
{
    private TileNode target;
    public GameObject canvasUI;

    public void SetTarget(TileNode _target)
    {
        target = _target;
        Vector3 offset = new Vector3(0, 6.5f, 0);
        transform.position = target.GetBuildPosition()+ offset;
        canvasUI.SetActive(true);
    }
    public void Hide()
    {
        canvasUI.SetActive(false);
    }
    public void Dismantle()
    {
        target.DismantleTurret();
        BuildManager.instance.DeselectNode();
    }

}
