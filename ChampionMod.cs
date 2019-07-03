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

        group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " World Evil Guns", new int[]
        {
            ItemID.Musket,
            ItemID.TheUndertaker
        });
        RecipeGroup.RegisterGroup("ChampionMod:WorldEvilGuns", group);

        group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Tier 1 Bars", new int[]
        {
            ItemID.CopperBar,
            ItemID.TinBar
        });
        RecipeGroup.RegisterGroup("ChampionMod:Tier1Bars", group);

        group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Tier 3 Bars", new int[]
        {
            ItemID.SilverBar,
            ItemID.TungstenBar
        });
        RecipeGroup.RegisterGroup("ChampionMod:Tier3Bars", group);

         group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Tier 4 Bars", new int[]
        {
            ItemID.GoldBar,
            ItemID.PlatinumBar
        });
        RecipeGroup.RegisterGroup("ChampionMod:Tier4Bars", group);

        group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Tier 4 Bar Bows", new int[]
        {
            ItemID.GoldBow,
            ItemID.PlatinumBow
        });
        RecipeGroup.RegisterGroup("ChampionMod:Tier4BarBows", group);

        group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Evil Flamethrowers", new int[]
        {
            ItemType("Ichorthrower"),
            ItemType("Cursedthrower")
        });
        RecipeGroup.RegisterGroup("ChampionMod:EvilFlamethrowers", group);
        }
    }
}