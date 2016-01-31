using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class OnClickTransition : MonoBehaviour
{
	private bool hasClicked = false;
	public string sceneToLoad;

	public void OnPointerClick (PointerEventData eventData)
	{
		Debug.Log ("TransitionOnClick" + sceneToLoad);
		if (!hasClicked) {
			Debug.Log ("TransitionOnClick" + sceneToLoad);

			SceneManager.LoadScene(sceneToLoad);
			hasClicked = true;
		} else {
			Debug.LogWarning ("TransitionOnClick Disabled for now");
		}
	}
	protected void Update(){
		if (Input.GetButtonDown ("Fire1") || Input.GetButtonDown ("Jump")) {
			Debug.Log ("Lets playf");
			SceneManager.LoadScene(sceneToLoad);
		}
	}
}
