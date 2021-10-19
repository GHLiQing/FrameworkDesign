using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger2DCheck : MonoBehaviour
{
	public int EnterCount = 0;

	public LayerMask TargetLayers;


	public bool Triggered
	{
		get
		{
			return EnterCount > 0;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (IsInLayerMask(collision.gameObject,TargetLayers))
		{
			EnterCount++;
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (IsInLayerMask(collision.gameObject, TargetLayers))
		{
			EnterCount--;
		}

	}


	bool IsInLayerMask(GameObject obj, LayerMask layerMask)
	{
		var objLayerMask = 1 << obj.layer;

		return (layerMask.value & objLayerMask) > 0;
	}
}
