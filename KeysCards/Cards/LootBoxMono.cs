using System;
using ModdingUtils.MonoBehaviours;
using UnityEngine;

namespace KeysCards.Cards
{
	public class LootBoxMono : MonoBehaviour
	{

		public void Update()
		{
			if (Time.time >= this.startTime + this.updateDelay)
			{
				this.ResetTimer();
				if (GetComponent<Player>().GetComponent<OpportunistBuffMono>() != null)
                {
					GetComponent<Player>().GetComponent<OpportunistBuffMono>().Destroy();

				}
				GetComponent<Player>().transform.gameObject.AddComponent<OpportunistBuffMono>();
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
