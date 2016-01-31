using UnityEngine;
using System.Collections;

public class DoorsCylinderSprite : MonoBehaviour {

	public void SetSortingOrder( int sortingOrder ) {
		SpriteRenderer sprite = GetComponent<SpriteRenderer> ();
		if (sprite) {
			sprite.sortingOrder = sortingOrder;
		}
	}

	// Use this for initialization
	void Start () {
		Vector3 angle = new Vector3 (0.0f, 0.0f, Random.Range (0.0f, 360.0f));
		Quaternion rotation = Quaternion.Euler (angle);
		transform.rotation = rotation;
	}

}
