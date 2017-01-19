﻿using Analytics.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Analytics.Helpers.BO
{
    public class ShouldSerializeContractResolver1 : DefaultContractResolver
    {

        protected override JsonProperty CreateProperty(System.Reflection.MemberInfo member, Newtonsoft.Json.MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (property.DeclaringType == typeof(BaseEntity) || property.DeclaringType.BaseType == typeof(BaseEntity))
            {
                if (property.PropertyName == "serializableProperties")
                {
                    property.ShouldSerialize = instance => { return false; };
                }
                else
                {
                    property.ShouldSerialize = instance =>
                    {
                        var p = (Client)instance;
                        return p.serializableProperties.Contains(property.PropertyName);
                    };
                }
            }
            return property;
        }

    }
}