using UnityEngine;
using System.Collections;

public class playermove : MonoBehaviour {

	public AudioClip jumpsound;
	public AudioClip leftrightsound;
	private AudioSource source;
	
	Vector3 position;
	bool jump;
	float speedmove=5;
	float speedjump=300;

	void Update () {

		source = GetComponent<AudioSource> ();

		if (Input.GetKey(KeyCode.LeftArrow)){ 
			position= transform.position+Vector3.left;
			this.gameObject.transform.position = Vector3.MoveTowards (transform.position, position, speedmove * Time.deltaTime);
			source.PlayOneShot(leftrightsound);

		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			position= transform.position+Vector3.right;
			this.gameObject.transform.position = Vector3.MoveTowards (transform.position, position, speedmove * Time.deltaTime);
			source.PlayOneShot(leftrightsound);

		}
		//if (!jump) {
		if (Input.GetKeyDown(KeyCode.Space)) {
			GetComponent<Rigidbody> ().velocity = Vector3.zero;
			GetComponent<Rigidbody> ().AddForce (Vector3.up * speedjump);
			source.PlayOneShot(jumpsound);

			}
		//}

	}

	void onCollisionEnter(Collision other){
		jump = false;
	}

	void onCollisionExit(Collision other){
		jump = true;
	}
}
