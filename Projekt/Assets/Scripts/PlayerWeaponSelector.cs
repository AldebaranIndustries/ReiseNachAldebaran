using UnityEngine;
using System.Collections;

public class PlayerWeaponSelector : MonoBehaviour
{
    public static PlayerWeaponSelector instance { private set; get; }
    private const float speed = 1000;
    private RectTransform t;
    [System.NonSerialized]
    public Vector3 targetPosition;


	void Awake()
    {
        instance = this;
        t = GetComponent<RectTransform>();
	}

	void Update()
    {
        t.position = Vector3.MoveTowards(t.position, targetPosition, Time.deltaTime * speed);
	}
}
