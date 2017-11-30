using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingAgent : Agent {

	public float speed = 1f;

	public override List<float> CollectState()
	{
		List<float> state = new List<float>();
		state.Add(gameObject.transform.rotation.x);
		state.Add(gameObject.transform.rotation.z);
		return state;
	}

	public override void AgentStep(float[] act)
	{
		if (brain.brainParameters.actionSpaceType == StateType.continuous) {
			float xrotate = act[0];
			float zrotate = act[1];
			// float zmove = act[2];
			// float xmove = act[3];
			Rigidbody r = gameObject.GetComponent<Rigidbody>();

			if (zrotate != 0) {
				r.MovePosition(r.position + new Vector3(0, 0, zrotate * speed));
				r.AddForce(new Vector3(0, 0, zrotate * 10), ForceMode.Force);
			}
			if (xrotate != 0) {
				r.MovePosition(r.position + new Vector3(0, -xrotate * speed, 0));
				r.AddForce(new Vector3(0, -xrotate * 10, 0), ForceMode.Force);
			}
			
			// if ((gameObject.transform.rotation.x < 0.25f && xrotate > 0f) ||
            //     (gameObject.transform.rotation.x > -0.25f && xrotate < 0f))
            // {
            //     gameObject.transform.Rotate(new Vector3(1, 0, 0), xrotate * speed);
			// 	// gameObject.GetComponent<Rigidbody>().MoveRotation(Quaternion.)
            // }
			// if ((gameObject.transform.rotation.z < 0.25f && zrotate > 0f) ||
            //     (gameObject.transform.rotation.z > -0.25f && zrotate < 0f))
            // {
            //     gameObject.transform.Rotate(new Vector3(0, 0, 1), zrotate * speed);
            // }
			// if (!done) reward = 0.1f;
		}

		// if ((myPong.transform.position.y - gameObject.transform.position.y) < -0.5f ||
        //     Mathf.Abs(myPong.transform.position.x - gameObject.transform.position.x) > 1f ||
        //     Mathf.Abs(myPong.transform.position.z - gameObject.transform.position.z) > 1f)
        // {
        //     done = true;
        //     reward = -1f;
        // }
	}

	public override void AgentReset()
	{

	}

	public override void AgentOnDone()
	{

	}
}
