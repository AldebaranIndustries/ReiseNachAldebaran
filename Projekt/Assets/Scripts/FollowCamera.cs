using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;


    void Start()
    {
        if(!target)
        {
            target = GameObject.FindWithTag("Player").transform;
        }
    }

	void LateUpdate()
    {
        transform.position = target.position + offset;
	}
}
