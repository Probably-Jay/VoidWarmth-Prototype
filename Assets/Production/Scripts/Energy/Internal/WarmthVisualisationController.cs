using System;
using System.Collections;
using Game.Energy.Rendering.Internal;
using UnityEngine;
using static Game.Energy.WarmthProvider;

namespace Game.Energy.Rendering
{

    [RequireComponent(typeof(WarmthProviderBehaviour))]
    public class WarmthVisualisationController : MonoBehaviour
    {
        private IWarmthProvider _provider;
        private State _currentState;

        private void Awake()
        {
            _provider = GetComponent<WarmthProviderBehaviour>().WarmthProvider;
            _currentState = _provider.CurrentState;
        }

        private void Update()
        {
            var newState = _provider.CurrentState;
            switch (newState)
            {
                case State.Active:
                    RenderActiveState();
                    break;
                case State.Collected:
                    RenderCollectedState();
                    break;
                case State.Smothered:
                    RenderSmotheredState();
                    break;
            }

            _currentState = newState;
        }

        private void RenderActiveState()
        {
            
        }

        private void RenderCollectedState()
        {
            throw new NotImplementedException();
        }

        private void RenderSmotheredState()
        {
            throw new NotImplementedException();
        }
    }

   
    
    
   
}