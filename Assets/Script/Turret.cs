﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Turret : MonoBehaviour {

    public List<GameObject> enemys=new List<GameObject>();
    public GameObject bulletPrefab;
    public Transform bulletPosition;
    public Transform head;
    private float timer = 0;
    public int attackRateTime = 1;      //1秒攻击一次

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            enemys.Add(col.gameObject);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Enemy")
        {
            enemys.Remove(col.gameObject);
        }
    }

    void Start()
    {
        timer = attackRateTime;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (enemys.Count>0 && timer >= attackRateTime)
        {
            Attack();
            timer = 0 ;
        }
        if (enemys.Count > 0 && enemys[0] != null)
        {
            Vector3 targetPosition = enemys[0].transform.position;
            targetPosition.y = head.position.y;
            head.LookAt(targetPosition);
        }
    }

    void Attack()
    {
        if (enemys[0] == null)
        {
            UpdateEnemys();
        }
        if (enemys.Count > 0)
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab, bulletPosition.position, bulletPosition.rotation);
            bullet.GetComponent<Bullet>().SetTarget(enemys[0].transform);
        }
        else
        {
            timer = attackRateTime;
        }
           
    }

    void UpdateEnemys()
    {
        List<int> emptyIndex = new List<int>();
        for(int index = 0; index < enemys.Count; index++)
        {
            if (enemys[index] == null)
            {
                emptyIndex.Add(index);
            }
        }
        for(int i = emptyIndex.Count - 1; i >= 0; i--)
        {
            enemys.RemoveAt(emptyIndex[i]);
        }
    }

}
