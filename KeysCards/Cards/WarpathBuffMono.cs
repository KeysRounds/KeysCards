using System;
using ModdingUtils.MonoBehaviours;
using UnityEngine;

namespace KeysCards.Cards
{
	public class WarpathBuffMono : ReversibleEffect
	{
		public override void OnStart()
		{
			movespeed = this.player.data.stats.movementSpeed;
			if (movespeed > 1)
            {
				this.gunStatModifier.damage_mult *= (movespeed - 1f) * 1.3f + 1f;
			}
		}

		public override void OnOnDisable()
		{
			Destroy();
		}

		public float movespeed;

	}
}
