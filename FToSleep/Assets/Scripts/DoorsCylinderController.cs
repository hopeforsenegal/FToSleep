using UnityEngine;
using System.Collections;

public class DoorsCylinderController : MonoBehaviour {

	private DoorsCylinder _cylinder;
	private DoorsPin[] _doorsPins;

	// Use this for initialization
	void Start () {
		_cylinder = GetComponentInChildren<DoorsCylinder>();
		_doorsPins = GetComponentsInChildren<DoorsPin>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftArrow) == true || Input.GetKeyDown(KeyCode.RightArrow) == true) {
			_cylinder.RotateCylinder ();
		}
		if (Input.GetKeyDown (KeyCode.Space) == true) {
			foreach (DoorsPin pin in _doorsPins) {
				if (_cylinder.IsInSolvedPosition ()) {
					pin.Insert ();
				} else {
					pin.Bounce ();
				}
			}
		}
	}

}
