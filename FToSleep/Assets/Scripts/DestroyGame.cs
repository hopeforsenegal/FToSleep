using UnityEngine;
using System.Collections;

public class DestroyGame : MonoBehaviour
{
	void Awake ()
	{
		GameObject.Destroy (GameObject.Find ("MetagameController"));
	}

}
