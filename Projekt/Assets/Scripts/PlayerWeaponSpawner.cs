using UnityEngine;
using System.Collections;

public class PlayerWeaponSpawner : MonoBehaviour
{
	void Awake()
    {
	
	}

	void Update()
    {
	    if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(PlayerWeapon.currentWeapon.projectile, transform.position, Quaternion.identity);
        }
	}
}
