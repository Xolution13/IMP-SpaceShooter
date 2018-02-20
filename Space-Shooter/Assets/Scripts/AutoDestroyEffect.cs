using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class AutoDestroyEffect : MonoBehaviour
{	
	void OnEnable()
	{
		StartCoroutine(CheckIfAlive());
	}
	
	IEnumerator CheckIfAlive ()
	{
		while(true)
		{
			yield return new WaitForSeconds(0.5f);
			if(!GetComponent<ParticleSystem>().IsAlive(true))
			{
				GameObject.Destroy(this.gameObject);
				break;
			}
		}
	}
}
