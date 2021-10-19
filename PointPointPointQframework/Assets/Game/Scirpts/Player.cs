using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework.GameDesign
{
	public class Player : MonoBehaviour
	{

		private Rigidbody2D rigidbody2;

		public float Speed = 3f;

		private float horizontral;

		private bool isJump = false;

		private Trigger2DCheck mTrigger2DCheck;

		private Gun mGun;
		private void Awake()
		{
			rigidbody2 = GetComponent<Rigidbody2D>();
			mTrigger2DCheck = transform.Find("Group").GetComponent<Trigger2DCheck>();
			mGun= transform.Find("Gun").GetComponent<Gun>();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				isJump = true;
			}
		}

		private void FixedUpdate()
		{
			horizontral = Input.GetAxis("Horizontal");

			rigidbody2.velocity = new Vector2(horizontral* Speed, rigidbody2.velocity.y);

			var grouded = mTrigger2DCheck.Triggered;
			if (isJump&& grouded)
			{
				isJump = false;
				rigidbody2.velocity = new Vector2(rigidbody2.velocity.x, 5);
			}
			if (Input.GetKeyDown(KeyCode.P))
			{
				mGun.Shoot();
			}
		}
	}

}
