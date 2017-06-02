﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Common.Extensions
{
    public static class ObservableCollectionExtensions
    {
        public static void AddRange<T>(this ObservableCollection<T> oc, IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }
            foreach (var item in collection)
            {
                oc.Add(item);
            }


        }
    }
}