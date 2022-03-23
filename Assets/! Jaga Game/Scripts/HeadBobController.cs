using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobController : MonoBehaviour
{
    public bool _enable = true;

    [SerializeField, Range(0, 0.1f)] private float _amplitude = 0.015f;
    [SerializeField, Range(0, 30)] private float _frequency = 10f;

    [SerializeField] private Transform _camera = null;
    [SerializeField] private Transform _cameraholder = null;

    //private float _toggleSpeed = 3.0f;
    private Vector3 _startPos;
    private PlayerController _controller;
    //private Camera cam;

    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
        //cam = GetComponentInChildren<Camera>();
        _startPos = _camera.localPosition;

        //cam.fieldOfView = 80;
    }

    private void PlayMotion(Vector3 motion)
    {
        _camera.localPosition += motion * Time.deltaTime;
    }

    private void CheckMotion()
    {
        //float speed = new Vector3(_controller.velocity.x, 0, _controller.velocity.z).magnitude;     
        //Debug.Log(speed);
        ResetPosition();

        if (!_controller.isMoving) return;
        if (!_controller.isGrounded) return;

        if (!_controller.isWalking)
        {
            _frequency = 20f;
            //if(cam.fieldOfView != 85)
            //{
            //    cam.fieldOfView++;
            //}
        }
        else
        {
            _frequency = 10f;
            //if (cam.fieldOfView != 80)
            //{
            //    cam.fieldOfView--;
            //}
        }

        PlayMotion(FootStepMotion());
    }

    private Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * _frequency) * _amplitude;
        pos.x += Mathf.Cos(Time.time * _frequency / 2) * _amplitude * 2;
        return pos;
    }

    private void ResetPosition()
    {
        if (_camera.localPosition == _startPos) return;
        _camera.localPosition = Vector3.Lerp(_camera.localPosition, _startPos, 1 * Time.deltaTime);
    }

    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + _cameraholder.localPosition.y, transform.position.z);
        pos += _cameraholder.forward * 15.0f;
        return pos;
    }

    private void Update()
    {
        if (!_enable) return;

        CheckMotion();
        _camera.LookAt(FocusTarget());
    }
}
