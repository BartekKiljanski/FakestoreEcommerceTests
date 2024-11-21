using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FakestoreEcommerceTests.Helpers
{
    /// <summary>
    /// Porównywanie propertiesów o tej samej nazwie w obiektach
    /// </summary>

    class DataComparer
        {
            public bool CompareObjects<T>(T apiResult, T testResult)
            {
            foreach (PropertyInfo propObject1 in apiResult.GetType().GetProperties())
            {
                var propObject2 = testResult.GetType().GetProperty(propObject1.Name);

                if (propObject2.PropertyType.IsClass && propObject2.PropertyType.Name != "String" && propObject1.PropertyType.Namespace != "System.Collections.Generic")
                {
                    if (CompareObjects(propObject1.GetValue(apiResult), propObject2.GetValue(testResult)))
                    {
                        continue;
                    }
                    return false;
                }
                else if (propObject1.PropertyType.IsClass && propObject1.PropertyType.Name != "String" && (propObject1.PropertyType.IsArray || propObject1.PropertyType.Namespace == "System.Collections.Generic"))
                {

                    if (propObject1.GetValue(apiResult).GetType().GenericTypeArguments[0].ToString() == "System.Int32")
                    {
                        if (!compareLists((List<int>)propObject1.GetValue(apiResult), (List<int>)propObject2.GetValue(testResult)))
                            return false;
                    }
                    else if (propObject1.GetValue(apiResult).GetType().GenericTypeArguments[0].ToString() == "System.String")
                    {
                        if (!compareLists((List<string>)propObject1.GetValue(apiResult), (List<string>)propObject2.GetValue(testResult)))
                            return false;
                    }
                    else
                    {
                        Assert.Fail("Lista o nieznanym typie w obiektach do porównania");
                    }
                }
                else if (!Equals(propObject1.GetValue(apiResult), propObject2.GetValue(testResult)))
                    return false;
            }
            return true;
        }

            public bool CompareObjects<T>(T apiResult, T testResult, string[] propIgnore)
            {
            foreach (PropertyInfo propObject1 in apiResult.GetType().GetProperties())
            {
                if (!propIgnore.Contains(propObject1.Name))
                {
                    var propObject2 = testResult.GetType().GetProperty(propObject1.Name);

                    if (propObject2.PropertyType.IsClass && propObject2.PropertyType.Name != "String" && propObject1.PropertyType.Namespace != "System.Collections.Generic")
                    {
                        if (CompareObjects(propObject1.GetValue(apiResult), propObject2.GetValue(testResult)))
                        {
                            continue;
                        }
                        return false;
                    }
                    else if (propObject1.PropertyType.IsClass && propObject1.PropertyType.Name != "String" && (propObject1.PropertyType.IsArray || propObject1.PropertyType.Namespace == "System.Collections.Generic"))
                    {

                        if (propObject1.GetValue(apiResult).GetType().GenericTypeArguments[0].ToString() == "System.Int32")
                        {
                            if (!compareLists((List<int>)propObject1.GetValue(apiResult), (List<int>)propObject2.GetValue(testResult)))
                                return false;
                        }
                        else if (propObject1.GetValue(apiResult).GetType().GenericTypeArguments[0].ToString() == "System.String")
                        {
                            if (!compareLists((List<string>)propObject1.GetValue(apiResult), (List<string>)propObject2.GetValue(testResult)))
                                return false;
                        }
                    }
                    else if (!Equals(propObject1.GetValue(apiResult), propObject2.GetValue(testResult)))
                        return false;
                }
            }
            return true;
            }

        public bool compareLists<T>(List<T> apiParamList, List<T>testParamList)
        {
            if (apiParamList.Count != testParamList.Count) return false;

            for(int i = 0;i<apiParamList.Count;i++)
            {
                if (!Equals(apiParamList.ElementAt(i),testParamList.ElementAt(i))) return false;
            }

            return true;
        }
    }
}
