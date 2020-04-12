using Microsoft.Xna.Framework;
using Terraria; 
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Ranged.Guns
{
    public class Peashooter : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Not to be confused with a certain plant");
        }

        public override void SetDefaults() {
            item.damage = 3;
            item.ranged = true;
            item.width = 36;
            item.height = 22;
            item.useTime = 23;
            item.useAnimation = 23;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.UseSound = SoundID.Item11;
            item.shoot = 10;
            item.shootSpeed = 7f;
            item.useAmmo = AmmoID.Bullet;

            // Value and rarity are both 0 (that is the default)
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Wood", 10);
            recipe.AddIngredient(ItemID.StoneBlock, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        // So bullet comes out of muzzle
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            position.Y -= 9;
			return true;
		}
    }
}
