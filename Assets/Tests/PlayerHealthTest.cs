using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerHealthTest : MonoBehaviour
{

    [Test]

    public void TakeDamage_EmptyHP_ObjectSet()
    {


        GameObject testObject = new GameObject();

        PlayerHealth playerHealthScript = testObject.AddComponent<PlayerHealth>();

        playerHealthScript.currentHealth = 0;
        playerHealthScript.TakeDamage(0);

        Assert.IsTrue(testObject.activeSelf);


    }

    [Test]

    public void TakeDamage_DamHP_ObjectSet()
    {


        GameObject testObject = new GameObject();

        PlayerHealth playerHealthScript = testObject.AddComponent<PlayerHealth>();

        playerHealthScript.currentHealth = 50;
        playerHealthScript.TakeDamage(0);

        Assert.IsTrue(testObject.activeSelf);


    }


}
