using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class PlayerInteractionController : MonoBehaviour {
    [SerializeField]
    private Camera m_PlayerCamera;

    [SerializeField]
    private LayerMask collisionMask;

    public Animator m_PromptAnimator;

    static Interactables CurrentTarget;

    [SerializeField]
    private Animator m_cachedFaderAnimator;

    [SerializeField]
    private Text m_promptText;

	private string lastPromptPlayed;

    void Update() {
        if ( Input.GetButtonDown("Fire1") ) {
            FireRayToInteractable();
            Debug.Log("im firing my stuff");
        }
    }

	private void FireRayToInteractable ()
	{
		Transform cameraTransform = m_PlayerCamera.transform;
		Ray ray = new Ray (cameraTransform.position, cameraTransform.forward);
		RaycastHit hit;
		bool hitInteractable = Physics.Raycast (ray, out hit, 10.0f, collisionMask);

		if (hitInteractable) {
			CurrentTarget = hit.collider.GetComponentInParent<Interactables> ();
			if (!MetagameController.HasPlayedGame (CurrentTarget.MiniGameId)) {
				MetagameController.SetPlayedGame (CurrentTarget.MiniGameId);
                m_cachedFaderAnimator.SetBool("FadeOut", true);
            }
		}
	}

    public static void AddSceneAdditive() {
        if (CurrentTarget != null) {
			MetagameController.RecordPlayerPosition();
			MetagameController.SetNextSceneToLoad (CurrentTarget.MiniGameName);
			MetagameController.SetNextSplashScreenBackground (CurrentTarget.SplashBackground);
            CurrentTarget = null;
			SceneManager.LoadScene("SplashScreen");
        }
    }

    void OnTriggerEnter(Collider coll) {
        if ( coll.tag == "Interactables") {
            Interactables interact = coll.GetComponentInChildren<Interactables>();
            m_promptText.text = interact.PromptMessage;
            m_PromptAnimator.SetBool("HasPrompt", true);

			if (lastPromptPlayed != interact.MiniGameName) {
				AudioController.PlaySoundEffect (interact.PromptSound);
				lastPromptPlayed = interact.MiniGameName;
			}
        }
    }

    void OnTriggerExit(Collider coll) {
        if (coll.tag == "Interactables") {
            Interactables interact = coll.GetComponentInChildren<Interactables>();
            m_promptText.text = "";
            m_PromptAnimator.SetBool("HasPrompt", false);
        }
    }


}
