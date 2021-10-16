using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    
    public GameObject target;

    public bool lockedOnTarget = false;

    [SerializeField]
    GameObject cameraGO;
    Camera mainCamera;
    [SerializeField]
    GameObject forwardDirection;
    [SerializeField]
    private GameObject anchor;

    [Header("POSITIONING")]
    [SerializeField]
    private float xOffset;
    [SerializeField]
    private float height;
    [SerializeField]
    private float zOffset;

    [Header("MOVEMENT")]
    [SerializeField]
    float speed;
    [SerializeField]
    float normalSpeed;
    [SerializeField]
    float fastSpeed;

    [Header("ZOOM")]
    [SerializeField]
    float currentZoom = 0f;
    [SerializeField]
    float minZoom = 5f;
    [SerializeField]
    float maxZoom = 20f;

    [SerializeField]
    float zoomSpeed;

    [Header("ROTATION")]
    [SerializeField]
    Quaternion currentRotation;
    [SerializeField]
    float rotationSpeed;
    [SerializeField]
    float normalRotationSpeed = 20f;
    [SerializeField]
    float fastRotationSpeed = 40f;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //positioning
        cameraGO.transform.position = new Vector3(xOffset, height, zOffset);
        anchor.transform.localPosition = new Vector3(xOffset, -height, zOffset);

        //target = GameObject.FindGameObjectWithTag("Player");
        mainCamera = Camera.main;
        speed = normalSpeed;
        rotationSpeed = normalRotationSpeed;
        currentRotation = this.transform.rotation;
        lockedOnTarget = GameData.instance.cameraLockedOnTarget;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Quaternion.Lerp(transform.rotation, currentRotation, Time.deltaTime * speed);
        //keep camera height relevant to target
        if(target)
            AdjustCameraHeight();
        
        

        if (lockedOnTarget && target != null)
            FollowTarget();
    }

    public void MoveCamera(float horiMove, float vertMove)
    {
        lockedOnTarget = false;

        float hori;
        float vert;

        hori = horiMove * speed * Time.deltaTime;
        vert = vertMove * speed * Time.deltaTime;

        //cameraGO.transform.Translate(-hori, 0, -vert);        
        cameraGO.transform.Translate(hori, 0, 0, mainCamera.transform);
        cameraGO.transform.Translate(0, 0, vert, forwardDirection.transform);
    }

    public void SetCameraFastMovementSpeed(bool fast)
    {
        if (fast)
        {
            speed = fastSpeed;
            rotationSpeed = fastRotationSpeed;
        }
        else
        {
            speed = normalSpeed;
            rotationSpeed = normalRotationSpeed;
        }
    }

    public void CameraZoom(float zoomAmount)
    {
        if (zoomAmount > 0 && currentZoom <= maxZoom)
            currentZoom += Time.fixedDeltaTime;
        else if (zoomAmount < 0 && currentZoom >= minZoom)
            currentZoom -= Time.fixedDeltaTime;

        if (currentZoom < maxZoom && currentZoom > minZoom)
        {
            float currentZoom = zoomAmount * zoomSpeed * Time.fixedDeltaTime;

            mainCamera.gameObject.transform.Translate(0, 0, currentZoom, Space.Self);
        }
        
    }

    public void RotateCameraLeft(bool left)
    {
        Vector3 targetPos;
        if (lockedOnTarget)
            targetPos = target.transform.position;
        else
            targetPos = anchor.transform.position;

        if(left)
            mainCamera.transform.RotateAround(targetPos, Vector3.up, rotationSpeed * Time.fixedDeltaTime);
        else
            mainCamera.transform.RotateAround(targetPos, Vector3.up, -rotationSpeed * Time.fixedDeltaTime);
    }       

    public void FollowTarget()
    {
        currentRotation = Quaternion.Euler(0, 0, 0);
        
        this.transform.position = new Vector3(target.transform.position.x - xOffset, this.transform.position.y, target.transform.position.z - zOffset);
        AdjustCameraHeight();
    }

    private void AdjustCameraHeight()
    {
        this.transform.position = new Vector3(this.transform.position.x, target.transform.position.y + height, this.transform.position.z);
    }
}
