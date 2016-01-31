using UnityEngine;
using System.Collections;

public class Knight2D : MonoBehaviour
{
	public void GotTouched ()
	{
		Debug.Log ("GotTouched");
		transform.position -= transform.right * 10;
	}
}
