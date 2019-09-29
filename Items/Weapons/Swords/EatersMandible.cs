using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Swords
{
	public class EatersMandible : ModItem
	{
		public override void SetDefaults()
        {
			item.damage = 21;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 1;
			item.knockBack = 4;
            item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
            item.shoot = mod.ProjectileType("VileSpit");
            item.shootSpeed = 8f;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            /*for (int i = 0; i < 4; i++)
            {
                int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, 45, 0f, 0f, 255, default);
                Main.dust[dust].noLight = true;
                Main.dust[dust].noGravity = true;
            }*/
        }

        /*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }*/
    }
}