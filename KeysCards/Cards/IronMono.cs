using System;
using ModdingUtils.MonoBehaviours;
using System.Collections.Generic;
using UnityEngine;

namespace KeysCards.Cards
{
	public class IronMono : MonoBehaviour
	{
		private void Start()
		{
			this.player = base.GetComponent<Player>();
			ModdingUtils.Utils.Cards.instance.RemoveCardFromPlayer(player, ModdingUtils.Utils.Cards.instance.GetCardWithName("Metamorphosis"), ModdingUtils.Utils.Cards.SelectionType.Newest);
			Destroy(this);
		}

		private Player player;
	}
}
