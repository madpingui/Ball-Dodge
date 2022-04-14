using UnityEngine;

public class MobileInput : MonoBehaviour
{
    private const float DEADZONE = 10.0f;

    public static MobileInput Instance { set; get; }

    private bool tap;
    private Vector2 swipeDelta, startTouch, mouseTouch;

    public bool Tap { get { return tap; } }
    public Vector2 SwipeDelta { get { return swipeDelta; } }

    public static float swipeIntensity;

    private void Awake()
    {
        swipeIntensity = 12;
        Instance = this;
    }

    private void Update()
    {
        // lets check inputs

        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0) && tap == false)
        {
            tap = true;
            startTouch = Input.mousePosition;
            startTouch.x -= Screen.width / 2;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            tap = false;
            startTouch = Vector2.zero;
            startTouch.x -= Screen.width / 2;
            swipeDelta = Vector2.zero;
            swipeDelta.x -= Screen.width / 2;
        }
        #endregion

        #region Mobile Inputs
        if (Input.touches.Length !=0)
        {
            if(Input.touches[0].phase == TouchPhase.Began && tap == false)
            {
                tap = true;
                startTouch = Input.touches[0].position;
                startTouch.x -= Screen.width / 2;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                tap = false;
                startTouch = Vector2.zero;
                startTouch.x -= Screen.width / 2;
                swipeDelta = Vector2.zero;
                swipeDelta.x -= Screen.width / 2;
            }
        }
        #endregion

        // lets check with mobile
        if(Input.touches.Length != 0 && tap == true)
        {
            mouseTouch = Input.touches[0].position;
            mouseTouch.x -= Screen.width / 2;

            swipeDelta = mouseTouch - startTouch;
        }
        //lets check with standalone
        else if (Input.GetMouseButton(0) && tap == true)
        {
            mouseTouch = Input.mousePosition;
            mouseTouch.x -= Screen.width / 2;

            swipeDelta = mouseTouch - startTouch;
        }
        if(tap == true && swipeDelta.magnitude > DEADZONE)
        {
            PlayerMotor.x = ((swipeDelta.x) / (Screen.width / 2)) * swipeIntensity;
        }
    }
}
