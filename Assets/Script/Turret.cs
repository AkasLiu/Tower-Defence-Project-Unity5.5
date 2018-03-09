using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public List<GameObject> enemys=new List<GameObject>();
    public GameObject bulletPrefab;
    public Transform bulletPosition;
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
            timer -= attackRateTime;
        }
        //Debug.Log("Time"+Time.deltaTime);
        Debug.Log(Time.time);
    }

    void Attack()
    {
        GameObject.Instantiate(bulletPrefab, bulletPosition.position, bulletPosition.rotation);
    }
}
