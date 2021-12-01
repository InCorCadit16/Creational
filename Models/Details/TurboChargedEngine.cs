using System;
using System.Collections.Generic;
using System.Text;

namespace GarageSimulation.Models
{
    class TurboChargedEngine : Engine
    {
        private Engine engine;

        public float Boost { get; set; }

        public TurboChargedEngine(Engine engine): base(engine.detailApi)
        {
            this.engine = engine;
            Boost = 1.3f;
        }

        public override string ToString()
        {
            return engine.ToString() + $"Charge type - Turbo; Boost - {Boost};";
        }
    }
}
