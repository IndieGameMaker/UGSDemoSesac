using TMPro;
using Unity.Services.Authentication.PlayerAccounts;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.UI;

namespace AuthUnityPlayer
{
    public class AuthManager : MonoBehaviour
    {
        [SerializeField] private Button signInButton, signOutButton, playerNameSaveButton;
        [SerializeField] private TMP_InputField playerNameIf;

        private async void Awake()
        {
            await UnityServices.InitializeAsync();

            signInButton.onClick.AddListener(async () =>
            {
                await PlayerAccountService.Instance.StartSignInAsync();
            });
        }
    }
}
