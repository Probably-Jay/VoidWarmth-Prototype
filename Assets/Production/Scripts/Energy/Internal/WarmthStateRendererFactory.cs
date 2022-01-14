using System.Collections.Generic;
using UnityEngine;
using static Game.Energy.WarmthProvider;

namespace Game.Energy.Rendering.Internal
{
    public interface IStateRenderer
    {
        void Render(WarmthVisualisationController visualiserBehaviour);
    }
    public class WarmthStateRendererFactory
    {
        private readonly Dictionary<State, StateRenderer> _renderers;

        public WarmthStateRendererFactory(WarmthVisualisationController visualisationControllerBehaviour)
        {
            _renderers = new Dictionary<State, StateRenderer>()
            {
                {State.Active, new WarmthActiveStateRenderer(visualisationControllerBehaviour)},
                {State.Collected, new WarmthCollectedStateRenderer(visualisationControllerBehaviour)},
                {State.Smothered, new WarmthSmotheredStateRenderer(visualisationControllerBehaviour)},
            };
        }
       
        
        public StateRenderer GetRenderer(State state) => _renderers[state];
    }

    public abstract class StateRenderer
    {
        protected readonly WarmthVisualisationController _visualisationControllerBehaviour;
        protected readonly ParticleSystem _particleSystem;

        public StateRenderer(WarmthVisualisationController visualisationControllerBehaviour)
        {
            _visualisationControllerBehaviour = visualisationControllerBehaviour;
            _particleSystem = _visualisationControllerBehaviour.GetComponent<ParticleSystem>();
        }
        
        public abstract State StateRendered { get; }
        public abstract void Render();
    }

    public class WarmthActiveStateRenderer : StateRenderer
    {
        public override State StateRendered => State.Active;
        public override void Render()
        {
            
        }

        public WarmthActiveStateRenderer(WarmthVisualisationController visualisationControllerBehaviour) : base(visualisationControllerBehaviour)
        { }
    }

    

    public class WarmthCollectedStateRenderer : StateRenderer
    {
        public override State StateRendered => State.Collected;

        public override void Render()
        {
            
        }

        public WarmthCollectedStateRenderer(WarmthVisualisationController visualisationControllerBehaviour) : base(visualisationControllerBehaviour)
        { }
    }
   
    public class WarmthSmotheredStateRenderer : StateRenderer
    {
        public override State StateRendered => State.Smothered;

        public override void Render()
        {
            
        }

        public WarmthSmotheredStateRenderer(WarmthVisualisationController visualisationControllerBehaviour) : base(visualisationControllerBehaviour)
        { }
    }
}