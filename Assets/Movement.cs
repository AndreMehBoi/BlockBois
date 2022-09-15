using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1;
    public float Rotate = 100;
    public float jumpforce = 7;   
    private Vector3 spawnpos;
    private bool isgrounded = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.Confined;
    
        spawnpos = this.transform.localPosition;
    }

    public void respawn()
    {
        this.transform.localPosition = spawnpos;
        this.transform.localEulerAngles = Vector3.zero;
    }

    void Update()
    {
        moveforward();
        movebackward();
        moveright();
        moveleft();
        movejump();
        lookup();
        turn();
        sprint();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Floor")
        {
            Debug.Log("on");
            isgrounded = true;
        }    
    }
    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.name == "Floor")
        {
            Debug.Log("off");
            isgrounded = false;
        }    
    }


    private void movejump()
    {
        if (isgrounded && Input.GetKey(KeyCode.Space))
        {
            Debug.Log("jump");
            isgrounded = false;
            this.GetComponent<Rigidbody>().AddForce(this.transform.up * jumpforce, ForceMode.Impulse);
        }

    }

    private void moveleft()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 deltaPosition = this.transform.right * speed * Time.deltaTime;
            this.transform.localPosition -= deltaPosition;
        }

    }


    private void moveright()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 deltaPosition = this.transform.right * speed * Time.deltaTime;
            this.transform.localPosition += deltaPosition;
        }

    }


    private void movebackward()
    {
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 deltaPosition = this.transform.forward * speed * Time.deltaTime;
            this.transform.localPosition -= deltaPosition;
        }

    }

    private void moveforward()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 deltaPosition = this.transform.forward * speed * Time.deltaTime;
            this.transform.localPosition += deltaPosition;
        }

    }

    private void turn()
    {
        float deltaMouse = Input.GetAxis("Mouse X");
        this.transform.Rotate(this.transform.up,deltaMouse * Rotate,Space.World);
    }
    private void lookup()
    {
        float deltaMouse = -Input.GetAxis("Mouse Y");
        this.transform.Rotate(this.transform.right,deltaMouse * Rotate,Space.World);
    }

    private void sprint()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed * 2;   
        }
        
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed / 2;
        }
    }
}