﻿using UnityEngine;
using System.Collections;

public class DoorsCylinderController : MonoBehaviour {

	private DoorsCylinder _cylinder;
	private DoorsCylinderSprite _cylinderSprite;
	private DoorsPin[] _doorsPins;
	private DoorsSlot[] _doorsSlots;
	private bool _complete = false;

	public void SetSortingOrder( int sortingOrder ) {
		int cylinderSortingOrder = sortingOrder * 3 + 1;
		int doorsPinSortingOrder = sortingOrder * 3;
		int doorsSlotSortingOrder = sortingOrder * 3 + 2;

		_cylinderSprite.SetSortingOrder (cylinderSortingOrder);
		foreach (DoorsPin pin in _doorsPins) {
			pin.SetSortingOrder (doorsPinSortingOrder);
		}
		foreach (DoorsSlot slot in _doorsSlots) {
			slot.SetSortingOrder (doorsSlotSortingOrder);
		}
	}

	public void StartCylinderPuzzle () {
		gameObject.SetActive(true);
	}

	void Awake () {
		gameObject.SetActive (false);
		_cylinder = GetComponentInChildren<DoorsCylinder>();
		_cylinderSprite = GetComponentInChildren<DoorsCylinderSprite>();
		_doorsPins = GetComponentsInChildren<DoorsPin>();
		_doorsSlots = GetComponentsInChildren<DoorsSlot>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!_complete) {
			if (Input.GetKeyDown (KeyCode.LeftArrow) == true || Input.GetKeyDown (KeyCode.RightArrow) == true ||
				Input.GetKeyDown (KeyCode.A) == true || Input.GetKeyDown (KeyCode.D) == true) {
				_cylinder.RotateCylinder ();
			}
			if (Input.GetKeyDown (KeyCode.Space) == true) {
				foreach (DoorsPin pin in _doorsPins) {
					if (_cylinder.IsInSolvedPosition ()) {
						pin.Insert ();
						_complete = true;
					} else {
						pin.Bounce ();
					}
				}
				if (_complete) {
					DoorsManager.Instance.PlayLocked ();
					Invoke ("Complete", 1);
				} else {
					DoorsManager.Instance.PlayBounce ();
				}
			}
		}
	}

	void Complete () {
		DoorsManager.Instance.CylinderComplete ();
	}

}
