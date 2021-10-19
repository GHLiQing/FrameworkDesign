using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	public float moveSpeed = 5f;

	private Rigidbody2D mRigidbody2D;

	public float liveTime = 5f;
	private void Awake()
	{
		mRigidbody2D = GetComponent<Rigidbody2D>();

	}

	private void Start()
	{
		mRigidbody2D.velocity = Vector2.right * moveSpeed;


		StartCoroutine(Delay(liveTime));
	}


	IEnumerator Delay(float sc)
	{
		yield return new WaitForSeconds(sc);
		OnSelfOnDestroy();

	}

	private void OnSelfOnDestroy()
	{
		Destroy(gameObject);
	}


}
