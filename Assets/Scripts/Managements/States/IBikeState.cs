using UnityEngine;

namespace State
{
    public interface IBikeState
    {
        void Handle(BikeController controller);
    }
}