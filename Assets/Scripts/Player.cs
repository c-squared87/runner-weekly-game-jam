using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] GameObject player_prefab;
    Vector2 initLocation;

    [SerializeField] GameObject[] splats;
    [SerializeField] float jumpForce;
    [SerializeField] float moveSpeed;

    [SerializeField] float impactModifier = 1;

    Rigidbody2D rb;

    bool hit = false;
    bool canJump;
    bool doubleJump;
    // bool grounded;

    bool isGrounded = false;
    public Transform GroundCheck1; // Put the prefab of the ground here
    public LayerMask groundLayer; // Insert the layer here.

    private void Start () {
        initLocation = transform.position;

        rb = GetComponent<Rigidbody2D> ();
        rb.freezeRotation = true;
    }

    private void OnEnable () {
        FindObjectOfType<CameraFollow> ().SetTarget (this);
    }

    private void Update () {
        if (Input.GetKeyDown (KeyCode.Space)) {
            if (!hit && canJump) {
                Jump ();
            }
        }
        if (Input.GetKeyDown (KeyCode.P)) {
            if (Time.timeScale == 1) {
                Time.timeScale = 0;
            } else {
                Time.timeScale = 1;
            }
        }
    }

    private void FixedUpdate () {

        isGrounded = Physics2D.OverlapCircle (GroundCheck1.position, 0.15f, groundLayer); // checks if you are within 0.15 position in the Y of the ground

        if (isGrounded) {
            canJump = true;
            doubleJump = false;
        }

        if (!hit) {
            Vector2 _vel = rb.velocity;
            _vel.x = 2 * moveSpeed;
            rb.velocity = _vel;
        }
        if (rb.velocity.y < 0) {
            rb.gravityScale = 2.5f;
        } else {
            rb.gravityScale = 1;
        }
    }

    private void OnCollisionEnter2D (Collision2D other) {

        // Debug.Log (other.collider.gameObject.layer);
        if (other.collider.gameObject.layer == 8) {
            if (hit) {
                GenerateSplat ();
            }
        }

        if (other.collider.gameObject.tag == "Wall") {
            KillPlayer ();
        }
    }

    private void KillPlayer () {

        FindObjectOfType<CameraFollow> ().ClearTarget ();

        hit = true;

        EventsManager.PlayerHit ();

        GenerateSplat ();

        rb.freezeRotation = false;
        rb.velocity = Vector3.zero;

        rb.AddForce (new Vector2 (-3.5f, 2.25f) * impactModifier, ForceMode2D.Impulse);
        rb.AddTorque (2 * impactModifier, ForceMode2D.Impulse);

        StartCoroutine (Next ());
    }

    IEnumerator Next () {
        Destroy (gameObject, 1.1f);

        yield return new WaitForSeconds (1f);

        GameObject _player_clone = Instantiate (player_prefab, initLocation, Quaternion.Euler (Vector3.zero));
        _player_clone.name = "Player";

        this.enabled = false;
    }

    // TODO: I DONT KNOW THIS IS FUCKED UP SOMEHOW.
    void Jump () {

        if (doubleJump == false) {
            rb.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
            // if (doubleJump) {
            //     canJump = false;
            // }
            doubleJump = true;
            Debug.Log ("Jump 1 called" + canJump + doubleJump);
            return;
        }
        // Debug.Log ("Jump 2 called" + isGrounded + canJump + doubleJump);
        // rb.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
        // canJump = false;
        // return;
    }

    void GenerateSplat () {
        int _rand = UnityEngine.Random.Range (0, splats.Length);
        Instantiate (splats[_rand], transform.position, Quaternion.identity);
        EventsManager.PlayerHit ();
    }
}