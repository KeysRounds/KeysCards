using System.Collections.Generic;
using UnityEngine;

namespace KeysCards
{
    class CardCheck : MonoBehaviour
    {
        public static int Amount(Player player, string cardName)
        {
			List<CardInfo> currentCards = player.data.currentCards;
			int cardAmount = 0;
			for (int i = currentCards.Count - 1; i >= 0; i--)
			{
				if (currentCards[i].cardName == cardName)
				{
					cardAmount++;
				}
			}
			return cardAmount;
		}

		public static CardInfo getTreasure()
        {
			int randonum = UnityEngine.Random.Range(0, 5);
			switch (randonum)
            {
				case 0:
					return ModdingUtils.Utils.Cards.instance.GetCardWithName("Giants Gauntlet");
				case 1:
					return ModdingUtils.Utils.Cards.instance.GetCardWithName("Dead Mans Boots");
				case 2:
					return ModdingUtils.Utils.Cards.instance.GetCardWithName("Grovetenders Shield");
				case 3:
					return ModdingUtils.Utils.Cards.instance.GetCardWithName("Yvrells Staff");
				case 4:
					return ModdingUtils.Utils.Cards.instance.GetCardWithName("Pickpockets Dagger");
				default:
					return null;
			}
		}
    }
}
