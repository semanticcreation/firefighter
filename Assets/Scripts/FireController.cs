using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour {
	GameObject Fire;
	public GameObject Water;

	public void Start(){
		Fire = GameObject.Find("Fire");
	}

	public void DestroyWater(){
		Water.SetActive (false);
	}

	IEnumerator DestroyFire(){
		Water.SetActive (true);
		yield return  new WaitForSeconds(3);
		Destroy (Fire);

		yield return  new WaitForSeconds(1);

		DestroyWater ();
	}

	public void StopFire(){
		StartCoroutine (DestroyFire ());
	}
}
