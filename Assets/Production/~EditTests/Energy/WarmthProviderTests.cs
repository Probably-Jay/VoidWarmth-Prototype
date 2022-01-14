using System.Collections;
using System.Collections.Generic;
using Game.Energy;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using static Game.Energy.WarmthProvider;

public class WarmthProviderTests
{
    private IWarmthProvider warmthProvider;
    private const float InitialWarmth = 1;

    [SetUp]
    public void SetUp()
    {
        warmthProvider = new WarmthProvider(InitialWarmth);
    }
    
    
   [Test]
    public void GetEnergy_IsValid()
    {
        var warmthProviderEnergyType = warmthProvider.EnergyType;
        var warmthProviderWarmth = warmthProvider.WarmthAmount;
        
        var (energyType, energyValue) = warmthProvider.GetEnergy();
        
        Assert.AreEqual(energyType,warmthProviderEnergyType);
        Assert.AreEqual(energyValue,warmthProviderWarmth);
    } 
    
    [Test]
    public void Collect_CollectsWarmth()
    {
        var initialWarmth = warmthProvider.WarmthAmount;
        
        var (successfullyCollected, amountCollected) = warmthProvider.Collect();
        
        Assert.IsTrue(successfullyCollected);
        Assert.AreEqual(initialWarmth, amountCollected);
        Assert.AreEqual(warmthProvider.CurrentState, State.Collected);
    }
    
    [Test]
    public void Collect_Fails_WhenAlreadyCollected()
    {
        _ = warmthProvider.Collect();
        var (successfullyCollected, _)  = warmthProvider.Collect();
        
        Assert.IsFalse(successfullyCollected);
    } 
    
    [Test]
    public void Smother_Smothers_WhenNotSmothered()
    {
        Assert.AreNotEqual(warmthProvider.CurrentState, State.Smothered);
        
        warmthProvider.Smother();
        
        Assert.AreEqual(warmthProvider.CurrentState, State.Smothered);
    }
    
    [Test]
    public void UnSmother_UnSmothers_WhenSmothered()
    {
        warmthProvider.Smother();
        
        Assert.AreEqual(warmthProvider.CurrentState, State.Smothered);
        
        warmthProvider.UnSmother();

        Assert.AreNotEqual(warmthProvider.CurrentState, State.Smothered);
    }
    
    [Test]
    public void Collect_Fails_WhenSmothered()
    {
        warmthProvider.Smother();
        var (successfullyCollected, _)  = warmthProvider.Collect();
        
        Assert.IsFalse(successfullyCollected);
    } 
    
    [Test]
    public void Warmth_IsZero_WhenCollected()
    {
        {
            var initialWarmth = warmthProvider.WarmthAmount;
            Assert.AreNotEqual(initialWarmth, 0);
        }
        
        warmthProvider.Collect();
        
        var postCollectionWarmth = warmthProvider.WarmthAmount;
        Assert.AreEqual(postCollectionWarmth, 0);
    }  
    
    [Test]
    public void Warmth_IsZero_WhenSmothered()
    {
        {
            var initialWarmth = warmthProvider.WarmthAmount;
            Assert.AreNotEqual(initialWarmth, 0);
        }
        
        warmthProvider.Smother();
        
        var postSmotheringWarmth = warmthProvider.WarmthAmount;
        Assert.AreEqual(postSmotheringWarmth, 0);
    } 
    
   
    
}
