using System;
using ModdingUtils.MonoBehaviours;
using UnityEngine;

namespace KeysCards.Cards
{
	public class SnipersNestMono : MonoBehaviour
	{

		public void Update()
		{
			if (Time.time >= this.startTime + this.updateDelay)
			{
				this.ResetTimer();
				if (GetComponent<Player>().GetComponent<SnipersNestBuffMono>() != null)
                {
					GetComponent<Player>().GetComponent<SnipersNestBuffMono>().Destroy();
				}
				GetComponent<Player>().transform.gameObject.AddComponent<SnipersNestBuffMono>();
			}
		}

		private void ResetTimer()
		{
			this.startTime = Time.time;
		}

		private readonly float updateDelay = 0.1f;

		public float startTime = Time.time;
	}
}
