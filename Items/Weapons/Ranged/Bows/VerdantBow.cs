using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Ranged.Bows
{
    public class VerdantBow : ModItem
    {

        public override void SetDefaults()
        {
            item.damage = 5;
            item.ranged = true;
            item.noMelee = true;
            item.width = 40;
            item.height = 20;
            item.useTime = 23;
            item.useAnimation = 23;
            item.useStyle = 5;
            item.knockBack = 4;
            item.value = 1000;
            item.rare = 0;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 6f;
            item.useAmmo = AmmoID.Arrow;
            item.crit = 6;
			item.scale = 0.75f;
        }

		public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("VerdantLeaf"), 9);
            recipe.AddRecipeGroup("Wood", 4);
			recipe.AddTile(TileID.LivingLoom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override Vector2? HoldoutOffset() // So player holds the handle
        {
            return new Vector2(3, 3);
        }
    }
}