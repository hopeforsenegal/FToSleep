using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Positioner : MonoBehaviour
{
	protected void Awake ()
	{
		Debug.Log ("Im awake i swear!");
		MetagameController.PlayInsanitySound ();
		MetagameController.PositionYourPlayer ();
	}
}
