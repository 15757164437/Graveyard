using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.Hearthstone;

namespace HDT.Plugins.Graveyard
{
	public class ResurrectView : NormalView
	{
		private ChancesTracker _chances = new ChancesTracker();

		public static bool isValid()
		{
			return Core.Game.Player.PlayerCardList.FindIndex(card =>
				card.Id == HearthDb.CardIds.Collectible.Priest.Resurrect ||
				card.Id == HearthDb.CardIds.Collectible.Priest.OnyxBishop ||
				card.Id == HearthDb.CardIds.Collectible.Priest.EternalServitude ||
				card.Id == HearthDb.CardIds.Collectible.Priest.LesserDiamondSpellstone ||
                card.Id == HearthDb.CardIds.Collectible.Priest.MassResurrection ||
                card.Id == HearthDb.CardIds.Collectible.Priest.CatrinaMuerte ||
				(Settings.Default.ResurrectKazakus && card.Id == HearthDb.CardIds.Collectible.Neutral.Kazakus)) > -1;
		}

		public ResurrectView()
		{
			// Section Label
			Label.Text = "Resurrect";
		}

		new public bool Update(Card card)
		{
			if (!base.Update(card))
			{
				return false;
			}

			_chances.Update(card, Cards, View);

			return true;
		}
	}
}
