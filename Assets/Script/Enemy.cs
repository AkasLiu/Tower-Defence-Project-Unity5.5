using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float speed = 10;
    private Transform[] positions;
    private int index=0;
    public int hp = 150;
    private int totalHp;
    private Slider slider;
    public GameObject enemyExplosionEffectPrefab;

	// Use this for initialization
	void Start () {
        positions = WayPoints.positions;
        totalHp = hp;
        slider = GetComponentInChildren<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        //Debug.Log("Time" + Time.deltaTime);
    }

    void Move()
    {
        if (index > positions.Length - 1)
        {
            return;
        }
        transform.Translate((positions[index].position-transform.position).normalized*Time.deltaTime*speed);
        if(Vector3.Distance(positions[index].position,transform.position) < 0.2f)
        {
            index++;
        }
        if (index > positions.Length - 1)
        {
            ReachDestination();
        }
    }

     void ReachDestination()
    {
        GameObject.Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        EnemySpawner.CountEnemyAlive--;
    }

    public void TakeDamage(int damage)
    {
        //if (hp <= 0)
          //  return;
        hp -= damage;
        slider.value = (float)hp / totalHp;
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
        GameObject enemyExplosionEffect = GameObject.Instantiate(enemyExplosionEffectPrefab, transform.position, transform.rotation);
        Destroy(enemyExplosionEffect,1.5f);
        
    }

}
