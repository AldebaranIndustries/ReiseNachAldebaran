using UnityEngine;
using System.Collections;

//[ExecuteInEditMode]
public class Parallax : MonoBehaviour
{
    public Vector2 parallax;
    public Vector2 offset;

	void OnWillRenderObject()
    {
        var camPos = Camera.current.transform.position;
        var z = transform.position.z;
        Vector3 newPos = offset + Vector2.Scale(parallax, camPos);
        newPos.z = z;
        transform.position = newPos;
	}
}
