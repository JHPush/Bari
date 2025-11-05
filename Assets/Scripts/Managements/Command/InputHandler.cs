using UnityEngine;

namespace Command
{
    public class InputHandler : MonoBehaviour
    {
        private Invoker invoker;
        private bool isReplaying;
        private bool isRecording;
        private BikeController controller;
        private Command buttonA, buttonD, buttonW;

        void Start()
        {
            invoker = gameObject.AddComponent<Invoker>();
            controller = gameObject.AddComponent<BikeController>();
            buttonA = new TurnLeft(controller);
            buttonD = new TurnRight(controller);
            buttonW = new ToggleTurbo(controller);
        }
        void Update()
        {
            if (!isReplaying && isRecording)
            {
                if (Input.GetKeyUp(KeyCode.A))
                    invoker.ExecuteCommand(buttonA);

                if (Input.GetKeyUp(KeyCode.D))
                    invoker.ExecuteCommand(buttonD);

                if (Input.GetKeyUp(KeyCode.W))
                    invoker.ExecuteCommand(buttonW);
            }
        }

        void OnGUI()
        {
            if (GUILayout.Button("Start Recording"))
            {
                controller.ResetPosition();
                isReplaying = false;
                isRecording = true;
                invoker.Record();
            }
            if (GUILayout.Button("Stop Recording"))
            {
                controller.ResetPosition();
                isRecording = false;
            }
            if (!isRecording)
            {
                if(GUILayout.Button("Start Replay"))
                {
                    controller.ResetPosition();
                    isRecording = false;
                    isReplaying = true;
                    invoker.Replay();
                }
            }
        }
    }
}