using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Consumables
{
    public class MemoryPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Memory Potion");
            Tooltip.SetDefault("Teleports you to your last death point");
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
            item.UseSound = SoundID.Item6;
            item.consumable = true;
            item.value = 205000; // 4 gold + 10 silver
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Waterleaf);
            recipe.AddIngredient(mod.ItemType("MemoryFish"));
            recipe.AddTile(TileID.Bottles);
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
                player.GetModPlayer<MyPlayer>().memoryTimer = 5;

                // See MyPlayer.cs for the teleportation and dust effect
            }

            return true;
        }
    }
}