using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public Camera kamera;
	public float maxSkyteLengde;
	public float force = 300.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("ShootGun")){
			Shoot();
		}
	}

	public void Shoot(){
		RaycastHit hit;
		Ray ray = kamera.ScreenPointToRay(Input.mousePosition);
		
		if (Physics.Raycast(ray, out hit, maxSkyteLengde)) {
			Transform trans = hit.transform;
			if(trans.tag == "DestructableWall"){
				Vector3 explosionPos = trans.position;
				float radius = 20.0f;
				Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
				foreach(Collider collider in colliders){
					if(collider.tag == "DestructableWall"){
						collider.GetComponent<DestroyInPieces>().DestroyMe(hit.point, force, radius);
					}
				}

				trans.GetComponent<DestroyInPieces>().DestroyMe(hit.point, force, radius);
			}
			
		}
	}
}
