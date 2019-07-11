using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Swords
{
    public class EnchantedKatana : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enchanted Katana");
            Tooltip.SetDefault("A powerful blade, both in forgery and enchantment");
        }
        public override void SetDefaults()
        {
            item.damage = 26;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 21;
            item.useAnimation = 21;
            item.useStyle = 1;
            item.knockBack = 4;
            item.value = 250000;
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("EnchantedKatanaBeam");
            item.shootSpeed = 10f;
            item.crit = 6; // Terraria adds 4% crit to everything so 6 is actually 10
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.EnchantedSword, 1);
            recipe.AddIngredient(ItemID.Katana, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(5) == 0) // Lowers amount of dust
            {
                int dustChoice;
                switch (Main.rand.Next(3))
                {
                case 0:
                    dustChoice = 15;
                    break;
                case 1:
                    dustChoice = 57;
                    break;
                default:
                    dustChoice = 58;
                    break;
                }
                Dust enchantedDust = Main.dust[Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, dustChoice, (float)(player.direction * 2), 0f, 150, default(Color), 1.3f)];
                enchantedDust.velocity *= 0.2f;
            }
        }
    }
}