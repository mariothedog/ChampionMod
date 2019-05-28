using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SingleSwordMod.Items
{
    public class EpicGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Very Epic Gun");
            Tooltip.SetDefault("Epic gun for Epic people");
        }
        public override void SetDefaults()
        {
            item.damage = 50000;
            item.ranged = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 100;
            item.value = 100000000;
            item.rare = 13;
            item.UseSound = SoundID.Item12;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 1f;
            item.useAmmo = AmmoID.Bullet;
            // Use styles:
            // 1 - General swinging/throwing (Swords, Acorns)
            // 2 - Eating/Using (Potions)
            // 3 - Stabbing (Shortswords)
            // 4 - Holding up (Life Crystals, Summoning items)
            // 5 - Holding out (Guns, Spellbooks, Drills)
            item.useStyle = 5;
            //item.shoot = mod.ProjectileType("EpicLaser");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.Bullet) // or ProjectileID.WoodenArrowFriendly
            {
                type = mod.ProjectileType("EpicLaser"); // or ProjectileID.FireArrow;
            }
            int numberProjectiles = 4 + Main.rand.Next(2); // 4 or 5 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
                                                                                                                // If you want to randomize the speed to stagger the projectiles
                                                                                                                // float scale = 1f - (Main.rand.NextFloat() * .3f);
                                                                                                                // perturbedSpeed = perturbedSpeed * scale; 
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            // return false because we don't want tmodloader to shoot projectile
            return false; // return true to allow tmodloader to call Projectile.NewProjectile as normal
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        
    }
}
