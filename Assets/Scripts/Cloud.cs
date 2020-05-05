using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

    [SerializeField] float x_min;
    [SerializeField] float x_max;

    [SerializeField] float moveSpeed;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        transform.Translate (Vector2.left * moveSpeed * Time.deltaTime);
        if (transform.position.x <= x_min) {
            Vector2 _newPos = transform.position;
            _newPos.x = x_max;
            transform.position = _newPos;
        }
    }
}