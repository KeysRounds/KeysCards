using System;
using ModdingUtils.MonoBehaviours;
using UnityEngine;

namespace KeysCards.Cards
{
	public class SnipersNestBuffMono : ReversibleEffect
	{
		public override void OnStart()
		{
			ammoNorm = this.gunAmmo.maxAmmo;

			this.block.additionalBlocks = ammoNorm;
			this.gunStatModifier.damage_add = ((0.135f * (ammoNorm-1f)));
			this.gunAmmoStatModifier.maxAmmo_add = -this.gunAmmo.maxAmmo + 1;
		}

		public override void OnOnDisable()
		{
			Destroy();
		}

		public void OnDestroy()
		{
			
		}
		public float asBonus;
		public int ammoNorm;
	}
}
