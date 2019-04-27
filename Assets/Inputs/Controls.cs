// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Input;
using UnityEngine.Experimental.Input.Utilities;

public class Controls : IInputActionCollection
{
    private InputActionAsset asset;
    public Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""PlayerControls"",
            ""id"": ""a26553c2-ed69-4513-a740-3a3983c48df9"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""id"": ""c3a051c4-9867-4b22-9f89-8fc659c65b3b"",
                    ""expectedControlLayout"": ""Button"",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                },
                {
                    ""name"": ""DashForward"",
                    ""id"": ""d9c112e2-e32f-4b7c-a3df-480ce893f98b"",
                    ""expectedControlLayout"": ""Button"",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5d2b04d9-8333-4429-86aa-2027094fc5fb"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""40537447-5680-4c87-87e6-9539fc20a668"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""ecb3dd2b-ee60-4d6e-8a63-9b4e23f66092"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DashForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerControls
        m_PlayerControls = asset.GetActionMap("PlayerControls");
        m_PlayerControls_Jump = m_PlayerControls.GetAction("Jump");
        m_PlayerControls_DashForward = m_PlayerControls.GetAction("DashForward");
    }
    ~Controls()
    {
        UnityEngine.Object.Destroy(asset);
    }
    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }
    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }
    public ReadOnlyArray<InputControlScheme> controlSchemes
    {
        get => asset.controlSchemes;
    }
    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }
    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    public void Enable()
    {
        asset.Enable();
    }
    public void Disable()
    {
        asset.Disable();
    }
    // PlayerControls
    private InputActionMap m_PlayerControls;
    private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
    private InputAction m_PlayerControls_Jump;
    private InputAction m_PlayerControls_DashForward;
    public struct PlayerControlsActions
    {
        private Controls m_Wrapper;
        public PlayerControlsActions(Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump { get { return m_Wrapper.m_PlayerControls_Jump; } }
        public InputAction @DashForward { get { return m_Wrapper.m_PlayerControls_DashForward; } }
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
            {
                Jump.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                Jump.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                Jump.cancelled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                DashForward.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnDashForward;
                DashForward.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnDashForward;
                DashForward.cancelled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnDashForward;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                Jump.started += instance.OnJump;
                Jump.performed += instance.OnJump;
                Jump.cancelled += instance.OnJump;
                DashForward.started += instance.OnDashForward;
                DashForward.performed += instance.OnDashForward;
                DashForward.cancelled += instance.OnDashForward;
            }
        }
    }
    public PlayerControlsActions @PlayerControls
    {
        get
        {
            return new PlayerControlsActions(this);
        }
    }
    public interface IPlayerControlsActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnDashForward(InputAction.CallbackContext context);
    }
}
