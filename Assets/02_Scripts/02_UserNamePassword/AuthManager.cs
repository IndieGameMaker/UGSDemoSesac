
using System.Threading.Tasks;
using TMPro;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.UI;

namespace AuthUserNamePassword
{
    public class AuthManager : MonoBehaviour
    {
        [SerializeField] private TMP_InputField userNameIf, passwordIf;
        [SerializeField] private Button signUpButton, signInButton;

        private async void Awake()
        {
            await UnityServices.InitializeAsync();
            Debug.Log("UGS 초기화");

            signUpButton.onClick.AddListener(async () =>
            {

            });
        }

        // 회원가입 로직
        private async Task SignUpAsync(string userName, string password)
        {
            try
            {
                await AuthenticationService.Instance.SignUpWithUsernamePasswordAsync(userName, password);
                Debug.Log("회원 가입 완료");
            }
            catch (AuthenticationException e)
            {
                Debug.LogException(e);
            }
            catch (RequestFailedException e)
            {
                Debug.LogException(e);
            }
        }
        // 로그인 로직
    }
}