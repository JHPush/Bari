using State;
using UnityEngine;

namespace State
{
    public class BikeStateContext : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public IBikeState CurrentState
        {
            get; set;
        }

        private readonly BikeController _bikecontroller;

        public BikeStateContext(BikeController bikeController)
        {
            _bikecontroller = bikeController;
        }

        public void Transition()
        {
            CurrentState.Handle(_bikecontroller);
        }
        public void Transition(IBikeState state)
        {
            CurrentState = state;
            CurrentState.Handle(_bikecontroller);
        }
    }

}