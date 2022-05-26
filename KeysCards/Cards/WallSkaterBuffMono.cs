using System;
using ModdingUtils.MonoBehaviours;
using System.Collections.Generic;
using UnityEngine;

namespace KeysCards.Cards
{
	public class WallSkaterBuffMono : ReversibleEffect
	{
		public override void OnStart()
		{
			this.characterStatModifiersModifier.movementSpeed_mult *= 1f + (CardCheck.Amount(player, "Wall Skater") * 0.2f);
			this.characterStatModifiersModifier.jump_mult *= 1.2f;

			this.colorEffect = this.player.gameObject.AddComponent<ReversibleColorEffect>();
			this.colorEffect.SetColor(player.GetTeamColors().color + this.color);
			this.colorEffect.SetLivesToEffect(1);
		}

		public void Update()
		{
			if (player.data.sinceWallGrab >= 0.5f && player.data.isGrounded)
            {
				Destroy();
            }
		}

		public override void OnOnDisable()
		{
			Destroy();
		}
		public void OnDestroy()
		{
			this.colorEffect.Destroy();
		}

		private ReversibleColorEffect colorEffect;

		private readonly Color color = new Color(0.3f, 0f, 0.3f, 0f);

	}

}
