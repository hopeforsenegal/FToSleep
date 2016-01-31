using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
           
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool attack = false; // CrossPlatformInputManager.GetButtonDown("Fire1");
             float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, false, false);

            if(attack)
            {
                m_Character.Attack();
            }
        }
    }
}
