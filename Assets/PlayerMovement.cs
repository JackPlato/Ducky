using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Camera cam;
    private CharacterController charCon;
    public float velocityFwd = 0.4f;
    public float velocityStrafe = 0.4f;
    public float camTilt = 0.4f;
    bool leftPress;
    bool rightPress;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        charCon = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        leftPress = Input.GetKey(KeyCode.A);
        rightPress = Input.GetKey(KeyCode.D);
    }
    void FixedUpdate()
    {
        charCon.Move(velocityFwd * transform.forward);
        if (leftPress && !rightPress)
        {
            charCon.Move(velocityStrafe * (transform.right*-1));
            Vector3 newRot = new Vector3(0, 0, -camTilt);
        }
        else if (rightPress && !leftPress)
        {
            Vector3 newRot = new Vector3(0, 0, -camTilt);
            charCon.Move(velocityStrafe * transform.right);
        }
        else
        {

        }
    }
}
