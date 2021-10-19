using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

	private Bullet mBullet;

	public Transform bulletPoint;

	public GameObject bulletObj;
	private void Awake()
	{
		mBullet = bulletObj.GetComponent<Bullet>();
	
	}


	public void Shoot()
	{
		var bullet = Instantiate(mBullet.transform, bulletPoint.position,bulletPoint.rotation);
		bullet.localScale = mBullet.transform.lossyScale;
		bullet.transform.SetParent(bulletPoint);
		bullet.gameObject.SetActive(true);

	}
}
