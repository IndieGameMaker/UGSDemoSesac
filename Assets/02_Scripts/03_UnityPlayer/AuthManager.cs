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

            signInButton.onClick.AddListener(async () =>
            {
                await PlayerAccountService.Instance.StartSignInAsync();
            });
        }

        // 로그인 프로세스 
        private async void OnSignedIn()
        {
            string accessToken = PlayerAccountService.Instance.AccessToken;
            await AuthenticationService.Instance.SignInWithUnityAsync(accessToken);
            Debug.Log("로그인 완료");
        }
    }
}
