﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignupToLogScript : MonoBehaviour
{
    public void navigaterino()
    {
        SceneManager.LoadScene("MenuLoginScene", LoadSceneMode.Single);
    }
}