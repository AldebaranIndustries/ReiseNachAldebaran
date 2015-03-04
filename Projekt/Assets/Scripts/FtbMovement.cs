using UnityEngine;
using System.Collections;

public class FtbMovement : MonoBehaviour
{
	private Rigidbody2D rb;
	//Wenn's public ist, kann man den Wert im Editor einstellen.
	public float speed = 10;
	
	//In Awake werden Referenzen gesetzt und Strukturen aufgebaut.
	//Erste Spiellogik wäre in Start().
	void Awake()
	{
		//Speichere die Referenzen auf deine hierfür relevanten Komponenten
		rb = GetComponent<Rigidbody2D>();
	}
	
	//FixedUpdate findet im Schnitt immer genau 50 Mal pro Sekunde statt (einstellbar).
	//Ist also unabhängig von der Framerate, nicht so wie Update().
	void FixedUpdate()
	{
		if (rb.position.x > -4f && rb.velocity.x <= 0) {
			rb.AddRelativeForce (Vector3.left * speed);
		}
		else if (transform.position.x < 4f && rb.velocity.x >= 0) {
			rb.AddRelativeForce (Vector3.right * speed);
		}
	}
}

