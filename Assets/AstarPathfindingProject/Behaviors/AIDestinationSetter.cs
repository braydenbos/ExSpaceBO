using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Pathfinding {
	[UniqueComponent(tag = "ai.destination")]
	public class AIDestinationSetter : VersionedMonoBehaviour
	{
		public string targettag = "Player";
		public string prefframe;
		public Transform target;
		IAstarAI ai;

		void OnEnable () {
			ai = GetComponent<IAstarAI>();
			if (ai != null) ai.onSearchPath += Update;
		}

		void OnDisable () {
			if (ai != null) ai.onSearchPath -= Update;
		}

		/// <summary>Updates the AI's destination every frame</summary>
		void Update () {
			AIPath movement = gameObject.GetComponent<AIPath>();
			target = GameObject.FindGameObjectWithTag(targettag).GetComponent<Transform>();
			if (targettag != prefframe)
            {
				if (targettag == "Player")
				{
					movement.maxSpeed /= 2;

				}
				else
				{
					movement.maxSpeed *= 2;
				}

			}
			prefframe = targettag;
			if (target != null && ai != null) ai.destination = target.position;
		}
	}
}
