/*
   Copyright 2012 Michael Edwards
 
   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
 
*/ 
//-CRE-

using System;
using System.Linq.Expressions;

namespace Glass.Mapper.Sc.Configuration.Fluent
{
    /// <summary>
    /// Indicates that the property should be populated with the parent item.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SitecoreParent<T> : AbstractPropertyBuilder<T, SitecoreParentConfiguration>
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="SitecoreParent{T}"/> class.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public SitecoreParent(Expression<Func<T, object>> ex)
            : base(ex)
        {
        }

        /// <summary>
        /// Indicates if the parent shouldn't be loaded lazily.
        /// </summary>
        public SitecoreParent<T> IsNotLazy()
        {
            Configuration.IsLazy = false;
            return this;
        }
        /// <summary>
        /// Indicates the type should be inferred from the item template
        /// </summary>
        /// <returns>SitecoreParent{`0}.</returns>
        public SitecoreParent<T> InferType()
        {
            Configuration.InferType = true;
            return this;
        }



    }
}




