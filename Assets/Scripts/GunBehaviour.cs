using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
	[SerializeField] private Transform bulletSpawnPoint;
	[SerializeField] private float damage = 15;
	[Space]
    
	[SerializeField] private Transform parent;

	RaycastHit hit;

	private void Start()
	{
		parent = gameObject.GetComponentInParent<Transform>();
	}

	public void Shoot()
	{
		//Debug.Log("Shooting");

		Ray ray = new Ray(bulletSpawnPoint.position, bulletSpawnPoint.forward);

		float shotDistance = 100f;
		if(Physics.Raycast(ray, out hit, shotDistance))
		{

			if(hit.transform.tag == "Enemy")
			{
			    Debug.Log(hit.transform.name);
				//GameObject enemy = hit.transform.gameObject;
				//hit.transform.gameObject.GetComponent<EnemyBehaviour>().Health -= damage;
			}
		}
		Debug.DrawRay(ray.origin, ray.direction * shotDistance, Color.black, 1f);

			

		
	}

	
}
