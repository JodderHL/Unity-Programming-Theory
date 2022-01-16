using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private GameObject _ShotPrefab;
    [SerializeField] private float _SensitivityX, _SensitivityY;
    private float _RotationX, _RotationY;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.IsGameActive)
        {
            float m_RotX = Input.GetAxis("Mouse X") * _SensitivityX;
            float m_RotY = -Input.GetAxis("Mouse Y") * _SensitivityY;


            _RotationX += m_RotX * Time.deltaTime;
            _RotationY += m_RotY * Time.deltaTime;

            Quaternion localRotation = Quaternion.Euler(_RotationY, _RotationX, 0.0f);

            transform.localRotation = localRotation;


            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Fire();
            }
        }

    }


    private void Fire()
    {
        GameObject m_Shot = Instantiate(_ShotPrefab);
        m_Shot.transform.position = transform.position;
        Quaternion m_Rotation = transform.rotation;
        m_Rotation.eulerAngles = new Vector3(m_Rotation.eulerAngles.x+90, m_Rotation.eulerAngles.y, m_Rotation.eulerAngles.z);
        m_Shot.transform.rotation = m_Rotation;
        m_Shot.GetComponent<Shot>().Launch();

    }


    private void Start()
    {

    }
}
