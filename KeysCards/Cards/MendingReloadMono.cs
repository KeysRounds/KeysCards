using System;
using System.Linq;
using System.Runtime.CompilerServices;
using UnboundLib;
using UnityEngine;

namespace KeysCards.Cards
{
	public class MendingReloadMono : MonoBehaviour
	{
		// Token: 0x06000042 RID: 66 RVA: 0x00002A28 File Offset: 0x00000C28
		private void Start()
		{
			this.player = base.GetComponent<Player>();
			this.block = base.GetComponent<Block>();
			this.gun = base.GetComponent<Gun>();
		}

		public void Update()
		{
			if (Time.time >= this.startTime + this.updateDelay)
			{
				this.ResetTimer();
				if (Time.time >= this.timeOfLastEffect + this.effectCooldown && this.player.data.weaponHandler.gun.isReloading)
				{
					if (active == true)
                    {
						this.player.data.healthHandler.Heal(player.data.maxHealth * 0.15f);
						active = false;
					}
					this.ResetEffectTimer();
				}
				if (!this.player.data.weaponHandler.gun.isReloading)
                {
					active = true;
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

		private bool active = true;

		private float updateDelay = 0.1f;

		private float effectCooldown = 2f;

		private float timeOfLastEffect = Time.time;

		private float startTime = Time.time;

		private Player player;

		private Block block;

		private Gun gun;
	}
}
