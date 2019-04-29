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
                },
                {
                    ""name"": ""Exit"",
                    ""id"": ""d1ab1394-8880-4189-bb63-7741fdaca9a3"",
                    ""expectedControlLayout"": """",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                },
                {
                    ""name"": ""Crouch"",
                    ""id"": ""6a579445-748e-4c64-86af-8d0d0a382b18"",
                    ""expectedControlLayout"": """",
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
                    ""id"": ""5d644fe4-287f-475f-9e71-3d940a0db68a"",
                    ""path"": ""<Keyboard>/upArrow"",
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
                    ""id"": ""4fbd758f-272b-4a75-a8a7-084e319b6634"",
                    ""path"": ""<XInputController>/dpad/up"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""a52b40bf-b8d9-460e-a157-6a693636c2ee"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DashForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""763214a3-2b4b-4617-bb5c-dcfd7034aee7"",
                    ""path"": ""<XInputController>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DashForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""5b7696f6-2fce-44a2-8ab8-5a18f7305592"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""07ae7d30-ef6a-4015-bd34-0a353e8225f8"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""0487b92d-4718-4fc3-b259-608784125acd"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""8c974a4b-5440-4986-8588-a15b8a23a1a3"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""fcdaea60-c8d4-43ed-8dbd-f462527c9d49"",
                    ""path"": ""<XInputController>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                }
            ]
        },
        {
            ""name"": ""QteControls"",
            ""id"": ""0749edb5-6b96-44a9-a077-2d6beab93d40"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""id"": ""72ead512-805d-4acd-8f7d-adfd239344bb"",
                    ""expectedControlLayout"": """",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""5259a65c-e97d-4097-8478-747aea269258"",
                    ""expectedControlLayout"": """",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""726043eb-0d3e-4cba-8b89-a8dec9c995e1"",
                    ""expectedControlLayout"": """",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""25459d43-f91d-486a-aa36-6e31ac0375b1"",
                    ""expectedControlLayout"": """",
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
                    ""id"": ""e0404059-5677-46ba-9c6f-87fb435e27a4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""d8f9ff84-76ab-495c-8f5f-110f452f01f1"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""3d378b37-e64c-4b7b-93bf-a1934b700028"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""477c71fd-b5e8-4d09-9191-c962e90bc018"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""23c4e54b-7ca6-40c6-82ae-60ab217d213b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""6e4607e8-a0b6-4080-9bfc-3021312f2f1e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
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
        m_PlayerControls_Exit = m_PlayerControls.GetAction("Exit");
        m_PlayerControls_Crouch = m_PlayerControls.GetAction("Crouch");
        // QteControls
        m_QteControls = asset.GetActionMap("QteControls");
        m_QteControls_Up = m_QteControls.GetAction("Up");
        m_QteControls_Down = m_QteControls.GetAction("Down");
        m_QteControls_Left = m_QteControls.GetAction("Left");
        m_QteControls_Right = m_QteControls.GetAction("Right");
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
    private InputAction m_PlayerControls_Exit;
    private InputAction m_PlayerControls_Crouch;
    public struct PlayerControlsActions
    {
        private Controls m_Wrapper;
        public PlayerControlsActions(Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump { get { return m_Wrapper.m_PlayerControls_Jump; } }
        public InputAction @DashForward { get { return m_Wrapper.m_PlayerControls_DashForward; } }
        public InputAction @Exit { get { return m_Wrapper.m_PlayerControls_Exit; } }
        public InputAction @Crouch { get { return m_Wrapper.m_PlayerControls_Crouch; } }
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
                Exit.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnExit;
                Exit.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnExit;
                Exit.cancelled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnExit;
                Crouch.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnCrouch;
                Crouch.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnCrouch;
                Crouch.cancelled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnCrouch;
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
                Exit.started += instance.OnExit;
                Exit.performed += instance.OnExit;
                Exit.cancelled += instance.OnExit;
                Crouch.started += instance.OnCrouch;
                Crouch.performed += instance.OnCrouch;
                Crouch.cancelled += instance.OnCrouch;
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
    // QteControls
    private InputActionMap m_QteControls;
    private IQteControlsActions m_QteControlsActionsCallbackInterface;
    private InputAction m_QteControls_Up;
    private InputAction m_QteControls_Down;
    private InputAction m_QteControls_Left;
    private InputAction m_QteControls_Right;
    public struct QteControlsActions
    {
        private Controls m_Wrapper;
        public QteControlsActions(Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Up { get { return m_Wrapper.m_QteControls_Up; } }
        public InputAction @Down { get { return m_Wrapper.m_QteControls_Down; } }
        public InputAction @Left { get { return m_Wrapper.m_QteControls_Left; } }
        public InputAction @Right { get { return m_Wrapper.m_QteControls_Right; } }
        public InputActionMap Get() { return m_Wrapper.m_QteControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(QteControlsActions set) { return set.Get(); }
        public void SetCallbacks(IQteControlsActions instance)
        {
            if (m_Wrapper.m_QteControlsActionsCallbackInterface != null)
            {
                Up.started -= m_Wrapper.m_QteControlsActionsCallbackInterface.OnUp;
                Up.performed -= m_Wrapper.m_QteControlsActionsCallbackInterface.OnUp;
                Up.cancelled -= m_Wrapper.m_QteControlsActionsCallbackInterface.OnUp;
                Down.started -= m_Wrapper.m_QteControlsActionsCallbackInterface.OnDown;
                Down.performed -= m_Wrapper.m_QteControlsActionsCallbackInterface.OnDown;
                Down.cancelled -= m_Wrapper.m_QteControlsActionsCallbackInterface.OnDown;
                Left.started -= m_Wrapper.m_QteControlsActionsCallbackInterface.OnLeft;
                Left.performed -= m_Wrapper.m_QteControlsActionsCallbackInterface.OnLeft;
                Left.cancelled -= m_Wrapper.m_QteControlsActionsCallbackInterface.OnLeft;
                Right.started -= m_Wrapper.m_QteControlsActionsCallbackInterface.OnRight;
                Right.performed -= m_Wrapper.m_QteControlsActionsCallbackInterface.OnRight;
                Right.cancelled -= m_Wrapper.m_QteControlsActionsCallbackInterface.OnRight;
            }
            m_Wrapper.m_QteControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                Up.started += instance.OnUp;
                Up.performed += instance.OnUp;
                Up.cancelled += instance.OnUp;
                Down.started += instance.OnDown;
                Down.performed += instance.OnDown;
                Down.cancelled += instance.OnDown;
                Left.started += instance.OnLeft;
                Left.performed += instance.OnLeft;
                Left.cancelled += instance.OnLeft;
                Right.started += instance.OnRight;
                Right.performed += instance.OnRight;
                Right.cancelled += instance.OnRight;
            }
        }
    }
    public QteControlsActions @QteControls
    {
        get
        {
            return new QteControlsActions(this);
        }
    }
    public interface IPlayerControlsActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnDashForward(InputAction.CallbackContext context);
        void OnExit(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
    }
    public interface IQteControlsActions
    {
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
    }
}
