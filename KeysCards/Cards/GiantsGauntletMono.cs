using System;
using ModdingUtils.MonoBehaviours;
using System.Collections.Generic;
using UnityEngine;

namespace KeysCards.Cards
{
	public class GiantsGauntletMono : MonoBehaviour
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
				this.player.data.healthHandler.Heal(player.data.maxHealth * 0.004f * CardCheck.Amount(player, "Giants Gauntlet"));
			}
		}

		private void ResetTimer()
		{
			this.startTime = Time.time;
		}

		private Player player;

		private readonly float updateDelay = 0.1f;

		public float startTime = Time.time;
	}
}
