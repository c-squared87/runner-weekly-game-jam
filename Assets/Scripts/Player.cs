using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] GameObject[] splats;
    [SerializeField] float jumpForce;
    [SerializeField] float moveSpeed;

    Rigidbody2D rb;

    private void Start () {
        rb = GetComponent<Rigidbody2D> ();
    }

    private void Update () {
        if (Input.GetKeyDown (KeyCode.Space)) {
            Jump ();
        }
    }

    private void FixedUpdate () {
        rb.velocity = new Vector2 (1, 0) * moveSpeed;
    }

    private void OnCollisionEnter2D (Collision2D other) {
        if (other.collider.gameObject.tag == "Wall") {
            GenerateSplat ();
            rb.freezeRotation = false;
            rb.AddForce (new Vector2 (-3, 1.25f) * 3, ForceMode2D.Impulse);
            this.enabled = false;
        }
    }

    void Jump () {
        rb.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void GenerateSplat () {
        int _rand = UnityEngine.Random.Range (0, splats.Length);
        Instantiate (splats[_rand], transform.position, Quaternion.identity);
    }
}