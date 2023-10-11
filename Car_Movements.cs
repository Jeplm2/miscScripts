using UnityEngine;

public class Car_Movements : MonoBehaviour
{
    public WheelCollider wheel_front_left_col, wheel_front_right_col, wheel_back_left_col, wheel_back_right_col;
    public Transform wheel_front_left_tr, wheel_front_right_tr, wheel_back_left_tr, wheel_back_right_tr;
    public float speed = 2000f;

    public float _steerAngle = 25f;
    public float steerAng;

    void FixedUpdate()
    {
        Steer();
        UpdateWheelPos(wheel_front_left_col, wheel_front_left_tr);
        UpdateWheelPos(wheel_front_right_col, wheel_front_right_tr);
        UpdateWheelPos(wheel_back_left_col, wheel_back_left_tr);
        UpdateWheelPos(wheel_back_right_col, wheel_back_right_tr);


        if(Input.GetButton("Jump"))
        {
            // wheel_back_left_col.motorTorque = 0;
            // wheel_back_right_col.motorTorque = 0;
            // wheel_front_left_col.motorTorque = 0;
            // wheel_front_right_col.motorTorque = 0;
            wheel_back_left_col.brakeTorque = speed * 2;
            wheel_back_right_col.brakeTorque = speed * 2;
            wheel_front_left_col.brakeTorque = speed * 2;
            wheel_front_right_col.brakeTorque = speed * 2;
        }
        else
        {
            wheel_back_left_col.brakeTorque = 0;
            wheel_back_right_col.brakeTorque = 0;
            wheel_front_left_col.brakeTorque = 0;
            wheel_front_right_col.brakeTorque = 0;
            Drive();
        }
    }

    void Drive()
    {
        wheel_back_left_col.motorTorque = Input.GetAxis("Vertical") * speed;
        wheel_back_right_col.motorTorque = Input.GetAxis("Vertical") * speed;
        wheel_front_left_tr.Rotate( 0f, 0f,wheel_front_left_col.rpm / 60 * 360 * Time.deltaTime);
        wheel_front_right_tr.Rotate( 0f, 0f, wheel_front_right_col.rpm / 60 * 360 * Time.deltaTime);
        wheel_back_left_tr.Rotate( 0f, 0f,wheel_back_left_col.rpm / 60 * 360 * Time.deltaTime);
        wheel_back_right_tr.Rotate( 0f, 0f, wheel_back_right_col.rpm / 60 * 360 * Time.deltaTime);
    }

    void Steer()
    {
        steerAng = _steerAngle * Input.GetAxis("Horizontal");
        wheel_front_left_col.steerAngle = steerAng;
        wheel_front_right_col.steerAngle = steerAng;
    }

    void UpdateWheelPos(WheelCollider col, Transform tr)
    {
        Vector3 pos = tr.position;
        Quaternion rot = tr.rotation;

        col.GetWorldPose(out pos, out rot);
        tr.position = pos;
        tr.rotation = rot * Quaternion.Euler(0f, 90f, 0f);
    }

}
