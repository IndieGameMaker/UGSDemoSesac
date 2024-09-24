using TMPro;
using Unity.Services.Authentication;
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

            // 로그인 후 콜백 연결
            PlayerAccountService.Instance.SignedIn += OnSignedIn;
            PlayerAccountService.Instance.SignedOut += () =>
            {
                Debug.Log("로그 아웃!");
            };

            signInButton.onClick.AddListener(async () =>
            {
                await PlayerAccountService.Instance.StartSignInAsync();
            });

            signOutButton.onClick.AddListener(() =>
            {
                PlayerAccountService.Instance.SignOut();
            });
        }

        // 로그인 프로세스 
        private async void OnSignedIn()
        {
            string accessToken = PlayerAccountService.Instance.AccessToken;
            Debug.Log($"AuthenticationService.Instance.IsSignedIn : {AuthenticationService.Instance.IsSignedIn}");
            if (AuthenticationService.Instance.IsSignedIn) return;
            await AuthenticationService.Instance.SignInWithUnityAsync(accessToken);
            Debug.Log("로그인 완료");
        }
    }
}
