using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PauseMenuTest
{
    [Test]
    public void Pause_PauseGame_MenuSetActive()
    {
        GameObject testObject = new GameObject();
        MenuPause pauseScript = testObject.AddComponent<MenuPause>();
        GameObject pauseUI = pauseScript.GetComponent<MenuPause>().pauseMenuUI;
        pauseUI.SetActive(false);
        pauseScript.Pause();

        Assert.IsTrue(testObject.activeSelf);
    }

}
