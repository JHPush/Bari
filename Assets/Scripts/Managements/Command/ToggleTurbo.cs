using UnityEngine;

namespace Command
{
    public class ToggleTurbo : Command
    {
        private BikeController controller;

        public ToggleTurbo(BikeController _controller) =>
            controller = _controller;

        public override void Execute() =>
            controller.ToggleTurbo();
    }
}