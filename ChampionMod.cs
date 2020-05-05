using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.UI;
using ChampionMod.UI;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace ChampionMod
{
    class ChampionMod : Mod
    {
        //private GameTime _lastUpdateUIGameTime;

        public static ModHotKey ArmorVanitySwitchHotKey;
        public static ModHotKey AccVanitySwitchHotKey;

        //internal UserInterface MyUserInterface;
        //internal VanitySwitch MyVanitySwitch;

        public static int farmer;
        public static float farmerProjectileRotation;

        public override void Load()
        {
            ArmorVanitySwitchHotKey = RegisterHotKey("Armor Vanity Switch", "V");
            AccVanitySwitchHotKey = RegisterHotKey("Accessory Vanity Switch", "G");

            /*if (!Main.dedServ)
            {
                MyUserInterface = new UserInterface();

                MyVanitySwitch = new VanitySwitch();
                MyVanitySwitch.Activate();
            }*/

            //ShowVanitySwitch();
        }

        public override void Unload()
        {
            //MyVanitySwitch?.Unload();
            //MyVanitySwitch = null;

            ArmorVanitySwitchHotKey = null;
            AccVanitySwitchHotKey = null;
        }

        /*public override void UpdateUI(GameTime gameTime)
        {
            _lastUpdateUIGameTime = gameTime;
            if (MyUserInterface?.CurrentState != null)
            {
                MyUserInterface.Update(gameTime);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int index = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
            if (index != -1)
            {
                layers.Insert(index, new LegacyGameInterfaceLayer("ChampionMod: VanitySwitch",
                    delegate
                    {
                        if (_lastUpdateUIGameTime != null && MyUserInterface?.CurrentState != null)
                        {
                            MyUserInterface.Draw(Main.spriteBatch, _lastUpdateUIGameTime);
                        }

                        return true;
                    },
                    InterfaceScaleType.UI));
            }
        }

        internal void ShowVanitySwitch()
        {
            MyUserInterface?.SetState(MyVanitySwitch);
        }

        internal void HideVanitySwitch()
        {
            MyUserInterface?.SetState(null);
        }*/

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

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Evil Bars", new int[]
            {
                ItemID.DemoniteBar,
                ItemID.CrimtaneBar
            });
            RecipeGroup.RegisterGroup("ChampionMod:EvilBars", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Mythril Bars", new int[]
            {
                ItemID.MythrilBar,
                ItemID.OrichalcumBar
            });
            RecipeGroup.RegisterGroup("ChampionMod:MythrilBars", group);

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

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Magic Mirrors", new int[]
            {
                ItemID.MagicMirror,
                ItemID.IceMirror
            });
            RecipeGroup.RegisterGroup("ChampionMod:MagicMirrors", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Flares", new int[]
            {
                ItemID.Flare,
                ItemID.BlueFlare
            });
            RecipeGroup.RegisterGroup("ChampionMod:Flares", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Tier 4 Bar Swords", new int[]
            {
                ItemID.GoldBroadsword,
                ItemID.PlatinumBroadsword
            });
            RecipeGroup.RegisterGroup("ChampionMod:Tier4BarSwords", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Shadow Scales", new int[]
            {
                ItemID.ShadowScale,
                ItemID.TissueSample
            });
            RecipeGroup.RegisterGroup("ChampionMod:ShadowScales", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Light's Bane", new int[]
            {
                ItemID.LightsBane,
                ItemID.BloodButcherer
            });
            RecipeGroup.RegisterGroup("ChampionMod:LightsBane", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Demon Bow", new int[]
            {
                ItemID.DemonBow,
                ItemID.TendonBow
            });
            RecipeGroup.RegisterGroup("ChampionMod:DemonBow", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Malaise", new int[]
            {
                ItemID.CorruptYoyo,
                ItemID.CrimsonYoyo
            });
            RecipeGroup.RegisterGroup("ChampionMod:Malaise", group);

            group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Vilethorn", new int[]
            {
                ItemID.Vilethorn,
                ItemID.CrimsonRod
            });
            RecipeGroup.RegisterGroup("ChampionMod:Vilethorn", group);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(this);
            recipe.AddRecipeGroup("Wood", 10);
            recipe.AddIngredient(ItemID.Acorn, 1);
            recipe.AddIngredient(ItemID.Torch, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.WandofSparking, 1);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(this);
            recipe2.AddIngredient(ItemType("PrimalCleaver"), 1);
            recipe2.AddIngredient(ItemID.BladeofGrass, 1);
            recipe2.AddIngredient(ItemID.FieryGreatsword, 1);
            recipe2.AddTile(TileID.DemonAltar);
            recipe2.SetResult(ItemID.NightsEdge, 1);
            recipe2.AddRecipe();
        }
    }
}