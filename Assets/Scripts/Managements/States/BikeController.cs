using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace State
{
    public class BikeController : MonoBehaviour
    {
        public float maxSpd = 2f;
        public float turnDistance = 2f;
        public float CurrentSpd { get; set; }

        public Direction CurrentTurnDirection
        {
            get; private set;
        }

        private IBikeState _startState, _stopState, _turnState;
        private BikeStateContext _bikeStateContext;

        private void Start()
        {
            _bikeStateContext = new BikeStateContext(this);

            // _startState = gameObject.AddComponent<BikeStartState>();
            _stopState = gameObject.AddComponent<BikeStopState>();
            // _turnState = gameObject.AddComponent<BikeTurnState>();

            _bikeStateContext.Transition(_stopState);
        }

        public void StartBike() =>
            _bikeStateContext.Transition(_startState);

        public void StopBike() =>
            _bikeStateContext.Transition(_stopState);

        public void TurnBike(Direction dir)
        {
            CurrentTurnDirection = dir;
            _bikeStateContext.Transition(_turnState);
        }
    }
}