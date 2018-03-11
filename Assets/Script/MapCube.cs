using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour {
    [HideInInspector]
    public GameObject turretGo;     //保存当前cube身上的炮台
    [HideInInspector]
    public bool isUpgraded = false;
    public GameObject buildEffect;
    private Renderer renderer;
    private TurretData turretData;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void OnMouseEnter()
    {
        if (turretGo == null && EventSystem.current.IsPointerOverGameObject()==false)
        {
            renderer.material.color = Color.red;
        }
    }

    private void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }

    public void UpgradeTurret()
    {

    }

    public void DismanTleTurret()
    {

    }

    public void BuildTurret(TurretData turretData)
    {
        this.turretData = turretData;
        isUpgraded = false;
        turretGo=GameObject.Instantiate(turretData.TurretPerfab, transform.position, Quaternion.identity);
        GameObject effect= GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1);
    } 
}