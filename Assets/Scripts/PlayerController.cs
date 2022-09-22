using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed;
    public float rotationspeed;
    private Rigidbody bombRb;
    public GameObject[] bomb;
    private Animator playerAnim;
    GameObject bombPrefab,bombPrefab1;
    int bombCount,multiBombCount,stickyBombCount;
    public bool multiBomb,stickyBomb;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        bombCount = 0;
        multiBombCount = 0;
        multiBomb = false;
        stickyBomb = false;
    }

    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward*verticalInput * Time.deltaTime * speed);
        transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * rotationspeed);
        bombCount = GameObject.FindGameObjectsWithTag("Bomb").Length;
        multiBombCount= GameObject.FindGameObjectsWithTag("Multi Bomb").Length;
        stickyBombCount = GameObject.FindGameObjectsWithTag("Sticky Bomb").Length;

        if (Input.GetKeyDown(KeyCode.Space)&&bombCount==0&&!multiBomb&&!stickyBomb)
        {
            bombPrefab = Instantiate(bomb[0], transform.position + new Vector3(0, 3.7f, 0), bomb[0].transform.rotation);
            bombPrefab.GetComponent<Rigidbody>().AddForce((transform.up+transform.forward) * 5, ForceMode.Impulse);
        }

        if(Input.GetKeyDown(KeyCode.Space) && multiBombCount == 0 &&multiBomb)
        {
            bombPrefab = Instantiate(bomb[1], transform.position + new Vector3(0, 3.7f, 0), bomb[1].transform.rotation);
            bombPrefab1 = Instantiate(bomb[1], transform.position + new Vector3(0, 3.7f, 0), bomb[1].transform.rotation);
            bombPrefab.GetComponent<Rigidbody>().AddForce((transform.up + transform.forward) * 5, ForceMode.Impulse);
            bombPrefab1.GetComponent<Rigidbody>().AddForce((transform.up + transform.forward) * 5, ForceMode.Impulse);
            StartCoroutine(PowerUpCountDown());
        }
        if (Input.GetKeyDown(KeyCode.Space) && stickyBombCount == 0  && stickyBomb)
        {
            bombPrefab = Instantiate(bomb[2], transform.position + new Vector3(0, 3.7f, 0), bomb[2].transform.rotation);
            bombPrefab1 = Instantiate(bomb[2], transform.position + new Vector3(0, 3.7f, 0), bomb[2].transform.rotation);
            bombPrefab.GetComponent<Rigidbody>().AddForce( transform.forward * 10, ForceMode.Impulse);
            bombPrefab1.GetComponent<Rigidbody>().AddForce( transform.forward * 10, ForceMode.Impulse);
            StartCoroutine(StickyPowerUpCountDown());
        }

        playerAnim.SetFloat("Speed_f", verticalInput);

    }
    IEnumerator PowerUpCountDown()
    {
        yield return new WaitForSeconds(8);
        multiBomb = false;
    }
    IEnumerator StickyPowerUpCountDown()
    {
        yield return new WaitForSeconds(8);
        stickyBomb = false;
    }
}
