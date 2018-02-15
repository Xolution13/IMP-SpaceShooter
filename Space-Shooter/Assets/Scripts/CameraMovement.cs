using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    // Variables
    private AccelerometerMovement player;

    public float startSmoothness = 1.5f;
	public float endSmoothness = 0.3f;
    private float smoothness;

	public float height;

	private Vector3 velocity = Vector3.zero;
	
    private void Start()
    {
        player = FindObjectOfType<AccelerometerMovement>();
    }

	private void Update ()
    {
		Vector3 pos = new Vector3 ();
		pos.x = player.transform.position.x;
		pos.z = player.transform.position.z;
		pos.y = player.transform.position.y + height;

        // Change the smoothness after height has been reached for speed transition
        if (transform.position.y < height)
        {
            smoothness = startSmoothness;
        }
        else if (transform.position.y >= height)
        {
            smoothness = endSmoothness;
        }

        // Follow the player but stop at the border
        transform.position = Vector3.SmoothDamp(new Vector3(Mathf.Clamp(transform.position.x, -8, 8), transform.position.y, Mathf.Clamp(transform.position.z, -8, 8)), 
                                                new Vector3(Mathf.Clamp(pos.x, -8, 8), 
                                                pos.y, Mathf.Clamp(pos.z, -8, 8)), 
                                                ref velocity, smoothness);
    }
}
