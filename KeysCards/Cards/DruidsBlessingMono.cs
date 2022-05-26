using System;
using ModdingUtils.MonoBehaviours;
using System.Collections.Generic;
using UnityEngine;

namespace KeysCards.Cards
{
	public class DruidsBlessingMono : MonoBehaviour
	{
		private void Start()
		{
			this.player = base.GetComponent<Player>();
		}

		public void Update()
		{
			if (Time.time >= this.startTime + this.updateDelay)
			{
				this.ResetTimer();
				this.player.data.healthHandler.Heal(player.data.maxHealth * (0.08f * CardCheck.Amount(player, "Druids Blessing")));
			}
		}

		private void ResetTimer()
		{
			this.startTime = Time.time;
		}

		private Player player;

		private readonly float updateDelay = 4.5f;

		public float startTime = Time.time;
	}
}
