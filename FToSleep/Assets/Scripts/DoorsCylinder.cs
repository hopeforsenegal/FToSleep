using UnityEngine;
using System.Collections;

public class DoorsCylinder : MonoBehaviour {

	public float speed = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 v3 = new Vector3( Input.GetAxis( "Horizontal" ), 0.0f, 1.0f );
		Quaternion qTo = Quaternion.LookRotation( v3 );

		transform.rotation = Quaternion.Slerp( transform.rotation, qTo, speed * Time.deltaTime );
	}
}
