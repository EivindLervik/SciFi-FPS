using UnityEngine;
using System.Collections;

public class DestroyInPieces : MonoBehaviour {

	public GameObject debreeModel;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DestroyMe (Vector3 kraftpunkt, float kraft, float radius){
		GameObject debree = Instantiate(debreeModel, transform.position, Quaternion.identity) as GameObject;
		Rigidbody[] kropper = debree.GetComponentsInChildren<Rigidbody>();
		foreach(Rigidbody kropp in kropper){
			kropp.AddExplosionForce(kraft, kraftpunkt, radius);
		}
		Destroy (gameObject);
	}
}
