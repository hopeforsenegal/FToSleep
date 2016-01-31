using UnityEngine;
using System.Collections;

public class FadeEventController : MonoBehaviour {

    public void OnFadedOut() {
        PlayerInteractionController.AddSceneAdditive();
    }
}
