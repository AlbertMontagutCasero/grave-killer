using System;
using System.Linq;
using System.Numerics;
using NSubstitute;
using NUnit.Framework;

namespace GraveKiller
{
    public class EnemyGeneratorTests
    {
        [Test]
        public void Spawn()
        {
            var doc = Substitute.For<EnemyGeneratorMotor>();
            var sut = new EnemyGenerator(doc);

            sut.SpawnEnemiesTest();
            
            Assert.That(sut.GetEnemyCount().Equals(1000));
        }
        
        [Test]
        public void SpawnInDifferentPositions()
        {
            var doc = Substitute.For<EnemyGeneratorMotor>();
            doc.GetEnemyPositions().Returns(
            new []{
                   new Vector3(0,0,0), 
                   new Vector3(0,1,0) ,
                   new Vector3(1,0,0) 
            }
            );
            var sut = new EnemyGenerator(doc);

            sut.SpawnEnemiesTest();
            var enemyPositions = sut.GetEnemyPositions().ToList();

            var i = 0;
            var different = true;
            do
            {
                var current = enemyPositions[i];
                enemyPositions.Remove(current);

                for (var j = 0; j < enemyPositions.Count; j++)
                {
                    var toCompare = enemyPositions[j];
                    if (current.Equals(toCompare))
                    {
                        different = false;
                    }    
                }
                
                i++;
            } while (different && i < enemyPositions.Count);
            
            Assert.That(different);
        }


        [Test]
        public void METHOD()
        {
            Random rnd = new Random();
            var random = rnd.NextDouble();
            var random2 = rnd.NextDouble();
            
            TestContext.Out.WriteLine(random);
            TestContext.Out.WriteLine(random2);
            Assert.That(!random.Equals(random2));
        }
    }
}
