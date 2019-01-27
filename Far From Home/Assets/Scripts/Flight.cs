using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Flight : MonoBehaviour {

    [Header("Ship Settings")]
    public float forwardSpeed = 20f;
    public float horizontaSpeed = 20f;
    public float horizontalAcceleration = 0.1f;
    float horizontalVelocity;
    public float playareaWidth = 14f;
    bool dead = false;
    float fade = 1;

    [Header("Laser Settings")]
    public GameObject laserPrefab;
    public float laserSpeed = 40f;
    public float weaponCooldownTime = 0.1f;
    float weapoonLastFireTime;

    [Header("Level Settings")]
    public Vector3 startPos = new Vector3 (0,0,-1000);
    public Vector3 endPos = new Vector3 (0,0,-100);
    float levelProgressPercent = 0;

    [Header("Other")]
    Transform player;
    Transform playerModel;
    ParticleSystem explosion;
    Animator animator;
    AsteroidSpawn asteroidSpawner;
    public Image fadePanel;
    Color fadeColour;

    void Start ()
    {
        fadeColour = new Color(1, 0, 0, 0);
        player = transform.GetChild(0);
        playerModel = player.GetChild(0);
        explosion = player.GetChild(1).GetComponent<ParticleSystem>();
        animator = playerModel.GetComponent<Animator>();
        asteroidSpawner = GetComponent<AsteroidSpawn>();
    }
	
	void Update ()
    {
        if (!dead) {

            Move();

            if (Input.GetButton("Fire") && Time.time - weapoonLastFireTime > weaponCooldownTime)
            {
                GameObject laser = Instantiate(laserPrefab, playerModel.transform.position + new Vector3(1, 0, 0), transform.rotation);
                GameObject laser2 = Instantiate(laserPrefab, playerModel.transform.position + new Vector3(-1, 0, 0), transform.rotation);
                laser.GetComponent<Laser>().laserSpeed = laserSpeed;
                laser2.GetComponent<Laser>().laserSpeed = laserSpeed;
                laser.transform.Rotate(Vector3.right * 90);
                laser2.transform.Rotate(Vector3.right * 90);
                Destroy(laser, 30f);
                Destroy(laser2, 30f);
                weapoonLastFireTime = Time.time;
            }

            fadeColour -= new Color(-0.05f, 0, 0, 0);
        } else
        {
            fadeColour += new Color(0.05f, 0, 0, 0);
        }
        if (levelProgressPercent >= 100)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        fadePanel.color = fadeColour;
    }

    void Move ()
    {    
        if (Input.GetAxisRaw("Horizontal") == 1 && player.position.x < playareaWidth)
        {
            horizontalVelocity = Mathf.Lerp(horizontalVelocity, horizontaSpeed, horizontalAcceleration);
            animator.SetBool("Right", true);
            animator.SetBool("Left", false);
        }
        else if (Input.GetAxisRaw("Horizontal") == -1 && player.position.x > -playareaWidth)
        {
            horizontalVelocity = Mathf.Lerp(horizontalVelocity, -horizontaSpeed, horizontalAcceleration);
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
        } else
        {
            horizontalVelocity = Mathf.Lerp(horizontalVelocity, 0, horizontalAcceleration);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
        }

        player.transform.Translate(new Vector2(horizontalVelocity * Time.deltaTime, 0));
        levelProgressPercent += forwardSpeed * Time.deltaTime;
        transform.position = Vector3.Lerp(startPos, endPos, levelProgressPercent / 100);
    }

    public IEnumerator PlayerDeath()
    {
        if (!dead)
        {
            dead = true;
            Destroy(playerModel.gameObject);
            explosion.Play();

            yield return new WaitForSecondsRealtime(2f);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }     
    }
}
