using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Svetsoft.Data.Expressions.Tests
{
    [TestClass]
    public class RulesEngineTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var filename = "Rules.json";
            var car = new SerializableCar();
            car.Classification = CarClassification.SportUtilityVehicle;
            car.WheelCount = 2;
            
            var json = File.ReadAllText(filename);
            var deserializedObject = JsonConvert.DeserializeObject<SerializableCar>(json);
            var ruleEngine = new RuleEngine<SerializableCar>();

            foreach (var deserializedRule in deserializedObject.Rules)
            {
                var rule = new Rule<SerializableCar>();

                foreach (var compositeCondition in deserializedRule.Conditions)
                {
                    foreach (var condition in compositeCondition.Conditions)
                    {
                        rule.AddCondition(condition.FieldName, condition.Operation, condition.Value, compositeCondition.LogicalOperation);
                    }
                }

                foreach (var action in deserializedRule.Actions)
                {
                    rule.AddAction(action.FieldName, action.Operation, action.Data);
                }

                ruleEngine.AddRule(rule);
            }

            ruleEngine.Evaluate(car);

            Assert.AreEqual(300, car.WheelCount);
        }
    }
}
