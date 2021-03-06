﻿namespace LinqToQueryString.UnitTests
{
    using System;
    using System.Linq;

    using LinqToQuerystring;
    using LinqToQuerystring.Exceptions;

    using Machine.Specifications;
    
    public class When_using_eq_filter_on_a_dynamic_type_decimal_property_without_m_suffix : Dynamics
    {
        private static Exception ex;

        private Because of = () => ex = Catch.Exception(() => collection.AsQueryable().LinqToQuerystring("$filter=[Score] eq 0.4").ToList());

        private It should_throw_an_exception = () => ex.ShouldBeOfType<InvalidCastException>();
    }

    #region Filter on String tests

    public class When_using_eq_filter_on_a_single_with_an_invalid_escape_sequence : Filtering
    {
        private Because of = () => ex = Catch.Exception(() => result = edgeCaseCollection.AsQueryable().LinqToQuerystring(@"?$filter=Name eq 'Apple\Bob'"));

        private It should_throw_an_exception = () => ex.ShouldBeOfType<InvalidEscapeSequenceException>();
    }

    public class When_using_gt_filter_on_a_single_string : Filtering
    {
        private Because of = () => ex = Catch.Exception(() => result = concreteCollection.AsQueryable().LinqToQuerystring("?$filter=Name gt 'B'"));

        private It should_throw_an_exception = () => ex.ShouldBeOfType<InvalidOperationException>();
    }

    public class When_using_ge_filter_on_a_single_string : Filtering
    {
        private Because of = () => ex = Catch.Exception(() => result = concreteCollection.AsQueryable().LinqToQuerystring("?$filter=Name ge 'B'"));

        private It should_throw_an_exception = () => ex.ShouldBeOfType<InvalidOperationException>();
    }

    public class When_using_lt_filter_on_a_single_string : Filtering
    {
        private Because of = () => ex = Catch.Exception(() => result = concreteCollection.AsQueryable().LinqToQuerystring("?$filter=Name lt 'B'"));

        private It should_throw_an_exception = () => ex.ShouldBeOfType<InvalidOperationException>();
    }

    public class When_using_le_filter_on_a_single_string : Filtering
    {
        private Because of = () => ex = Catch.Exception(() => result = concreteCollection.AsQueryable().LinqToQuerystring("?$filter=Name lt 'B'"));

        private It should_throw_an_exception = () => ex.ShouldBeOfType<InvalidOperationException>();
    }

    #endregion

    #region Filter on Bool tests

    public class When_using_gt_filter_on_a_single_bool : Filtering
    {
        private Because of = () => ex = Catch.Exception(() => result = concreteCollection.AsQueryable().LinqToQuerystring("?$filter=Complete gt false"));

        private It should_throw_an_exception = () => ex.ShouldBeOfType<InvalidOperationException>();
    }

    public class When_using_ge_filter_on_a_single_bool : Filtering
    {
        private Because of = () => ex = Catch.Exception(() => result = concreteCollection.AsQueryable().LinqToQuerystring("?$filter=Complete ge datetime'2003-01-01T00:00'"));

        private It should_throw_an_exception = () => ex.ShouldBeOfType<InvalidOperationException>();
    }

    public class When_using_lt_filter_on_a_single_bool : Filtering
    {
        private Because of = () => ex = Catch.Exception(() => result = concreteCollection.AsQueryable().LinqToQuerystring("?$filter=Complete lt datetime'2003-01-01T00:00'"));

        private It should_throw_an_exception = () => ex.ShouldBeOfType<InvalidOperationException>();
    }

    public class When_using_le_filter_on_a_single_bool : Filtering
    {
        private Because of = () => ex = Catch.Exception(() => result = concreteCollection.AsQueryable().LinqToQuerystring("?$filter=Complete le datetime'2003-01-01T00:00'"));

        private It should_throw_an_exception = () => ex.ShouldBeOfType<InvalidOperationException>();
    }

    #endregion
}
