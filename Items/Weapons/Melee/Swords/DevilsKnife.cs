using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Melee.Swords
{
	public class DevilsKnife : ModItem
	{
        // See NPCGlobal.cs for npc damaging code

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Devil's Knife");
            Tooltip.SetDefault("A knife that instakills Town NPCs");
        }

        public override void SetDefaults()
        {
			item.damage = 5;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = 3;
			item.knockBack = 2;
            item.value = 200000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
        }
    }
}