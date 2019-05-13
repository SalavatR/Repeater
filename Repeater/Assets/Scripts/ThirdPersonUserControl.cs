using System;
using Repeater.States;
using UnityEditorInternal;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(ThirdPersonCharacter))]
public class ThirdPersonUserControl : MonoBehaviour
{
    [HideInInspector]
    [SerializeField] private ThirdPersonCharacter m_Character;
    private Vector3 m_Move;
    private bool m_Jump;


    private void OnValidate()
    {
        m_Character = GetComponent<ThirdPersonCharacter>();
    }

    private void Update()
    {
        if (!m_Jump)
        {
            m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }
    }

    private void FixedUpdate()
    {
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");
        bool crouch = Input.GetKey(KeyCode.C);

        m_Move = v * Vector3.forward + h * Vector3.right;
        if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;

        MoveState state = new MoveState(m_Move, crouch, m_Jump);
        StatesHandler.Instance.AddStateUnique(state);

        m_Character.Move(m_Move, crouch, m_Jump);
        m_Jump = false;
    }
}