using System.Collections.Generic;
using System.Numerics;

namespace GraveKiller
{
    public interface EnemyGeneratorMotor
    {
        IEnumerable<Vector3> GetEnemyPositions();
        void GenerateNewEnemy(Vector3 position);
    }
}
