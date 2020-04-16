using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Consumables
{
    public class SlimeForecast : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slime Forecast");
            Tooltip.SetDefault("Summons a Slime Rain");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.maxStack = 30;
            item.rare = 7;
            item.useTime = 17;
            item.useAnimation = 17;
            item.useStyle = 2;
            item.consumable = true;
            item.value = 100 * 5;
        }

        public override bool UseItem(Player player)
        {
            if (!Main.slimeRain)
            {
                Main.slimeWarningTime = Main.slimeWarningDelay = 1;
                NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
                Main.PlaySound(SoundID.Roar, player.position, 0);
                Main.StartSlimeRain();
                return true;
            }
            else
                return false;
        }

        public override bool CanUseItem(Player player)
        {
            if(!Main.slimeRain && player.statLifeMax >= 140 && player.statDefense >= 8)
                return true;
            else
                return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Gel, 100);
            recipe.AddIngredient(ItemID.Cloud, 10);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}