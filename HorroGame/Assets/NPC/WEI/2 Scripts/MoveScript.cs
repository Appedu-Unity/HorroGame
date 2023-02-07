using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour
{

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    public static bool isEnableMove;

    float moveSensitivity = 1.0f;

    float rotationX = 0F;
    float rotationY = 0F;

    //Quaternion originalRotation;
    //¹«??©ñ
    public float sensitivity = 60f;
    public float minFov = 50f;
    public float maxFov = 70f;

    public float speedMove = 10f;
    private float speed;

    void Start()
    {
        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
        // originalRotation = transform.localRotation;
        speed = speedMove;
        isEnableMove = true;
    }

    void Update()
    {
        fnRotate();
        if (isEnableMove)
            fnMove();
        // fnScroll();
    }

    void fnRotate()
    {
        CharacterController controller = gameObject.GetComponent<CharacterController>();
        if (Input.GetMouseButton(1))//0??¥ª? ¡A 1??¥k? ¡A 2??¤¤?
        {
            if (axes == RotationAxes.MouseXAndY)
            {
                float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            }
            else if (axes == RotationAxes.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);

            }
            else
            {
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
            }
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }

    void fnScroll()
    {
        float fov = Camera.main.fieldOfView;
        fov -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }

    void fnMove()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = speedMove * 2f;
        }
        else
            speed = speedMove;


        float fTranslationV = Input.GetAxis("Vertical") * speed;
        float fTranslationH = Input.GetAxis("Horizontal") * speed;
        transform.Translate(0, 0, fTranslationV * Time.deltaTime);
        transform.Translate(fTranslationH * Time.deltaTime, 0, 0);


        if (Input.GetKey(KeyCode.E))
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + 0.5f * speed * Time.deltaTime, transform.localPosition.z);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 0.5f * speed * Time.deltaTime, transform.localPosition.z);
        }
    }
}
