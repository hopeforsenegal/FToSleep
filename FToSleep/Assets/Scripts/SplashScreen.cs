using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SplashScreen : MonoBehaviour
{
	private bool hasClicked = false;

	protected void Awake ()
	{
		Image[] fromImages = GetComponents<Image> ();
		foreach (Image t in fromImages) {
			if (MetagameController.GetNextSplashScreenBackground ()) {
				t.sprite = MetagameController.GetNextSplashScreenBackground ();
			}
		}
	}

	public void OnPointerClick (PointerEventData eventData)
	{
		if (!hasClicked) {
			string sceneToLoad = SceneToLoad ();
			Debug.Log ("TransitionOnClick" + sceneToLoad);
			SceneManager.LoadScene (sceneToLoad);
			hasClicked = true;
		} else {
			Debug.LogWarning ("TransitionOnClick Disabled for now");
		}
	}

	protected void Update ()
	{
		if (Input.GetButtonDown ("Fire1")) {
			Debug.Log ("Lets playf");
			string sceneToLoad = SceneToLoad ();
			SceneManager.LoadScene (sceneToLoad);
		}
	}

	private string SceneToLoad ()
	{
		string sceneToLoad = "";
		if (MetagameController.GetNextSceneToLoad () != null && MetagameController.GetNextSceneToLoad ().Length > 0) {
			sceneToLoad = MetagameController.GetNextSceneToLoad ();
		} else {
			sceneToLoad = "Start";
		}
		return sceneToLoad;
	}
}
