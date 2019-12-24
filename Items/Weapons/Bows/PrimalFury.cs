using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Bows
{
    public class PrimalFury : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Fires a ghostly arrow behind the equipped arrow when shot");
        }

        public override void SetDefaults()
        {
            item.damage = 20;
            item.ranged = true;
            item.noMelee = true;
            item.width = 40;
            item.height = 20;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 5;
            item.knockBack = 5;
            item.value = 30000;
            item.rare = 3;
            item.UseSound = SoundID.Item5;
            item.shoot = 10;
            item.shootSpeed = 9f;
            item.useAmmo = AmmoID.Arrow;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("ChampionMod:DemonBow");
            recipe.AddIngredient(ItemID.MoltenFury);
            recipe.AddIngredient(mod.ItemType("OpticalResidue"));
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 speed = new Vector2(speedX, speedY);
            Vector2 offset = Vector2.Normalize(speed) * -30;
            Vector2 ghostPosition = position + offset;
            Projectile.NewProjectile(ghostPosition, speed, mod.ProjectileType("GhostlyArrowProjectile"), damage, knockBack, player.whoAmI);
			return true;
        }
    }
}