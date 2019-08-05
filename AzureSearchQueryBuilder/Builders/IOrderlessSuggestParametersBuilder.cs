﻿using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.Azure.Search.Models;

namespace AzureSearchQueryBuilder.Builders
{
    public interface IOrderlessSuggestParametersBuilder<TModel> : IParametersBuilder<TModel, SuggestParameters>
    {
        IEnumerable<string> Select { get; }

        bool UseFuzzyMatching { get; }

        ISuggestParametersBuilder<TModel> WithSelect<TProperty>(Expression<PropertyLambdaDelegate<TModel, TProperty>> lambdaExpression);

        ISuggestParametersBuilder<TModel> WithUseFuzzyMatching(bool useFuzzyMatching);
    }
}