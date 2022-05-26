using System;
using System.Collections;
using System.Linq;
using ModdingUtils.MonoBehaviours;
using UnityEngine;
using UnboundLib.Cards;

namespace KeysCards.Cards
{
	public class VirusMono : MonoBehaviour
	{
		public void Start()
        {
			this.player = base.GetComponent<Player>();
			int cardsExist = player.data.currentCards.Count;
			ModdingUtils.Utils.Cards.instance.RemoveAllCardsFromPlayer(player);
			//fix this it is so bad my man
			for (int i = cardsExist - 1; i >= 0; i--)
			{
				ModdingUtils.Utils.Cards.instance.AddCardToPlayer(player, ModdingUtils.Utils.Cards.instance.GetCardWithName("Virus"), false, "", 2f, 2f);
			}
			ModdingUtils.Utils.CardBarUtils.instance.ShowAtEndOfPhase(player, ModdingUtils.Utils.Cards.instance.GetCardWithName("Virus"));

			Destroy(this, 0.1f);
		}

		Player player;
	}
}
