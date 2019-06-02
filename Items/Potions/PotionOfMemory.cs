using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items
{
    public class PotionOfMemory : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Potion of Memory");
            Tooltip.SetDefault("Teleports you to your last death point");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.maxStack = 30;
            item.rare = 1;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useStyle = 2;
            item.UseSound = SoundID.Item3;
            item.consumable = true;
            item.value = Item.sellPrice(0, 0, 1, 20);
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
            if (player.GetModPlayer<MyPlayer>().LastDeathX == 0 || player.GetModPlayer<MyPlayer>().LastDeathY == 0)
            {
                Main.NewText("You have not died recently!");
            }
            else
            {
                player.position.X = player.GetModPlayer<MyPlayer>().LastDeathX;
                player.position.Y = player.GetModPlayer<MyPlayer>().LastDeathY;
            }
            return true;
        }
    }
}