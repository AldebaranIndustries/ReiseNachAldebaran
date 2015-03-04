using UnityEngine;
using System.Collections;

public class PlayerWeaponSpawner : MonoBehaviour
{
	
	[SerializeField]
	public float reloadSeconds = 1f;

	private float lastShot = 0f;


	void Awake()
    {
	
	}

	void Update()
    {
		lastShot += Time.deltaTime;
		if(lastShot > reloadSeconds && Input.GetButtonDown("Fire1"))
        {
			lastShot = 0;
            Instantiate(PlayerWeapon.currentWeapon.projectile, transform.position, Quaternion.identity);
        }
	}
}
