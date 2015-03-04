using UnityEngine;
using System.Collections;

public class FtbCollide : MonoBehaviour
{
	[SerializeField]
	private int hitpoints = 4;	

	void OnBanHammer()
	{
		Debug.Log ("onbanhammer()");
		if(--hitpoints <= 0)
		{
			Destroy(gameObject);
		}
	}
}
