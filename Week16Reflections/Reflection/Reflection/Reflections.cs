using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class IncrementableAtrribute : Attribute
    {
    }



    public enum Conditions
    {
        byClass,
        byProperty,
        None
    };

    public static class ExtensionMethod
    {
        public static void IncrementExtensionMethod(this object obj)
        {
            if (IsIncrementable(obj) == Conditions.byClass)
            {
                PropertyInfo[] props = obj.GetType().GetProperties();
                foreach (var p in props)
                {
                    var type = p.PropertyType;
                    if (type == typeof(int))
                    {
                        int val = (int)p.GetValue(obj) + 1;
                        p.SetValue(obj, val);
                    } else if(type == typeof(string))
                    {
                        string str = (string)p.GetValue(obj) + " added a string";
                        p.SetValue(obj, str);
                    }
                }
            }
            if (IsIncrementable(obj) == Conditions.byProperty)
            {
                PropertyInfo[] props = obj.GetType().GetProperties();
                foreach (var p in props)
                {
                    var type = p.PropertyType;
                    var typeHolder = p.IsDefined(typeof(IncrementableAtrribute), false);
                    if (type == typeof(int))
                    {
                        int val = (int)p.GetValue(obj) + 1;
                        p.SetValue(obj, val);
                    }
                    else if (type == typeof(string))
                    {
                        string str = (string)p.GetValue(obj) + " added a string";
                        p.SetValue(obj, str);
                    }
                    else
                    {
                        throw new ArgumentException("Wrong property type!");
                    }
                }
            }
        }


        private static Conditions IsIncrementable(object obj)
        {
            if (obj == null)
            {
                return Conditions.None;
            }
            var type = obj.GetType();
            PropertyInfo[] props = type.GetProperties();

            if (type.IsDefined(typeof(IncrementableAtrribute), false))
            {
                return Conditions.byClass;
            }
            else if (props.Any(p => p.IsDefined(typeof(IncrementableAtrribute), false)))
            {
                return Conditions.byProperty;
            }
            else
            {
                return Conditions.None;
            }
        }
    }

    [IncrementableAtrribute]
    public class test1
    {
        public int ValueOne { get; set; }
        public int ValueTwo { get; set; }
        public string StringValue { get; set; }
    }
}