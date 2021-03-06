﻿namespace DhubSolutions.Reports.Domain.Services.Helpers
{
    public static class NullableHelper
    {
        public delegate bool TryDelegate<T>(string s, out T result)
           where T : struct;


        public static T? Parse<T>(string s, TryDelegate<T> tryDelegate)
            where T : struct
        {
            return tryDelegate(s, out T value) ? value : default(T?);
        }
    }
}