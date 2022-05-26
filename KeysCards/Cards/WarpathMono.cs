using System;
using ModdingUtils.MonoBehaviours;
using UnityEngine;

namespace KeysCards.Cards
{
	public class WarpathMono : MonoBehaviour
	{

		public void Update()
		{
			if (Time.time >= this.startTime + this.updateDelay)
			{
				this.ResetTimer();
				if (GetComponent<Player>().GetComponent<WarpathBuffMono>() != null)
                {
					GetComponent<Player>().GetComponent<WarpathBuffMono>().Destroy();
				}
				GetComponent<Player>().transform.gameObject.AddComponent<WarpathBuffMono>();
			}
		}

		private void ResetTimer()
		{
			this.startTime = Time.time;
		}

		private readonly float updateDelay = 0.1f;

		public float startTime = Time.time;

		public WarpathBuffMono prevBuff;

		public float movespeed;

		public float bonusDmg = 1000;
	}
}
