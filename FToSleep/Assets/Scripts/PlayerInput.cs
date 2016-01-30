using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
	protected void Update ()
	{
		if (Input.GetButtonDown ("Up")) {
			Debug.Log ("UP was pressed", gameObject);
		} else if (Input.GetButtonDown ("Right")) {
			Debug.Log ("RIGHT was pressed", gameObject);
		} else if (Input.GetButtonDown ("Down")) {
			Debug.Log ("DOWN was pressed", gameObject);
		} else if (Input.GetButtonDown ("Left")) {
			Debug.Log ("LEFT was pressed", gameObject);
		}
	}
}
