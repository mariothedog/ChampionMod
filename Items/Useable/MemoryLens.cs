using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Useable
{
    public class MemoryLens : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Teleports you to your last death point");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.rare = 7;
            item.useTime = 90;
            item.useAnimation = 90;
            item.useStyle = 4;
            item.UseSound = SoundID.Item6;
            item.value = 250000; // 5 gold
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("ChampionMod:MagicMirrors");
            recipe.AddIngredient(mod.ItemType("MemoryPotion"), 5);
            recipe.AddRecipeGroup("ChampionMod:MythrilBars", 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool UseItem(Player player)
        {
            // If the player has not died
            if (player.GetModPlayer<MyPlayer>().LastDeathX == 0 || player.GetModPlayer<MyPlayer>().LastDeathY == 0)
            {
                Main.NewText("You have not died recently!");
            }
            else
            {
                player.GetModPlayer<MyPlayer>().memoryTimer = 30;

                // See MyPlayer.cs for the teleportation and dust effect
            }

            return true;
        }
    }
}