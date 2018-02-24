using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachChildrenAndDestroy : MonoBehaviour
{
    // Add this to a prefab with children
	private void Start ()
    {
        transform.DetachChildren();
        Destroy(gameObject);
	}
}
