using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_World_Simulation {
    class Faction {
        public List<Faction> enemies;	// The factions Enemies.
		public List<Faction> allies;	// The factions Allies.
		// Note: Every other faction considered neutral.

		public Faction() {
			enemies = new List<Faction>();
			allies = new List<Faction>();
		}

		public void MakeAlly(Faction faction) {
			// Chech if this faction is an enemy and if
			// so remove him from enemies.
			if (enemies.Contains(faction)) {
				enemies.Remove(faction);
			}
			allies.Add(faction);
		}

        public void MakeEnemy(Faction faction) {
            // Check if this faction is an ally and if
			// so remove him from allies.
			if (allies.Contains(faction)) {
				allies.Remove(faction);
			}
			enemies.Add(faction);
        }
    }
}
