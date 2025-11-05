using UnityEngine;

namespace Command
{
    public class BikeController : MonoBehaviour
    {
        public enum Direction
        {
            Left = -1, Right = 1
        }
        private bool isTurboOn;
        private float distance = 1f;
        public void ToggleTurbo()
        {
            isTurboOn = !isTurboOn;
            Debug.Log("Turbo Active : " + isTurboOn.ToString());
        }
        public void Turn(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    transform.Translate(Vector3.left * distance);
                    break;
                case Direction.Right:
                    transform.Translate(Vector3.right * distance);
                    break;
            }
        }
        
        public void ResetPosition()
        {
            transform.position = new Vector3();
        }
    }
}