using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputController : MonoBehaviour
{
    public static UserInputController instance;

    //public GameObject selectedPlayer;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //selectedPlayer = PlayersSquadController.instance.selectedPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        #region Camera
        //WASD/arrows camera movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //camera movement speed
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            CameraController.instance.SetCameraFastMovementSpeed(true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            CameraController.instance.SetCameraFastMovementSpeed(false);
        }
        //camera movement
        if (horizontalInput != 0 || verticalInput != 0)
        {
            CameraController.instance.MoveCamera(horizontalInput, verticalInput);
        }
        //camera rotation
        if (Input.GetKey(KeyCode.Q))
        {
            CameraController.instance.RotateCameraLeft(true);
        }
        if (Input.GetKey(KeyCode.E))
        {
            //rotates camera counter-clockwise
            CameraController.instance.RotateCameraLeft(false);
        }
        //move camera to target
        if (Input.GetKeyDown(KeyCode.F))
        {
            //CameraController.instance.MoveToTarget();
            CameraController.instance.lockedOnTarget = !CameraController.instance.lockedOnTarget;
            GameData.instance.cameraLockedOnTarget = !GameData.instance.cameraLockedOnTarget;
        }

        //camera zoom
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel != 0)
        {
            CameraController.instance.CameraZoom(scrollWheel);
        }
        #endregion

        //left click
        if (Input.GetMouseButtonDown(0))
        {
            GameObject selectedPlayer = PlayersSquadController.instance.selectedPlayer;
            selectedPlayer.GetComponent<PlayerController>().LeftMouseClick(selectedPlayer.name);
        }

        //right click
        if (Input.GetMouseButtonDown(1))
        {
            //playerScript.RightMouseClick();
            GameObject selectedPlayer = PlayersSquadController.instance.selectedPlayer;
            selectedPlayer.GetComponent<PlayerController>().RightMouseClick(selectedPlayer.name);
        }

        //pause
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.timeScale != 0)
                Time.timeScale = 0f;
            else
                Time.timeScale = 1f;

            print("Paused/Unpaused");
        }
    }    
}
