using UnityEngine;
using System.Collections;

public class DoorsSlot : MonoBehaviour {

	public void SetSortingOrder( int sortingOrder ) {
		SpriteRenderer sprite = GetComponent<SpriteRenderer> ();
		if (sprite) {
			sprite.sortingOrder = sortingOrder;
		}
	}

}
