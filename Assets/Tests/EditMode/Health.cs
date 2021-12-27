using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Scripts
{
    // A Test behaves as an ordinary method
    [Test]
    public void PlayerHealth()
    {   
        var gobj= new GameObject();
        var playerHealth=gobj.AddComponent<PlayerHealth>();
        playerHealth.currentHealth=100;
        Assert.AreEqual(100,playerHealth.currentHealth );

     
    }
}
