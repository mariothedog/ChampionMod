using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace ChampionMod
{
	class ChampionMod : Mod
	{
		public ChampionMod()
		{
		}

		public override void AddRecipeGroups()
        {
            RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Tier 2 Broadswords", new int[]
            {
                    ItemID.LeadBroadsword,
                    ItemID.IronBroadsword
            });
            RecipeGroup.RegisterGroup("ChampionMod:Tier2Broadswords", group);

            RecipeGroup group2 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " World Evil Guns", new int[]
            {
                    ItemID.Musket,
                    ItemID.TheUndertaker
            });
            RecipeGroup.RegisterGroup("ChampionMod:WorldEvilGuns", group2);
        }
	}
}
