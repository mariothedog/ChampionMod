using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Materials
{
    public class AlchemerGunCasing : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Used as a casing for a gun that causes extreme chemical reactions.");
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.width = 74;
            item.height = 38;
            item.value = 150000;
            item.rare = 5;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Glass, 1);
            recipe.AddIngredient(ItemID.SoulofSight, 1);
            recipe.AddIngredient(ItemID.SoulofFright, 1);
            recipe.AddIngredient(ItemID.SoulofMight, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}