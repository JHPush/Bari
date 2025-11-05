using UnityEngine;

namespace State
{
    public class BikeStopState : MonoBehaviour, IBikeState
    {
        private BikeController _inst;

        public void Handle(BikeController controller)
        {
            if(!_inst)
                _inst = controller;

            _inst.CurrentSpd = 0f;

        }
    }
}