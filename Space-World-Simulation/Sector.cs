using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_World_Simulation {
    class Sector {
        public List<Sector> connections;	// Our connections to other sectors.
        public List<Unit> units;		// The units contained within this sector.
		public World world { get; private set; }

		public string name;


		public Sector(string name, World world) {
			this.units = new List<Unit>();
			this.connections = new List<Sector>();
			this.world = world;
			this.name  = name;
		}

        public void Update() {
			// Update each unit.
            foreach (Unit unit in units) {
				unit.Update(this);
            }
        }
    }
}
