using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 MovingDirection;
    Transform t;
    Animator animator;
    //NavMesh
    private int degree = 0;
    public int jumpf = 25000;
    [SerializeField] float movingSpeed = 5f;
    bool onGround = false, run = false;
    //int vertical;
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
        animator = GetComponent<Animator>();
        //t.position = Vector3.one;//(1, 1, 1)
        animator.SetBool("Run", run);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Viking_Axes")
        {
            SceneManager.LoadScene(3);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            run = true;
            animator.SetBool("Run", run);
        }
        
    }
}
