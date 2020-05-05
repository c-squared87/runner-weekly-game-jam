using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    Player target;

    [SerializeField] float x_offset;
    [SerializeField] float y_offset;

    public void SetTarget (Player _target) {
        target = null;
        target = _target;
    }

    private void LateUpdate () {
        Vector3 _pos = target.transform.position;
        _pos.z = -10;
        _pos.y = y_offset;
        _pos.x += x_offset;
        transform.position = _pos;
    }
}