using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private MainMenu mainMenu;
    [SerializeField] private Camera dummyCamera;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            mainMenu.StartGame();
            mainMenu.gameObject.SetActive(false);
        }
    }

    public void SetDummyCameraActive(bool isOn)
    {
        dummyCamera.gameObject.SetActive(isOn);
    }
}
