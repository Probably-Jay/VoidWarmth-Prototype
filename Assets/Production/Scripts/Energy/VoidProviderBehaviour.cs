using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Energy
{
    public class VoidProviderBehaviour : MonoBehaviour
    {
        [SerializeField] private VoidProvider voidProvider;
        public IVoidProvider VoidProvider => voidProvider;
    }

    public interface IVoidProvider : IEnergyProvider
    { 
        VoidProvider.State CurrentState { get; }
        float VoidAmount { get; }
        void Grow();
        void Dispel();
    }

    [Serializable]
    public class VoidProvider : IVoidProvider
    {
        public VoidProvider(float initialVoidAmount = 1)
        {
            this.voidAmount = initialVoidAmount;
        }
        
        public enum State
        {
            Active,
            Dispelled,
        }
        
        [SerializeField, Range(0, 10)] private float voidAmount;

        [SerializeField] private bool dispelled = false;
        
        public State CurrentState
        {
            get
            {
                if (dispelled) return State.Dispelled;
                return State.Active;
            }
        }

        public float VoidAmount
        {
            get => CurrentState switch
            {
                State.Active => voidAmount,
                _ => 0
            };

            set => voidAmount = value;
        }

        public void Grow()
        {
            throw new System.NotImplementedException();
        }

        public void Dispel() 
            => dispelled = true;

        public EnergyType EnergyType => EnergyType.Void;
        public (EnergyType energyType, float energyValue) GetEnergy() => (EnergyType, VoidAmount);
    }
}