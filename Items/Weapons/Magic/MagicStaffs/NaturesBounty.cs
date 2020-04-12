using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Magic.MagicStaffs
{
    public class NaturesBounty : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nature's Bounty");
            Tooltip.SetDefault("Shoots a slow blue orb that deals damage");
            Item.staff[item.type] = true;
		}
		public override void SetDefaults()
		{
			item.damage = 4;
            item.magic = true;
			item.noMelee = true;
            item.mana = 10;
			item.width = 36;
			item.height = 36;
			item.useTime = 32;
			item.useAnimation = 32;
			item.useStyle = 5;
			item.knockBack = 1;
            item.value = 150; // 5 is 1 copper
			item.UseSound = SoundID.Item20;
            item.shoot = mod.ProjectileType("BlueOrb");
            item.shootSpeed = 4f;
            item.crit = -1; // 3 crit total
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("VerdantLeaf"), 5);
            recipe.AddRecipeGroup("Wood", 30);
            recipe.AddIngredient(ItemID.FallenStar, 3);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            // Offset the projectile's position relative to the direction that the weapon is pointing out
            Vector2 dir = Vector2.Normalize(Main.MouseWorld - position);
            position += dir * new Vector2(50, 55);
            return true;
        }
    }
}