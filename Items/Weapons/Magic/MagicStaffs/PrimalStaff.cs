using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Magic.MagicStaffs
{
	public class PrimalStaff : ModItem
	{
		public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Fires ghostly orbs from the sky that pierce all blocks");
            Item.staff[item.type] = true;
		}

		public override void SetDefaults()
        {
			item.damage = 16;
			item.magic = true;
			item.mana = 10;
			item.width = 48;
			item.height = 58;
			item.useTime = 16;
		    item.useAnimation = 16;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 5;
			item.rare = 3;
            item.value = 30000;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("GhostlyOrb");
			item.shootSpeed = 13f;
	    }

		public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("ChampionMod:Vilethorn");
            recipe.AddIngredient(ItemID.AquaScepter);
            recipe.AddIngredient(mod.ItemType("OpticalResidue"));
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 target = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
            float ceilingLimit = target.Y;
            if (ceilingLimit > player.Center.Y - 200f)
            {
                ceilingLimit = player.Center.Y - 200f;
            }
            for (int i = 0; i < 3; i++)
            {
                Vector2 pos = player.Center + new Vector2((-(float)Main.rand.Next(0, 401) * player.direction), -600f);
                pos.Y -= (100 * i);
                Vector2 heading = target - pos;
                if (heading.Y < 0f)
                {
                    heading.Y *= -1f;
                }
                if (heading.Y < 20f)
                {
                    heading.Y = 20f;
                }
                heading.Normalize();
                heading *= new Vector2(speedX, speedY).Length();
                float spdX = heading.X;
                float spdY = heading.Y + Main.rand.Next(-40, 41) * 0.02f;

                Projectile.NewProjectile(pos.X, pos.Y, spdX, spdY, type, damage, knockBack, player.whoAmI, 0f, ceilingLimit);
            }

            return false;
        }
    }
}