using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongAgent : Agent {

	[Header("Specific to Pong")]
	public GameObject myPong;

	public override void InitializeAgent() {
		
	}
	public override List<float> CollectState()
	{
		List<float> state = new List<float>();
		// state.Add(gameObject.transform.position.x);
		// state.Add(gameObject.transform.position.z);
		state.Add(gameObject.transform.rotation.x);
		state.Add(gameObject.transform.rotation.z);
		state.Add((myPong.transform.position.x - gameObject.transform.position.x) / 5f);
        state.Add((myPong.transform.position.y - gameObject.transform.position.y) / 5f);
        state.Add((myPong.transform.position.z - gameObject.transform.position.z) / 5f);
        state.Add(myPong.transform.GetComponent<Rigidbody>().velocity.x / 5f);
        state.Add(myPong.transform.GetComponent<Rigidbody>().velocity.y / 5f);
        state.Add(myPong.transform.GetComponent<Rigidbody>().velocity.z / 5f);

		return state;
	}

	public override void AgentStep(float[] act)
	{
		if (brain.brainParameters.actionSpaceType == StateType.continuous) {
			float xrotate = act[0];
			float zrotate = act[1];
			// float zmove = act[2];
			// float xmove = act[3];

			if ((gameObject.transform.rotation.x < 0.25f && xrotate > 0f) ||
                (gameObject.transform.rotation.x > -0.25f && xrotate < 0f))
            {
                gameObject.transform.Rotate(new Vector3(1, 0, 0), xrotate);
            }
			if ((gameObject.transform.rotation.z < 0.25f && zrotate > 0f) ||
                (gameObject.transform.rotation.z > -0.25f && zrotate < 0f))
            {
                gameObject.transform.Rotate(new Vector3(0, 0, 1), zrotate);
            }
			if (!done) reward = 0.1f;
		}

		if ((myPong.transform.position.y - gameObject.transform.position.y) < -0.5f ||
            Mathf.Abs(myPong.transform.position.x - gameObject.transform.position.x) > 1f ||
            Mathf.Abs(myPong.transform.position.z - gameObject.transform.position.z) > 1f)
        {
            done = true;
            reward = -1f;
        }
	}

	public override void AgentReset()
	{
		gameObject.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        gameObject.transform.Rotate(new Vector3(1, 0, 0), Random.Range(-10f, 10f));
        gameObject.transform.Rotate(new Vector3(0, 0, 1), Random.Range(-10f, 10f));
        myPong.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        myPong.transform.position = new Vector3(Random.Range(-0.25f, 0.25f), 2f, Random.Range(-0.25f, 0.25f)) + gameObject.transform.position;
	}

	public override void AgentOnDone()
	{

	}
}
