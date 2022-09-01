using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    internal void StartGame()
    {
        this.gameObject.SetActive(false);
        UIManager.Instance.SetDummyCameraActive(false);
    }
}
