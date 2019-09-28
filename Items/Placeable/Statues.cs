using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Placeable
{
    class HyphenStatue : ModItem
    {
        public string name = "Hyphen"; // Default

        public override string Texture { get { return $"ChampionMod/Items/Placeable/{name}Statue"; } }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("'-' Statue");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ArmorStatue);
            item.createTile = mod.TileType($"{name}StatueTile");
            item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}