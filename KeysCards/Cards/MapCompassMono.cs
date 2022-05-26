using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnboundLib;
using UnityEngine;

namespace KeysCards.Cards
{
	public class MapCompassMono : MonoBehaviour
	{
		// Token: 0x06000042 RID: 66 RVA: 0x00002A28 File Offset: 0x00000C28
		private void Start()
		{
			this.player = base.GetComponent<Player>();
			this.gun = base.GetComponent<Gun>();
		}

		public void checkCards()
        {
			if (compass >= 1 && maps >= 1)
            {
				CardInfo addedCard = CardCheck.getTreasure();
				ModdingUtils.Utils.Cards.instance.AddCardToPlayer(player, addedCard, addToCardBar: true);
				ModdingUtils.Utils.CardBarUtils.instance.ShowAtEndOfPhase(player, addedCard);
				compass--;
				maps--;
			}
        }

		public int compass;

		public int maps;

		private Player player;

		private Gun gun;
	}
}
