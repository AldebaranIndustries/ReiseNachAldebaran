using UnityEngine;
using System.Collections;

public class WeaponBanhammer : MonoBehaviour
{
    [SerializeField]
    private float startSpeed = 10;
    [SerializeField]
    private int collisionsLeft = 4;
    [SerializeField]
    private float aliveTime = 8;

	void Start()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, Random.insideUnitCircle);
        rigidbody2D.AddTorque(Random.value * 2, ForceMode2D.Impulse);

        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        var direction = (mousePosition - transform.position).normalized;
        rigidbody2D.AddForce(direction * startSpeed, ForceMode2D.Impulse);

        Destroy(gameObject, aliveTime);
	}

	void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("OnBanHammer", SendMessageOptions.DontRequireReceiver);

	    if(--collisionsLeft <= 0)
        {
            Destroy(gameObject);
        }
	}
}
