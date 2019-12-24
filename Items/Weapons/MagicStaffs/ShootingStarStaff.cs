using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.MagicStaffs
{
	public class ShootingStarStaff : ModItem
	{
		public override void SetStaticDefaults()
        {
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
        {
			item.damage = 36;
			item.magic = true;
			item.mana = 8;
			item.width = 48;
			item.height = 58;
			item.useTime = 12;
		    item.useAnimation = 12;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 3;
			item.rare = 5;
            item.value = 200000;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = 92;
			item.shootSpeed = 10f;
	    }

		public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 15);
     		recipe.AddIngredient(ItemID.StarVeil);
            recipe.AddIngredient(ItemID.FallenStar, 10);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 offset = new Vector2(speedX, speedY);
            offset.Normalize();
            offset *= 50;

            Vector2 offset2 = offset *= 0.8f;
            for (int i = 0; i < 3; i++)
            {
                Projectile.NewProjectile(position.X + offset.X, position.Y + offset.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
                offset += offset2;
            }
            return false;
        }
    }
}