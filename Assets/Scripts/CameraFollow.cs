using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    Player target;

    [SerializeField] float x_offset;
    [SerializeField] float y_offset;

    [SerializeField] float moveSpeed;

    public void SetTarget (Player _target) {
        target = null;
        target = _target;
    }

    public void ClearTarget () {
        target = null;
    }

    private void LateUpdate () {
        Vector3 _pos;

        if (target != null) {
            _pos = target.transform.position;
        } else {
            _pos = Vector3.zero;
        }

        _pos.z = -10;
        _pos.y = y_offset;
        _pos.x += x_offset;

        float step = moveSpeed * Time.deltaTime; // calculate distance to move

        transform.position = Vector3.MoveTowards (transform.position, _pos, step);
    }
}