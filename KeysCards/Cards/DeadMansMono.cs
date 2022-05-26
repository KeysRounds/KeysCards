using System;
using ModdingUtils.MonoBehaviours;
using System.Collections.Generic;
using UnityEngine;

namespace KeysCards.Cards
{
	public class DeadMansMono : MonoBehaviour
	{
		private void Start()
		{
			this.player = base.GetComponent<Player>();
		}

		public void Update()
		{
			if (Time.time >= this.startTime + this.updateDelay)
			{
				if (strength < 30)
                {
					strength++;
				}
                else
                {
					strength = 30;
                }
				
				this.ResetTimer();
				if (GetComponent<Player>().GetComponent<DeadMansBuffMono>() != null)
				{
					GetComponent<Player>().GetComponent<DeadMansBuffMono>().Destroy();
				}
				DeadMansBuffMono dmbm = GetComponent<Player>().transform.gameObject.AddComponent<DeadMansBuffMono>();
				dmbm.strength = strength;
			}
			if (!this.player.data.weaponHandler.gun.IsReady())
			{
				if (GetComponent<Player>().GetComponent<DeadMansBuffMono>() != null)
				{
					GetComponent<Player>().GetComponent<DeadMansBuffMono>().Destroy();
					strength = 0;
				}
			}
		}

		private void ResetTimer()
		{
			this.startTime = Time.time;
		}

		private float strength;

		private Player player;

		private readonly float updateDelay = 0.1f;

		public float startTime = Time.time;
	}
}
