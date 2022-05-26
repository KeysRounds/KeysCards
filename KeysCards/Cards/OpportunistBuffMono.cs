using System;
using ModdingUtils.MonoBehaviours;
using UnityEngine;

namespace KeysCards.Cards
{
	public class OpportunistBuffMono : ReversibleEffect
	{
		public override void OnStart()
		{
			percHealth = (this.player.data.health - this.player.data.maxHealth * 0.2f) / (this.player.data.maxHealth * 0.8f);
            if (percHealth < 0)
            {
				percHealth = 0f;
            }
			
			this.characterStatModifiersModifier.movementSpeed_mult *= (1f - percHealth) * 0.4f + 1f;
			this.gunAmmoStatModifier.reloadTimeMultiplier_mult *= (percHealth) * 0.5f + 0.5f;
		}
		public override void OnOnDisable()
		{
			Destroy();
		}

		public float percHealth;
	}
}
