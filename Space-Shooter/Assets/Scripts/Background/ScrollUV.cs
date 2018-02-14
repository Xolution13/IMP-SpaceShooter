using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {

        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.material;

        Vector2 offset = mat.GetTextureOffset("_MainTex");

        offset.x += Time.deltaTime;

        mat.mainTextureOffset = offset;

	}
}
