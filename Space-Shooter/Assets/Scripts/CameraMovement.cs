using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	// Variables
	public Transform player;

    public float startSmoothness = 1.5f;
	public float endSmoothness = 0.3f;
    private float smoothness;

	public float height;
    private float changeValue = 15;

	private Vector3 velocity = Vector3.zero;
	

	private void Update ()
    {
		Vector3 pos = new Vector3 ();
		pos.x = player.position.x;
		pos.z = player.position.z;
		pos.y = player.position.y + height;

        // Change the smoothness after height of changeValue has been reached for nice speed transition
        if (transform.position.y < height)
        {
            smoothness = startSmoothness;
        }
        else if (transform.position.y >= height)
        {
            smoothness = endSmoothness;
        }
		transform.position = Vector3.SmoothDamp (transform.position, pos, ref velocity, smoothness);
	}
}
