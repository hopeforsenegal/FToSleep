using UnityEngine;
using Image = UnityEngine.UI.Image;
using System.Collections;

public class DoorsOverlay : MonoBehaviour {

	public Image image;
	public float speed = 1.0f;

	private Color _color;

	// Use this for initialization
	void Start () {
		_color = Color.black;
	}

	// Update is called once per frame
	void Update () {
		image.color = Color.Lerp (image.color, _color, speed * Time.deltaTime);
	}

}
