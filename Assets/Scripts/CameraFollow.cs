using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    Player target;

    public void SetTarget (Player _target) {
        target = null;
        target = _target;
    }

    private void LateUpdate () {
        Vector3 _pos = target.transform.position;
        _pos.z = -10;
        transform.position = _pos;
    }
}