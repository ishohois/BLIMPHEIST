using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class CameraViewportHandler : MonoBehaviour
{
    
    // Set this to the in-world distance between the left & right edges of your scene.
    public float sceneWidth = 20.5f;

    private Camera camera;
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Adjust the camera's height so the desired scene width fits in view
    // even if the screen/window size changes dynamically.
    void Update()
    {
        float unitsPerPixel = sceneWidth / Screen.width;

        float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;

        camera.orthographicSize = desiredHalfHeight;
    }
    


    /*
    public SpriteRenderer rink;

    // Use this for initialization
    void Start()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = rink.bounds.size.x / rink.bounds.size.y;

        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = rink.bounds.size.y / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = rink.bounds.size.y / 2 * differenceInSize;
        }
    }
    */

    /*
    private float baseAspect = 1280.0f / 800.0f;

    void Start()
    {
        float currAspect = 1.0f * Screen.width / Screen.height;
        Debug.Log(Camera.main.projectionMatrix);
        Debug.Log(baseAspect + ", " + currAspect + ", " + baseAspect / currAspect);
        Camera.main.projectionMatrix = Matrix4x4.Scale(Vector3(currAspect / baseAspect, 1.0, 1.0)) * Camera.main.projectionMatrix;
    }
    */


    /*
    public int targetWidth = 640;
    public float pixelsToUnits = 100;

    void Update()
    {

        int height = Mathf.RoundToInt(targetWidth / (float)Screen.width * Screen.height);

        Camera.main.orthographicSize = height / pixelsToUnits / 2;

    }
    /*
    

    /*
    public bool maintainWidth = true;

    [Range(-1, 1)]
    public int adaptPosition;

    float defaultWidth;
    float defaultHeight;

    Vector3 CameraPos;

    void Start()
    {
        CameraPos = Camera.main.transform.position;

        defaultHeight = Camera.main.orthographicSize;
        defaultWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    void Update()
    {
        if(maintainWidth)
        {
            Camera.main.orthographicSize = defaultWidth / Camera.main.aspect;

            Camera.main.transform.position = new Vector3(CameraPos.x, adaptPosition * (defaultHeight - Camera.main.orthographicSize), CameraPos.z);
        }
        else
        {
            Camera.main.transform.position = new Vector3(adaptPosition * (defaultWidth - Camera.main.orthographicSize * Camera.main.aspect), CameraPos.y, CameraPos.z);
        }
    }
    */



    /*
    private float targetAspect; // = 1080.0f / 1920.0f
    // Start is called before the first frame update
    void Start()
    {
        float currentAspect = (float)Screen.width / (float)Screen.height;
        float rectHeight = currentAspect / targetAspect;
        Rect cameraRect = Camera.main.rect;
        cameraRect.height = rectHeight;
        cameraRect.y = (1.0f - rectHeight) / 2.0f;
        Camera.main.rect = cameraRect;
    }
    */




    /*
    public float targetAspect; 

    void Start()
    {
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;
        Camera camera = GetComponent<Camera>();

        if (scaleHeight < 1.0f)
        {
            camera.orthographicSize = camera.orthographicSize / scaleHeight;
        }
    }
    */



    /*
	void Start()
	{
		// set the desired aspect ratio, I set it to fit every screen 
		float targetaspect = (float)Screen.width / (float)Screen.height;

		// determine the game window's current aspect ratio
		float windowaspect = (float)Screen.width / (float)Screen.height;

		// current viewport height should be scaled by this amount
		float scaleheight = windowaspect / targetaspect;

		// obtain camera component so we can modify its viewport
		Camera camera = GetComponent<Camera>();

		// if scaled height is less than current height, add letterbox
		if (scaleheight < 1.0f)
		{
			Rect rect = camera.rect;

			rect.width = 1.0f;
			rect.height = scaleheight;
			rect.x = 0;
			rect.y = (1.0f - scaleheight) / 2.0f;

			camera.rect = rect;
		}
		else // add container box
		{
			float scalewidth = 9f / scaleheight;

			Rect rect = camera.rect;

			rect.width = scalewidth;
			rect.height = 1.0f;
			rect.x = (1.0f - scalewidth) / 2.0f;
			rect.y = 0;

			camera.rect = rect;
		}
	}
    */


    /*
	// Set this to the in-world distance between the left & right edges of your scene.
	public float sceneWidth = 20.5f;

    private Camera camera;
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Adjust the camera's height so the desired scene width fits in view
    // even if the screen/window size changes dynamically.
    void Update()
    {
        float unitsPerPixel = sceneWidth / Screen.width;

        float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;

        camera.orthographicSize = desiredHalfHeight;
    }
	*/

    /*
    #region FIELDS
    public Color wireColor = Color.white;
    public float UnitsSize = 1; // size of your scene in unity units
    public Constraint constraint = Constraint.Portrait;
    public static CameraViewportHandler Instance;
    public new Camera camera;

    private float _width;
    private float _height;
    //*** bottom screen
    private Vector3 _bl;
    private Vector3 _bc;
    private Vector3 _br;
    //*** middle screen
    private Vector3 _ml;
    private Vector3 _mc;
    private Vector3 _mr;
    //*** top screen
    private Vector3 _tl;
    private Vector3 _tc;
    private Vector3 _tr;
    #endregion

    #region PROPERTIES
    public float Width
    {
        get
        {
            return _width;
        }
    }
    public float Height
    {
        get
        {
            return _height;
        }
    }

    // helper points:
    public Vector3 BottomLeft
    {
        get
        {
            return _bl;
        }
    }
    public Vector3 BottomCenter
    {
        get
        {
            return _bc;
        }
    }
    public Vector3 BottomRight
    {
        get
        {
            return _br;
        }
    }
    public Vector3 MiddleLeft
    {
        get
        {
            return _ml;
        }
    }
    public Vector3 MiddleCenter
    {
        get
        {
            return _mc;
        }
    }
    public Vector3 MiddleRight
    {
        get
        {
            return _mr;
        }
    }
    public Vector3 TopLeft
    {
        get
        {
            return _tl;
        }
    }
    public Vector3 TopCenter
    {
        get
        {
            return _tc;
        }
    }
    public Vector3 TopRight
    {
        get
        {
            return _tr;
        }
    }
    #endregion

    #region METHODS
    private void Awake()
    {
        camera = GetComponent<Camera>();
        Instance = this;
        ComputeResolution();
    }

    private void ComputeResolution()
    {
        float leftX, rightX, topY, bottomY;

        if (constraint == Constraint.Landscape)
        {
            camera.orthographicSize = 1f / camera.aspect * UnitsSize / 2f;
        }
        else
        {
            camera.orthographicSize = UnitsSize / 2f;
        }

        _height = 2f * camera.orthographicSize;
        _width = _height * camera.aspect;

        float cameraX, cameraY;
        cameraX = camera.transform.position.x;
        cameraY = camera.transform.position.y;

        leftX = cameraX - _width / 2;
        rightX = cameraX + _width / 2;
        topY = cameraY + _height / 2;
        bottomY = cameraY - _height / 2;

        //*** bottom
        _bl = new Vector3(leftX, bottomY, 0);
        _bc = new Vector3(cameraX, bottomY, 0);
        _br = new Vector3(rightX, bottomY, 0);
        //*** middle
        _ml = new Vector3(leftX, cameraY, 0);
        _mc = new Vector3(cameraX, cameraY, 0);
        _mr = new Vector3(rightX, cameraY, 0);
        //*** top
        _tl = new Vector3(leftX, topY, 0);
        _tc = new Vector3(cameraX, topY, 0);
        _tr = new Vector3(rightX, topY, 0);
    }

    private void Update()
    {
#if UNITY_EDITOR
        ComputeResolution();
#endif
    }

    void OnDrawGizmos()
    {
        Gizmos.color = wireColor;

        Matrix4x4 temp = Gizmos.matrix;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        if (camera.orthographic)
        {
            float spread = camera.farClipPlane - camera.nearClipPlane;
            float center = (camera.farClipPlane + camera.nearClipPlane) * 0.5f;
            Gizmos.DrawWireCube(new Vector3(0, 0, center), new Vector3(camera.orthographicSize * 2 * camera.aspect, camera.orthographicSize * 2, spread));
        }
        else
        {
            Gizmos.DrawFrustum(Vector3.zero, camera.fieldOfView, camera.farClipPlane, camera.nearClipPlane, camera.aspect);
        }
        Gizmos.matrix = temp;
    }
    #endregion

    public enum Constraint { Landscape, Portrait }
    */



}
