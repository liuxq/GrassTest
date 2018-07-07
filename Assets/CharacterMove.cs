using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {
    public float Speed = 1;
    private CharacterController cc;
	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
		if(v != 0 || h != 0)
        {
            Vector3 forward = Camera.main.transform.forward;
            Vector3 right = Camera.main.transform.right;
            Vector3 dir = forward * v + right * h;
            dir.y = 0;
            dir = dir.normalized;

            cc.Move(new Vector3(dir.x, 0, dir.z) * Time.deltaTime * Speed);
            Shader.SetGlobalVector("_Player1Pos", transform.position);
        }
	}

    
}
