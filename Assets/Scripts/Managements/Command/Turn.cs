namespace Command
{
    public class TurnLeft : Command
    {
        private BikeController controller;

        public TurnLeft(BikeController _controller) =>
            controller = _controller;

        public override void Execute() =>
            controller.Turn(BikeController.Direction.Left);
    }
    public class TurnRight : Command
    {
        private BikeController controller;

        public TurnRight(BikeController _controller) =>
            controller = _controller;

        public override void Execute()
        {
            controller.Turn(BikeController.Direction.Right);
        }
    }
    
}