using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Energy
{
    /// <summary>
    /// <see cref="MonoBehaviour"/> wrapper class for <see cref="WarmthProvider"/>
    /// </summary>
    public class WarmthProviderBehaviour : MonoBehaviour
    {
        [SerializeField] private WarmthProvider warmth;
        public IWarmthProvider WarmthProvider => warmth;
    }

    public interface IWarmthProvider : IEnergyProvider
    {
        WarmthProvider.State CurrentState { get; }
        float WarmthAmount { get; }
        (bool sucessfullyCollected, float amountCollected) Collect();
        void Smother();
        void UnSmother();
    }

    [Serializable]
    public class WarmthProvider : IWarmthProvider
    {
        public WarmthProvider(float initialWarmth = 1)
        {
            this.warmth = initialWarmth;
        }
        
        public enum State
        {
            Active,
            Collected,
            Smothered
        }

        [SerializeField, Range(0, 10)] private float warmth;

        [SerializeField] private bool smothered = false;
        [SerializeField] private bool collected = false;

        public float WarmthAmount =>
            CurrentState switch
            {
                State.Active => warmth,
                _ => 0
            };

        public State CurrentState
        {
            get
            {
                if (collected) return State.Collected;
                if (smothered) return State.Smothered;
                return State.Active;
            }
        }

        private bool IsActive => !smothered && !collected;
       
        public (bool sucessfullyCollected, float amountCollected) Collect()
        {
            return IsActive switch
            {
                true => (collected = true, warmth),
                false => (false, 0)
            };
        }

       
        public void Smother()
        {
            smothered = true;
        }   
        
        public void UnSmother()
        {
            smothered = false;
        }

        public EnergyType EnergyType => EnergyType.Warmth;

        public (EnergyType energyType, float energyValue) GetEnergy() => (EnergyType, WarmthAmount);
    }
    
  
}