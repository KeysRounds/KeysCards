using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnboundLib;
using UnityEngine;

namespace KeysCards.Cards
{
	public class ChargeShotMono : MonoBehaviour
	{
		private void Start()
		{
			newCards = null;
			this.player = base.GetComponent<Player>();
		}

		public void Update()
		{
			if (Time.time >= this.startTime + this.updateDelay)
			{
				this.ResetTimer();
				if (Time.time >= this.timeOfLastEffect + this.effectCooldown)
				{
					if (GetComponent<Player>().GetComponent<ChargeShotBuffMono>() == null)
					{
						GetComponent<Player>().transform.gameObject.AddComponent<ChargeShotBuffMono>();
					}
				}
			}
			if (!this.player.data.weaponHandler.gun.IsReady())
			{
				this.ResetEffectTimer();
				if(GetComponent<Player>().GetComponent<ChargeShotBuffMono>() != null)
                {
					GetComponent<Player>().GetComponent<ChargeShotBuffMono>().Destroy();

				}
			}
		}

		private void ResetTimer()
		{
			this.startTime = Time.time;
		}

		private void ResetEffectTimer()
		{
			this.timeOfLastEffect = Time.time;
		}

		private CardInfo[] newCards;

		private float updateDelay = 0.1f;

		private float effectCooldown = 1.75f;

		private float timeOfLastEffect = Time.time;

		private float startTime = Time.time;

		private Player player;
	}
}
