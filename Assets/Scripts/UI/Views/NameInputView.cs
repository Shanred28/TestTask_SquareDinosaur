using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace UI.Views
{
    public class NameInputView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField nickInput;
        [SerializeField] private Button connectButton;
        [SerializeField] private TMP_InputField addressInput;

        public event Action<string,string> OnConnectClicked;

        void Awake()
        {
            connectButton.onClick.AddListener(() =>
            {
                var nick = nickInput.text.Trim();
                if (string.IsNullOrEmpty(nick))
                    nick = $"Player{Random.Range(1000, 9999)}";
                
                var address = addressInput.text.Trim();
                OnConnectClicked?.Invoke(nick, address);
            });
        }
        
        public void SetInteractable(bool value) => connectButton.interactable = value;
    }
}
