using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraControll : MonoBehaviour {

	public enum cameraMode {orthographic, perspective}
    public enum rotateMode {LeftClick = 0, RightClick = 1, MiddleClick = 2}
    public enum panMode {LeftClick = 0, RightClick = 1, MiddleClick = 2}

	public cameraMode cameraState;
    public rotateMode rotateButton;
    public panMode panButton;

    //GameObject cameraObject;

    GameObject actuallyCamera;

    GameObject actuallCameraObject;

    Camera actuallCamera;

    int rotateInt;

    int panInt;

    //GameObject focusPoint;

    [SerializeField]
    Slider zoom;

    //[SerializeField]
    //float dragSpeed = 1;

    private Vector3 panOrigin;

    private Vector3 dragOrigin;

    [SerializeField]
    float maxZoom = 40;

    [SerializeField]
    float minZoom = 3;

    [SerializeField]
    float zoomSpeed = 15;

    [SerializeField]
    float rotateSpeed = 2;

    [SerializeField]
    bool touchZoom;

    [SerializeField]
    bool scrollZoom;

    [SerializeField]
    bool sliderZoom;

    float curZoom;

    float actuallRotate;

    float moveSpeed;

    float moveZoomMultiplier;

    Quaternion fromRotation;
    Quaternion toRotation;

    Vector3 fromPos;
    Vector3 toPos;

    float yDeg;
    float lastMouseX;
    float lastMouseY;

    float currentZoom;

	bool cameraType;

    bool zooming;

    float fovOrsize;

    float screenWidth = Screen.width;
    float screenHeight = Screen.height;

    float deltaMagnitudeDiff;

    public bool canDrag = false;

    bool dragging;

    //float width;
    //float height;
    //float boundary = 1;

    void Start()
	{
        zoom.maxValue = maxZoom;
        zoom.minValue = minZoom;
        zoom.value = maxZoom;
        //width = Screen.width;
        //height = Screen.height;
        //focusPoint = GameObject.FindGameObjectWithTag("FocusPoint");
        transform.parent.position = new Vector3(0, 0, 0);
        panInt = (int)panButton;
        rotateInt = (int)rotateButton;
        //cameraObject = this.gameObject;
        actuallyCamera = this.gameObject.transform.parent.gameObject;
        actuallCameraObject = this.gameObject.transform.GetChild(0).gameObject;
        actuallCamera = GetComponentInChildren<Camera>();
        CheckZoom();
		CameraModeCheck ();
        if (panInt == rotateInt)
        {
            throw new System.Exception("Buttons should not be the same");
        }

        //groundPlane = Plane (groundNormal, groundPoint);
    }

    void Update()
	{
        //float xMouse = Input.mousePosition.x;
        //float yMouse = Input.mousePosition.y;

		if (Input.GetMouseButtonDown(panInt) || Input.GetMouseButtonDown(rotateInt)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, 10000) && hit.transform.tag == "Floor" && Input.touchCount < 2) {
				canDrag = true;
			} else {
				canDrag = false;
			}
		}

        //float xpos = Input.mousePosition.x;
        //float ypos = Input.mousePosition.y;
        //Vector3 movement = new Vector3(0, 0, 0);

        curZoom = Mathf.Lerp(curZoom, currentZoom, Time.deltaTime * zoomSpeed);

        //float fov = actuallCamera.fieldOfView;       

//        Ray ray = Camera.main.ScreenPointToRay(new Vector3(screenWidth/2 , screenHeight/2));
//        RaycastHit hit;
//        if(Physics.Raycast(ray, out hit, 100))
//        {
//            //focusPoint.transform.position = hit.point;
//            focusPoint.transform.localPosition = Vector3.Lerp(focusPoint.transform.position, hit.point, Time.deltaTime * 3);
//            Debug.DrawLine(ray.origin, hit.point);
//        }

        if(curZoom == currentZoom)
        {
            CheckZoom();
        }

        moveSpeed = moveZoomMultiplier * -currentZoom;

        actuallRotate = rotateSpeed * 100;

        if (!cameraType) {
            actuallCamera.orthographicSize = Mathf.Lerp(actuallCamera.orthographicSize, currentZoom, Time.deltaTime * zoomSpeed);
		} else {
            actuallCameraObject.transform.localPosition = new Vector3(0, curZoom, -curZoom);
		}

        if (touchZoom)
        {
            if (Input.touchCount == 2)
            {
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

                deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
                zooming = true;

            }
            else
            {
                zooming = false;
            }

            currentZoom += deltaMagnitudeDiff * zoomSpeed;
        }

        if (scrollZoom) {
            currentZoom -= (Input.GetAxis("Mouse ScrollWheel") * zoomSpeed);
        }

        if (sliderZoom)
        {
            currentZoom = zoom.value;
        }

        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

		if (canDrag && !zooming) {
			if (Input.GetMouseButton (rotateInt)) {
				yDeg += Input.GetAxis ("Mouse X") * Time.deltaTime * actuallRotate;
				fromRotation = actuallyCamera.transform.rotation;
				toRotation = Quaternion.Euler (0, yDeg, 0);
                actuallyCamera.transform.rotation = Quaternion.Lerp (fromRotation, toRotation, Time.deltaTime * actuallRotate);
			}

            //if (Input.GetMouseButtonDown(panInt))
            //{
            //  dragOrigin = Input.mousePosition;
            //}

            //if (Input.GetMouseButton(panInt))
            //{
            //    Vector3 delta = Input.mousePosition - dragOrigin;
            //    transform.Translate(delta.x * dragSpeed, 0 ,delta.z * dragSpeed, 0);
            //    dragOrigin = Input.mousePosition;
            //}

            //original Panning
            if (Input.GetMouseButtonDown(panInt))
            {
                lastMouseX = Input.mousePosition.x;
                lastMouseY = Input.mousePosition.y;
            }
            if (Input.GetMouseButton(panInt))
            {
                float deltaX = Input.mousePosition.x - lastMouseX;
                float deltaY = Input.mousePosition.y - lastMouseY;
                actuallyCamera.transform.position = transform.forward * (deltaY * moveSpeed) + transform.right * (deltaX * moveSpeed) + actuallyCamera.transform.position;
                lastMouseX = Input.mousePosition.x;
                lastMouseY = Input.mousePosition.y;
            }
        }
    }

	void CameraModeCheck(){
		if (cameraState == cameraMode.orthographic) {
			actuallCamera.orthographic = true;
			currentZoom = actuallCamera.orthographicSize;
			moveZoomMultiplier = 0.002f;
            fovOrsize = actuallCamera.orthographicSize * 2;
            moveZoomMultiplier = screenWidth / screenHeight / 800;
            cameraType = false;
		} else {
			actuallCamera.orthographic = false;
			currentZoom = actuallCamera.fieldOfView;
			moveZoomMultiplier = 0.003f;
            fovOrsize = actuallCamera.fieldOfView;
            moveZoomMultiplier = (screenWidth / screenHeight / 1200);
            cameraType = true;
		}
	}

    void CheckZoom()
    {
        curZoom = currentZoom;
    }

    public void zoomin()
    {
        zooming = true;
    }

    public void notzoomin()
    {
        zooming = false;
    }
}
