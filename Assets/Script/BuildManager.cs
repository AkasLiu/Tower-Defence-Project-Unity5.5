using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour{

    public TurretData laserTurretData;
    public TurretData missileTurretData;
    public TurretData standardTurretdata;

    //当前选择的炮台(要建造的炮台)
    private TurretData selectTurretData;
    //游戏场景中选择的炮台
    private MapCube selectMapCube;

    private Animator upgradeCanvasAnimator;

    public Text moneyText;
    public Animator moneyAnimator;
    private int money=1000;
    public GameObject upgradeCanvas;
    public Button buttonUpgrade;

    void ChangeMoney(int change = 0)
    {
        money += change;
        moneyText.text = "￥" + money;
    }

    private void Start()
    {
        upgradeCanvasAnimator = upgradeCanvas.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //当点击的不是UI时，进行UI炮台的建设
            if (EventSystem.current.IsPointerOverGameObject()==false)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//发出一条以摄像机位置为起点，并且穿过鼠标按下的点的 坐标 的射线
                RaycastHit hit;
                bool isCollider=Physics.Raycast(ray,out hit, 1000, LayerMask.GetMask("MapCube"));    
                if (isCollider)
                {
                    MapCube mapCube = hit.collider.GetComponent<MapCube>();
                    if (selectTurretData != null && mapCube.turretGo == null)
                    {
                        //可以创建
                        if (money > selectTurretData.cost)
                        {
                            mapCube.BuildTurret(selectTurretData);
                            //HideUpgradeUI();
                            ChangeMoney(-selectTurretData.cost);
                        }
                        else
                        {
                            //TODO 提示钱不够
                            moneyAnimator.SetTrigger("Flicker");
                        }
                    }
                    else if(mapCube.turretGo != null)
                    {
                        // 升级处理
                        if (mapCube == selectMapCube && upgradeCanvas.activeInHierarchy)
                        {
                            StartCoroutine(HideUpgradeUI());
                        }
                        else
                        {
                            ShowUpgradeUI(mapCube.transform.position, mapCube.isUpgraded);
                        }
                        selectMapCube = mapCube;
                    }
                }
            }
        }    
    }

    public void OnLaserSelected(bool isOn)
    {
        if (isOn)
        {
            selectTurretData = laserTurretData;
        }
    }

    public void OnMissileSelected(bool isOn)
    {
        if (isOn)
        {
            selectTurretData = missileTurretData;
        }
    }

    public void OnStandardSelected(bool isOn)
    {
        if (isOn)
        {
            selectTurretData = standardTurretdata;
        }
    }

    void ShowUpgradeUI(Vector3 pos, bool isDisableUpgrade = false)
    {
        StopCoroutine("Hide");
        upgradeCanvas.SetActive(false);
        upgradeCanvas.SetActive(true);
        upgradeCanvas.transform.position = pos;
        buttonUpgrade.interactable = !isDisableUpgrade;
    }

    IEnumerator HideUpgradeUI()
    {
        upgradeCanvasAnimator.SetTrigger("Hide");
        yield return new WaitForSeconds(0.3f);
        upgradeCanvas.SetActive(false);
    }

    public void OnUpgradeButtonDown()
    {
        //TODO
        selectMapCube.UpgradeTurret();
        StartCoroutine(HideUpgradeUI());
    }

    public void OnDismantleButtonDown()
    {
        //TODO
        selectMapCube.DismanTleTurret();
        StartCoroutine(HideUpgradeUI());
    }

}
