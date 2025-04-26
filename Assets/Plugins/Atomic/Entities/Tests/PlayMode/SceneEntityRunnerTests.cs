using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Atomic.Entities.Tests
{
    public sealed class SceneEntityRunnerTests
    {
        [UnityTest]
        public IEnumerator AddBehaviourBeforeAwake()
        {
            //Arrange:
            var entityGO = new GameObject();
            var entity = entityGO.AddComponent<SceneEntity>();
            var runner = entityGO.AddComponent<SceneEntityRunner>();
            runner.AddEntity(entity);

            EntityBehaviourStub stub = new EntityBehaviourStub();
            bool success = entity.AddBehaviour(stub);
            
            Assert.IsTrue(success);
            Assert.IsFalse(stub.initialized);
            Assert.IsFalse(stub.enabled);
        
            yield return null;
            
            Assert.IsTrue(stub.initialized);
            Assert.IsTrue(stub.enabled);
            Assert.AreEqual(nameof(EntityBehaviourStub.Init), stub.invokationList[0]);
            Assert.AreEqual(nameof(EntityBehaviourStub.Enable), stub.invokationList[1]);
        
            yield return null;
            
            Assert.IsTrue(stub.updated);
            
            yield return new WaitForFixedUpdate();
            
            Assert.IsTrue(stub.fixedUpdated);
            Assert.IsTrue(stub.lateUpdated);
        
            //Finalize:
            GameObject.Destroy(runner);
            
            yield return null;
            Assert.IsTrue(stub.disabled);
            Assert.IsTrue(stub.disposed);
            
            Assert.AreEqual(nameof(EntityBehaviourStub.Disable), stub.invokationList[^2]);
            Assert.AreEqual(nameof(EntityBehaviourStub.Dispose), stub.invokationList[^1]);
        }
        
        [UnityTest]
        public IEnumerator AddBehaviourWhenAlreadyPlaying()
        {
            var entityGO = new GameObject();
            var entity = entityGO.AddComponent<SceneEntity>();
            var runner = entityGO.AddComponent<SceneEntityRunner>();
            runner.AddEntity(entity);

            yield return new WaitForSeconds(0.25f);


            EntityBehaviourStub stub = new EntityBehaviourStub();
            bool success = entity.AddBehaviour(stub);
            
            Assert.IsTrue(success);
            
            Assert.IsTrue(stub.initialized);
            Assert.IsTrue(stub.enabled);
            Assert.AreEqual(nameof(EntityBehaviourStub.Init), stub.invokationList[0]);
            Assert.AreEqual(nameof(EntityBehaviourStub.Enable), stub.invokationList[1]);
        
            yield return null;
            
            Assert.IsTrue(stub.updated);
            
            yield return new WaitForFixedUpdate();
            
            Assert.IsTrue(stub.fixedUpdated);
            Assert.IsTrue(stub.lateUpdated);
        
            //Finalize:
            GameObject.Destroy(entityGO);
        }
        
        [UnityTest]
        public IEnumerator AddAndRemoveRunnerInRuntime()
        {
            var entityGO = new GameObject();
            var entity = entityGO.AddComponent<SceneEntity>();
            EntityBehaviourStub stub = new EntityBehaviourStub();
            entity.AddBehaviour(stub);
            
            yield return new WaitForSeconds(0.25f);
            
            Assert.IsFalse(stub.initialized);
            Assert.IsFalse(stub.enabled);
            Assert.IsFalse(stub.updated);
            
            var runner = entityGO.AddComponent<SceneEntityRunner>();
            runner.AddEntity(entity);
            
            //Arrange:
            yield return null;
            
            //Assert:
            Assert.IsTrue(stub.initialized);
            Assert.IsTrue(stub.enabled);
            Assert.IsTrue(stub.updated);
            
            Assert.AreEqual(nameof(EntityBehaviourStub.Init), stub.invokationList[0]);
            Assert.AreEqual(nameof(EntityBehaviourStub.Enable), stub.invokationList[1]);

            yield return new WaitForFixedUpdate();
            
            Assert.IsTrue(stub.fixedUpdated);
            Assert.IsTrue(stub.lateUpdated);
            
            GameObject.Destroy(runner);

            Assert.IsTrue(stub.disabled);
            
            yield return null;
            Assert.IsTrue(stub.disposed);
            
            Assert.AreEqual(nameof(EntityBehaviourStub.Disable), stub.invokationList[^2]);
            Assert.AreEqual(nameof(EntityBehaviourStub.Dispose), stub.invokationList[^1]);
        }
    }
}