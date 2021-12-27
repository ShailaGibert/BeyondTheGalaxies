using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HealthTest
{
    [Test]
    public void TakeDamage_LowerHP_HealthTaken()
    {
        GameObject testObject = new GameObject();
        PlayerHealth healthScript = testObject.AddComponent<PlayerHealth>();
        healthScript.currentHealth = 2;
        healthScript.TakeDamage(1);

        Assert.AreEqual(1, testObject.GetComponent<PlayerHealth>().currentHealth);
    }

}
