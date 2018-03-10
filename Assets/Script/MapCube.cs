using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour {
    [HideInInspector]
    public GameObject turretGo;     //保存当前cube身上的炮台
    public GameObject buildEffect;
    private Renderer renderer;

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

    public void BuildTurret(GameObject turretPrefab)
    {
        turretGo=GameObject.Instantiate(turretPrefab, transform.position, Quaternion.identity);
        GameObject effect= GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1);
    } 
}