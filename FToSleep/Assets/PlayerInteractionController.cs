using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerInteractionController : MonoBehaviour {
    [SerializeField]
    private Camera m_PlayerCamera;

    [SerializeField]
    private LayerMask collisionMask;

    public Transform ViewTarget;

    void Update() {
        if ( Input.GetButtonDown("Fire1") ) {
            //TODO: Draw a ray to the object and check collision. If the collision has a interactables target. 
            //Load the scene associated with 
            FireRayToInteractable();
            Debug.Log("im firing my stuff");
        }
    }

    private void FireRayToInteractable() {
        Transform cameraTransform = m_PlayerCamera.transform;
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
        RaycastHit hit;
        bool hitInteractable = Physics.Raycast(ray, out hit, 10.0f, collisionMask);

        if (hitInteractable) {
            Debug.Log("I hit an interactable object");
        }

        Debug.DrawRay(ray.origin, ray.direction*10, Color.red, 100.0f);
    }

    static void AddSceneAdditive(Interactables target) {
        SceneManager.LoadScene(target.MiniGameName);
    }

}
