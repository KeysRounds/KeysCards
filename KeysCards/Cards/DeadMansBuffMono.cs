using System;
using ModdingUtils.MonoBehaviours;
using UnityEngine;

namespace KeysCards.Cards
{
	public class DeadMansBuffMono : ReversibleEffect
	{
		public override void OnStart()
		{
			this.gunStatModifier.damage_mult *= 1f + strength * 0.01f * CardCheck.Amount(player, "Dead Mans Boots");
			this.characterStatModifiersModifier.movementSpeed_mult = 1f + strength * 0.00666667f * CardCheck.Amount(player, "Dead Mans Boots");
		}
		public override void OnOnDisable()
		{
			Destroy();
		}

		public float strength;

	}
}
