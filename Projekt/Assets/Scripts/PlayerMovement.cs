using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D c;
    //Wenn's public ist, kann man den Wert im Editor einstellen.
    public float speed = 10;
    public float jumpPower = 10;
    private bool wasJumping;


    //In Awake werden Referenzen gesetzt und Strukturen aufgebaut.
    //Erste Spiellogik wäre in Start().
	void Awake()
    {
        //Speichere die Referenzen auf deine hierfür relevanten Komponenten
        rb = GetComponent<Rigidbody2D>();
        c = GetComponent<CircleCollider2D>();
	}

    //Wird jeden Frame ausgeführt.
    void Update()
    {
        if(wasJumping && !Input.GetButton("Jump"))
        {
            wasJumping = false;
        }
    }

    //FixedUpdate findet im Schnitt immer genau 50 Mal pro Sekunde statt (einstellbar).
    //Ist also unabhängig von der Framerate, nicht so wie Update().
	void FixedUpdate()
    {
        //Input-Achsen einstellbar unter Edit/Project Settings/Input
        var input = Input.GetAxis("Horizontal");

        rb.AddTorque(-input * speed);

        if(!wasJumping && Input.GetButton("Jump"))
        {
            if(IsGrounded())
            {
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
            wasJumping = true;
        }
	}

    private bool IsGrounded()
    {
        var mask = ~LayerMask.NameToLayer("Player");
        //Hier findet ein impliziter bool-Cast des Ergebnisses statt, der über != null läuft.
        return Physics2D.CircleCast(transform.position, c.radius, -Vector2.up, 0.1f, mask);
    }
}
