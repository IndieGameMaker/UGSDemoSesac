
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AuthUserNamePassword
{
    public class AuthManager : MonoBehaviour
    {
        [SerializeField] private TMP_InputField userNameIf, passwordIf;
        [SerializeField] private Button signUpButton, signInButton;
    }
}