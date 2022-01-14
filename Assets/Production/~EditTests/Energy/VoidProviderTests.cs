using System.Collections;
using System.Collections.Generic;
using Game.Energy;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using static Game.Energy.VoidProvider;

public class VoidProviderTests
{
    private IVoidProvider voidProvider;
    private const float InitialVoid = 1;

    [SetUp]
    public void SetUp()
    {
        voidProvider = new VoidProvider(InitialVoid);
    }
    
    
   [Test]
    public void GetVoid_IsValid()
    {
        var voidProviderEnergyType = voidProvider.EnergyType;
        var voidProviderVoidAmount = voidProvider.VoidAmount;
        
        var (energyType, energyValue) = voidProvider.GetEnergy();
        
        Assert.AreEqual(energyType,voidProviderEnergyType);
        Assert.AreEqual(energyValue,voidProviderVoidAmount);
    } 
    
    
    [Test]
    public void Dispel_Dispels_WhenNotDispelled()
    {
        Assert.AreNotEqual(voidProvider.CurrentState, State.Dispelled);
        
        voidProvider.Dispel();
        
        Assert.AreEqual(voidProvider.CurrentState, State.Dispelled);
    }
    
    
    [Test]
    public void Void_IsZero_WhenDispelled()
    {
        {
            var initialVoid = voidProvider.VoidAmount;
            Assert.AreNotEqual(initialVoid, 0);
        }
        
        voidProvider.Dispel();
        
        var postCollectionVoid = voidProvider.VoidAmount;
        Assert.AreEqual(postCollectionVoid, 0);
    }  
    
  
}
