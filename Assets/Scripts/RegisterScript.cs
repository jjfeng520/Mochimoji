using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class RegisterScript : MonoBehaviour {
    public InputField registerUsername;
    public InputField registerPassword;
    public Button registerButton;

    public Text registerUsernameValidation;
    public Text registerPasswordValidation;

    private string Username;
    private string Password;
    private int Score;
    private string form;


    public void Register()
    {
        bool UN = false;
        bool PW = false;

        // Checks if username is already registered.
        if (Username != "")
        {
            if (!System.IO.File.Exists(@"C:/Users/Jennifer/Documents/CodingDojo/UnityTestDbFolder_Mochimoji/" + Username + ".txt"))
            {
                UN = true;
                registerUsernameValidation.gameObject.SetActive(false);
            }
            else
            {
                registerUsernameValidation.text = "Username is already taken.";
                registerUsernameValidation.gameObject.SetActive(true);
            }
        }
        else
        {
            registerUsernameValidation.text = "Username field must not be empty.";
            registerUsernameValidation.gameObject.SetActive(true);
        }

        // Checks if password is valid.
        if (Password != "")
        {
            if(Password.Length > 5)
            {
                PW = true;
                registerPasswordValidation.gameObject.SetActive(false);
            }
            else
            {
                registerPasswordValidation.text = "Password must be at least 6 characters long.";
                registerPasswordValidation.gameObject.SetActive(true);
            }
        }
        else
        {
            registerPasswordValidation.text = "Password field must not be empty.";
            registerPasswordValidation.gameObject.SetActive(true);
        }

        // If everything is valid.
        if (UN == true && PW == true)
        {
            // Encrypt the password.
            bool Clear = true;
            int i = 1;
            foreach(char character in Password)
            {
                if (Clear)
                {
                    Password = "";
                    Clear = false;
                }
                i++;
                char Encrypted = (char)(character * i);
                Password += Encrypted.ToString();
            }

            // Save user info.
            form = (Username + "\r\n" + Password);
            System.IO.File.WriteAllText(@"C:/Users/Jennifer/Documents/CodingDojo/UnityTestDbFolder_Mochimoji/" + Username + ".txt", form);

            // Clear registration form.
            //registerUsername.text = "";
            //registerPassword.text = "";

            // Save account info to player preferences.
            PlayerPrefs.SetString("LoggedUser", Username);

            // Load start scene.
            SceneManager.LoadSceneAsync("GameStartScene", LoadSceneMode.Single);
        }
    }
	
	// Allow user to tab through fields and clicking Enter will submit the form.
	void Update () {
        // If user clicks Tab key, it will select next input field.
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (registerUsername.isFocused)
            {
                registerPassword.Select();
            }
            if (registerPassword.isFocused)
            {
                registerButton.Select();
            }
        }

        // If user clicks enter/return key, it will submit the form.
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Password != "" && Username != "")
            {
                Register();
            }
        }
        Username = registerUsername.text;
        Password = registerPassword.text;
	}
}
