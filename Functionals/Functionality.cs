using System;
using System.Collections.Generic;
using System.Linq;

namespace Functionals
{
    public static class Miscellaneous
    {

        public static Nothing Ignore<TInput>(this TInput _) =>
            new Nothing();

    }

    public static class Providers
    {
        public static TOutput With<TInput, TOutput>(this TInput @this, Func<TInput, TOutput> f) => f(@this);

        public static TOutput With<Nothing, TOutput>(this Nothing _, TOutput thing) => thing;

        public static IEnumerable<TOutput> With<Nothing, TOutput>(this Nothing _, params TOutput[] things) => things;

    }
    
    public static class Executors
    {
        public static Nothing Do<TInput>(this TInput @this, Action<TInput> f)
        {
            f(@this);
            return new Nothing();
        }
        
        public static Nothing Do<TInput>(this TInput @this, params Action<TInput>[] fs)
        {
            foreach (var f in fs)
                f(@this);
            return new Nothing();
        }
    }
    
    public static class Validations
    {
        public static bool ValidateAll<TInput>(this TInput input, params Func<TInput, bool>[] validators) =>
            validators.All(v => v(input));
    
        public static bool ValidateAny<TInput>(this TInput input, params Func<TInput, bool>[] validators) =>
            validators.Any(v => v(input));

        public static bool IsPositive(this int input) => input >= 0;
        public static bool LessThan(this int input, int validation) => input < validation;
        public static bool GreaterThanOrEqualTo(this int input, int validation) => input >= validation;
    }
}