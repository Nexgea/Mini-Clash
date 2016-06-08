using UnityEngine;
using System.Collections;

public class SwimAnimations : MonoBehaviour {
    public Animator animator;
    public GameObject graphic;
    public float speed;
    private Vector3 oldPosition;
	// Use this for initialization
	void Start () {
        graphic = transform.GetChild(0).gameObject;
        animator = graphic.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        speed = Vector3.Distance(oldPosition, transform.position);
        oldPosition = transform.position;
        animator.SetFloat("speed", speed);
	}
    public void Tempo()
    {
        animator.SetTrigger("MakeTempo");
    }
    public void Jump ()
    {
        animator.SetTrigger("Jump");
    }
}
