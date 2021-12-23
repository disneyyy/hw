using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collision))]
[RequireComponent(typeof(Animator))]
public class VikingController : MonoBehaviour
{
    public Vector3 MovingDirection;
    MeshRenderer mr;
    Transform t;
    Rigidbody rb;
    Animator animator;
    //NavMesh
    private int degree = 0;
    public int jumpf = 25000;
    [SerializeField] float movingSpeed = 10f;
    bool onGround = false, run = false;
    void Awake()
    {
        //Debug.Log("Awake");
    }
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start");
        run = false;
        t = GetComponent<Transform>();
        mr = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        //t.position = Vector3.one;//(1, 1, 1)
        animator.SetBool("Run", run);

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update");
        //run = false;
        //mr.material.color = new Color(255f, (int)Time.time % 2 * 255f, 255f);
        //Debug.Log("11111111111111");
        if (Input.GetKeyDown(KeyCode.W))
        {
            run = true;
        }
        float vertical;
        //Debug.Log("{0}",vertical);
        vertical = transform.localPosition.y;
        if (run)
        {
            
            if (vertical < 100.0) Debug.Log("45646584654");
            degree %= 4;
            if (Input.GetKeyDown(KeyCode.Space) && vertical < 1 && vertical > -1)
            {
                Debug.Log("jump");
                rb.AddForce(jumpf * Time.deltaTime * Vector3.up);
            }
            if (degree < 0) degree += 4;
            if (Input.GetKeyDown(KeyCode.A))//left
            {
                Debug.Log("11111111111111");
                transform.Rotate(new Vector3(0f, -90f, 0f));
                degree--;
            }
            else if (Input.GetKeyDown(KeyCode.D))//right
            {
                transform.Rotate(new Vector3(0f, 90f, 0f));
                degree++;
            }
            if (degree == 0)//forward
            {
                transform.localPosition += movingSpeed * Time.deltaTime * Vector3.forward;//forward(0, 0, 1)
            }
            else if (degree == 1)//right
            {
                transform.localPosition += movingSpeed * Time.deltaTime * Vector3.right;//forward(0, 0, 1)
            }
            else if (degree == 2)
            {//back
                transform.localPosition += movingSpeed * Time.deltaTime * Vector3.back;//forward(0, 0, 1)
            }
            else transform.localPosition += movingSpeed * Time.deltaTime * Vector3.left;//forward(0, 0, 1)
            animator.SetBool("Run", run);
        }
        if(vertical < -30)
        {
            SceneManager.LoadScene(0);
        }
    }
    
}
