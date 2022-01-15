using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    [SerializeField] private float _SensitivityX, _SensitivityY;
    private float _RotationX, _RotationY;

    // Update is called once per frame
    void Update()
    {
        float m_RotX = Input.GetAxis("Mouse X") * _SensitivityX;
        float m_RotY= -Input.GetAxis("Mouse Y") * _SensitivityY;


        _RotationX += m_RotX *Time.deltaTime;
        _RotationY += m_RotY *Time.deltaTime;

        Quaternion localRotation = Quaternion.Euler(_RotationY, _RotationX, 0.0f);

        transform.localRotation = localRotation;
    }





    private void Start()
    {

    }
}
