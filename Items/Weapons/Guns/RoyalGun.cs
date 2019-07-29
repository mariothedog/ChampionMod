using Microsoft.Xna.Framework;
using Terraria; 
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Guns
{
    public class RoyalGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("It feels like it will slip out of your hands.");
        }

        public override void SetDefaults() {
            item.damage = 11;
            item.ranged = true;
            item.width = 16;
            item.height = 16;
            item.useTime = 6;
            item.useAnimation = 12;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 4;
            item.UseSound = SoundID.Item11;
            item.shoot = 10;
            item.shootSpeed = 3f;
            item.useAmmo = AmmoID.Bullet;
            item.rare = 1;
            item.value = 250000;
			item.reuseDelay = 14;
            // If you are reading this, you're gay.
        }
		
		public override bool ConsumeAmmo(Player player)
		{
			// Because of how the game works, player.itemAnimation will be 11, 7, and finally 3. (UseAmination - 1, then - useTime until less than 0.) 
			// We can get the Clockwork Assault Riffle Effect by not consuming ammo when itemAnimation is lower than the first shot.
			return !(player.itemAnimation < item.useAnimation - 2);
		}

		
		public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2, -2);
        }
		
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("KingsGel"), 5);;
            recipe.AddIngredient(ItemID.Gel, 100);
            recipe.AddRecipeGroup("ChampionMod:Tier4Bars", 15);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            // Change bullet to a royal bullet
            if (type == ProjectileID.Bullet)
            {
                type = mod.ProjectileType("RoyalBulletProjectile");
            }

            return true; // return true to allow tmodloader to call Projectile.NewProjectile as normal
        }
    }
}