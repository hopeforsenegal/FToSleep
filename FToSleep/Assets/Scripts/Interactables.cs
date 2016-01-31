using UnityEngine;
using System.Collections;

public class Interactables : MonoBehaviour {

    [SerializeField]
    private string m_SceneToLoad;

    public string MiniGameName {
        get
        {
            return m_SceneToLoad;
        }
    }


    void Awake() {

    }

}
