using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int damage = 50;

    public float speed = 20;

    public GameObject explosionEffectPrefab;

    private Transform target;

    //private float distanceArriveTarget = 1.2f;

    public void SetTarget(Transform _target)
    {
        this.target = _target;
    }

	// Update is called once per frame
	void Update () {

        if (target == null)
        {
            Destroy(this.gameObject);
            return;
        }

        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

      /*  Vector3 dir = target.position - transform.position;
        if (dir.magnitude < distanceArriveTarget)
        {
            target.GetComponent<Enemy>().TakeDamage(damage);
            GameObject explosionEffect = GameObject.Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
            Destroy(this.gameObject);
            Destroy(explosionEffect, 1);

        }
        */

	}

    private void OnTriggerEnter(Collider col)
    {
        //Debug.Log("进入"+col.gameObject.name+"  "+this.tag);
        if (col.tag == "Enemy")
        {
            col.GetComponent<Enemy>().TakeDamage(damage);
            GameObject explosionEffect= GameObject.Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
            Destroy(this.gameObject);
            Destroy(explosionEffect, 1);
        }
    }

}
